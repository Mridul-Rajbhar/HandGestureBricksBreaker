import cv2
import mediapipe as mp
import time
import socket

cap = cv2.VideoCapture(0)
mpHands = mp.solutions.hands
hands = mpHands.Hands(max_num_hands=1)
mpDraw = mp.solutions.drawing_utils
pTime = 0
cTime = 0
port_number = 2000
obj = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
message = "0"


while True:
    # cap.set(cv2.CAP_PROP_FRAME_WIDTH, 1280)
    # cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 600)

    success, img = cap.read()
    img = cv2.flip(img,1)
    imgRGB = cv2.cvtColor(img,cv2.COLOR_BGR2RGB)
    results = hands.process(imgRGB)
    if results.multi_hand_landmarks:
        for handLms in results.multi_hand_landmarks:

            for id, lm in enumerate(handLms.landmark):
                # print(id,lm)
                h,w,c =img.shape
                cx, cy= int(lm.x * w), int(lm.y * h)
                if id==8:
                    message = str(cx)
                    obj.sendto(bytes(message, 'utf-8'), (socket.gethostbyname(socket.gethostname()), port_number))
                    cv2.circle(img, (cx, cy), 7, (0, 0, 0), -1)
                    cv2.putText(img, str(cx), (cx, cy), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 255), 2)
            mpDraw.draw_landmarks(img, handLms, mpHands.HAND_CONNECTIONS)
        #print(message)

    cTime = time.time()
    fps = 1/(cTime - pTime)
    pTime = cTime
    cv2.putText(img,str(int(fps)),(10,70),cv2.FONT_HERSHEY_SIMPLEX,3,(255,0,255),3)
    cv2.imshow("Image",img)
    #obj.sendto(bytes(message, 'utf-8'), (socket.gethostbyname(socket.gethostname()), port_number))
    if cv2.waitKey(1) & 0xFF == ord('q'):
        obj.shutdown(socket.SHUT_RDWR)
        obj.close()
        break
