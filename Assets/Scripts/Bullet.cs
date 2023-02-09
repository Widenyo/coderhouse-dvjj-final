using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float bulletDuration = 2f;
    private float bulletTimeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * speed);
        transform.position += transform.right * speed * Time.deltaTime;
        bulletTimeElapsed += Time.deltaTime;
        if (bulletTimeElapsed >= bulletDuration)
        {
            Destroy(gameObject);
        }
    }
}