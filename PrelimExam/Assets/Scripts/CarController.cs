using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float gravityMutliplier;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb  = GetComponent<Rigidbody>(); 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Turn();
        Fall();
    }
    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * speed * 10);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-Vector3.forward * speed * 10);
        }
        Vector3 localvelocity = transform.InverseTransformDirection(rb.velocity);
        localvelocity.x = 0;
        rb.velocity = transform.TransformDirection(localvelocity);
    }
    void Turn()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * turnSpeed * 10);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * turnSpeed* 10);
        }
    }
    void Fall()
    {
        rb.AddForce(Vector3.down * gravityMutliplier * 10);
    } 
}
