using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacterController : MonoBehaviour
{
    Rigidbody rb;
    
    Vector2 input;

    [SerializeField]
    float acceleration = 10;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");       
    }

    void FixedUpdate()
    {
        Vector3 inputDir = new Vector3(input.x, 0, input.y);
        input.Normalize();

        rb.AddForce(inputDir * acceleration);
    }
}
