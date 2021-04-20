using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Jump : MonoBehaviour
{
    Rigidbody rb;
    public bool jumpKeyPressed = false;
    public float jumpForce;
    public float extraGravity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        Jump();
        ApplyExtraGravity();
    }

    void ApplyExtraGravity()
    {
        if (rb.velocity.y < 0)
            rb.AddForce(Vector3.down*extraGravity);
    }

    void Jump()
    { 
        if (jumpKeyPressed
            && Physics.Raycast(transform.position, Vector3.down, transform.localScale.y))
        {

            rb.AddForce(new Vector3(0f, jumpForce, 0f));
        }
    }
}
