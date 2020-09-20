using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyCharacterController : MonoBehaviour
{
    Rigidbody rb;
    Collider col;

    [SerializeField]
    PhysicMaterial stopPhysicMat;
    [SerializeField]
    PhysicMaterial movePhysicMat;

    Vector2 input;
    
    [SerializeField]
    float acceleration = 10;
    [SerializeField]
    float maxSpeed = 2;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        col = this.GetComponent<Collider>();
    }
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");       
    }

    void FixedUpdate()
    {
        Vector3 inputDir = new Vector3(input.x, 0, input.y);
        inputDir = inputDir.normalized;

        col.material = inputDir.sqrMagnitude > 0 ? movePhysicMat : stopPhysicMat;

        if(rb.velocity.sqrMagnitude < maxSpeed) 
            rb.AddForce(inputDir * acceleration, ForceMode.Acceleration);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    
}
