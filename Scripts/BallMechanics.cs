using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMechanics : MonoBehaviour
{
    #region Public variables
    public ParticleSystem[] explosion;
    public Transform platform;
    public Rigidbody2D rb;
    public Text scoreText, lifeText;
    [HideInInspector]
    public static int score = 0;
    #endregion

    #region Private Variables
    Sounds soundEff;
    Transform temp;
    int life = 3;

    #endregion


    private void Awake()
    {
        soundEff = GetComponent<Sounds>();
    }

    void Update()
    {
        if(life == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        life--;
        Vector3 resestPos = new Vector3(platform.transform.position.x, -4.316f, platform.transform.position.z);
        transform.position = resestPos;
        lifeText.text = "Life: " + life;
        //rb.AddForce(Vector2.up * 40f * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Bricks")
        {
            score += 25;
            scoreText.text = "Score: " + score;
            temp = collision.gameObject.transform;
            string temp2 = collision.gameObject.transform.name;
            Destroy(collision.gameObject);
            ParticleSystem temp3;
            if (temp2 == "Yellow")
                temp3 = explosion[4];
            else if (temp2 == "Blue")
                temp3 = explosion[5];
            else if (temp2 == "Red")
                temp3 = explosion[3];
            else if (temp2 == "Pink")
                temp3 = explosion[2];
            else if (temp2 == "Green")
                temp3 = explosion[1];
            else
                temp3 = explosion[0];

            soundEff.brickSound();
           ParticleSystem temp4 =  Instantiate(temp3, temp.position, temp.rotation);
           Destroy(temp4.gameObject,2.0f);
        
        }

       if(collision.gameObject.name == "Platform")
        {
            soundEff.platformSound();   
        }

       if(collision.gameObject.tag == "Walls")
        {
            soundEff.wallSound();
        }
    }
}
