using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData m_BulletData;
    private float m_bulletTimeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * m_BulletData.getSpeed * Time.deltaTime;
        m_bulletTimeElapsed += Time.deltaTime;
        if (m_bulletTimeElapsed >= m_BulletData.getDuration)
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