using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyCharacterController : MonoBehaviour
{
    Rigidbody rb;
    Collider col;

    [SerializeField]
    PhysicMaterial stopPhysicMat;
    [SerializeField]
    PhysicMaterial movePhysicMat;

    Vector2 input;
    Vector3 inputDir;
    Vector3 camRelativeInputDir;

    [SerializeField]
    float acceleration = 10;
    [SerializeField]
    float maxSpeed = 2;

    [SerializeField, Range(0, 1)]
    float turnSpeed = 0.5f; 

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        col = this.GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        SetCamRelativeInput();

        MovePlayer();
        SetPlayerRotation();

        SetPhysicsMaterial();
    }


    public void OnMove(InputAction.CallbackContext context) 
    {
        input = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Convers the player's input into a vector that is relevant to the camera
    /// </summary>
    void SetCamRelativeInput()
    {
        inputDir = new Vector3(input.x, 0, input.y);
        inputDir = inputDir.normalized;

        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0;

        Quaternion camLocalRotation = Quaternion.LookRotation(camForward);
        camRelativeInputDir = camLocalRotation * inputDir;
    }
    
    /// <summary>
    /// If the player has changed their input direction the player rotates to face their direction
    /// </summary>
    void SetPlayerRotation()
    {
        if (camRelativeInputDir.sqrMagnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(camRelativeInputDir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, turnSpeed);
        }
    }

    /// <summary>
    /// If the player is holding the stick in any direction, move the player
    /// </summary>
    void MovePlayer()
    {
        if (rb.velocity.sqrMagnitude < maxSpeed)
            rb.AddForce(camRelativeInputDir * acceleration, ForceMode.Acceleration);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    /// <summary>
    /// If the player is moving, change the physics material to low friction. If they are stopped, set it to high friction.
    /// </summary>
    void SetPhysicsMaterial()
    {
        col.material = inputDir.sqrMagnitude > 0 ? movePhysicMat : stopPhysicMat;
    }


}
