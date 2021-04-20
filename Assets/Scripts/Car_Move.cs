using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour
{
    private Rigidbody rb;//Physics can affect us
    private float verticalInput=0f;
    private float horizontalInput=0f;
    public float forceMagnitude;
    public float timeToRotate = 0.1f;
    public float angleMangitude = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    

    private void FixedUpdate()
    {
        rb.AddRelativeForce(new Vector3(0f,0f,forceMagnitude*verticalInput));
        float currentAngle = transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.Euler(new Vector3(0f, Mathf.LerpAngle(currentAngle,currentAngle+horizontalInput*angleMangitude,timeToRotate),0f));
    }

}
