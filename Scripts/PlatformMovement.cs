using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class PlatformMovement : MonoBehaviour
{
    #region Private Variables
    private int portNumber = 2000;
    private UdpClient udpClient;
    private Rigidbody2D rb;
    float x = 0;
    #endregion

    #region Public Variables
    public float smooth = 0.04f;
    #endregion
    // Start is called before the first frame update
    void Awake()
    {
        udpClient = new UdpClient(portNumber);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        IPEndPoint remote = null;
        byte[] data = udpClient.Receive(ref remote);
        string message = Encoding.ASCII.GetString(data);
        float t = x;
        x = float.Parse(message);
        //print(x);
        x = (x - 300) * smooth;
        
        if (x <= -8.33f)
            transform.position = new Vector3(-8.33f, transform.position.y, transform.position.z);
        else if(x >=8.33f)
            transform.position = new Vector3(8.33f, transform.position.y, transform.position.z);
        else 
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

    }
}
