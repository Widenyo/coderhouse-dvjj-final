using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        Schhmovement();
    }

    private void Schhmovement()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float axisX;
        float axisZ;

        axisX = Input.GetAxis("Horizontal");
        axisZ = Input.GetAxis("Vertical");
        var direction = new Vector3(axisX, 0, axisZ);
        var rotation = new Vector3(0f, Mathf.Atan2(-axisZ, axisX), 0f) * (180 / Mathf.PI);
        rb.AddForce(direction * speed, ForceMode.Acceleration);
        if(axisX == 0f && !(axisZ < 0f || axisZ > 0f) && !(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            return;
        }
        transform.eulerAngles = rotation;
    }
}
