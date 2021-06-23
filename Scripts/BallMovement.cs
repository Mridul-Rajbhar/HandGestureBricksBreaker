using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update

    #region Private Variables
    [SerializeField]
    private float speed = 40f;
    public Rigidbody2D rb;
    #endregion
    void Start()
    {
        rb.AddForce(new Vector2(0, 1) * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
