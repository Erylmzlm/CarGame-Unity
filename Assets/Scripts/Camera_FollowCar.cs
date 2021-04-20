using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowCar : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    float horizontalInput =0f;

    private void Awake()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler( new Vector3(
            transform.rotation.eulerAngles.x,
            player.transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z));
        float rotationIncrement = 1f;
        float interpolationIncrement=0.2f;
        Vector3 newOffset = Quaternion.AngleAxis(horizontalInput*rotationIncrement,Vector3.up).normalized*offset;
        //smoothing
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, player.transform.position.x + newOffset.x, interpolationIncrement),
            Mathf.Lerp(transform.position.y, player.transform.position.y + newOffset.y, interpolationIncrement),
            Mathf.Lerp(transform.position.z, player.transform.position.z + newOffset.z, interpolationIncrement));
        //Update the offset
        offset = newOffset;
    }


}
