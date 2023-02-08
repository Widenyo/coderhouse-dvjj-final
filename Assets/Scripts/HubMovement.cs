using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Schhmovement();
    }

    private void Schhmovement()
    {
        float axisX;
        float axisZ;

        axisX = Input.GetAxis("Horizontal");
        axisZ = Input.GetAxis("Vertical");
        var direction = new Vector3(axisX, 0, axisZ);
        transform.position += direction * (speed*Time.deltaTime);
    }
}
