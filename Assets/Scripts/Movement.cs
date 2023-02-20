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
        checkFall();
    }

    void Schhmovin()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        float axisX;

        axisX = Input.GetAxis("Horizontal");

        if(axisX < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        Vector3 movement = new Vector3(axisX, 0f, 0f) * speed * Time.deltaTime;
        transform.position += movement;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            canJump = false;
        }


    }

    private void checkFall()
    {
        if(transform.position.y < -20f)
        {
            transform.position = new Vector3(0f, 10f, 0f);
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
