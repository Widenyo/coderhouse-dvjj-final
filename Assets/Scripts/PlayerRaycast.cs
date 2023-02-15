using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] private float rayDistance = 12f;
    [SerializeField] private float lungeForce = 30f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.right);

            if (Physics.Raycast(ray, out hit) && hit.distance < rayDistance && hit.transform.CompareTag("Enemy"))
            {
                m_Rigidbody.AddForce(transform.right * lungeForce, ForceMode.Impulse);
            }

        }
    }
}
