using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private bool canJump;

    void Update()
    {
        Schhmovin();
    }

    void Schhmovin()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float axisX;
        float axisY;

        axisX = Input.GetAxis("Horizontal");
        axisY = jumpHeight;

        var direction = new Vector3(axisX, 0, 0);
        rb.AddForce(direction * speed, ForceMode.Acceleration);
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * axisY, ForceMode.Acceleration);
            canJump = false;
        }

        if(axisX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            canJump = true;
        }
    }
}
