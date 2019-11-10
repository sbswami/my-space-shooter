using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float horizotal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizotal, 0.0f, vertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, xMin,xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, zMin,zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
}
