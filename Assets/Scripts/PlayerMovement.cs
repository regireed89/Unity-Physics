using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public Vector3 Velocity;
    Vector3 move;
    private Rigidbody rb;
	void Start ()
    {
        Velocity = rb.velocity;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if(Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(Vector3.left * speed);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(Vector3.right * speed);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(Vector3.back * speed);
       
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity -= rb.velocity;
            if(rb.velocity.z <= 0)
            {
                transform.Rotate(new Vector3(0, 1, 0), 180);
                return;
            }
            return;
        }
    }

    public void QuickTurn()
    {
        
    }
}
