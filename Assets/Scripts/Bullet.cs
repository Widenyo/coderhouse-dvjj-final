using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_speed = 5f;
    [SerializeField] private float m_bulletDuration = 2f;
    private float m_bulletTimeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Collider collider = GetComponent<Collider>();
        transform.position += transform.right * m_speed * Time.deltaTime;
        m_bulletTimeElapsed += Time.deltaTime;
        if (m_bulletTimeElapsed >= m_bulletDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().hp -= 1;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Movement>().TakeDamage();
        }
        //Al colisionar, se destruye si o si.
        Destroy(gameObject);
    }

}