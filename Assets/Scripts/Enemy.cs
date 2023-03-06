using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum State
    {
        Idle,
        Shoot,
        Escape,
        Dead
    }
    [SerializeField] private EnemyData m_enemyData;
    public int hp;
    [SerializeField] private State state = State.Idle;
    private float timeElapsedToHeal;
    [SerializeField] private GameObject m_bulletPrefab;
    private GameObject player;
    private float m_shootTimeElapsed = 0f;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void Start()
    {
        hp = m_enemyData.getLife;
        player = GameObject.Find("Player_main");
    }



    // Update is called once per frame
    void Update()
    {
        setState();
        executeState(state);
    }

    private void setState()
    {
        float distance = (player.transform.position - transform.position).magnitude;
        if(hp <= 0)
        {
            state = State.Dead;
        }
        else if(hp <= 5 && distance < 50f)
        {
            state = State.Escape;
        }
        else if (distance < 60f)
        {
            state = State.Shoot;
        }
        else
        {
            state = State.Idle;
        }
    }

    private void executeState(State state)
    {
        switch (state)
        {
            case State.Idle:
                Idle();
                break;
            case State.Shoot:
                Shoot();
                break;
            case State.Escape:
                Escape();
                break;
            case State.Dead:
                Dead();
                break;
        }
    }

    private void Idle()
    {
        if (m_enemyData.getLife != hp)
        {
            timeElapsedToHeal += Time.deltaTime;
            if (timeElapsedToHeal >= m_enemyData.getTimeToHeal)
            {
                timeElapsedToHeal = 0f;
                hp += 1;
            }
        }
    }

    private void Shoot()
    {

        if (transform.position.x < player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.right);

        if (Physics.Raycast(ray, out hit) && hit.distance < m_enemyData.getRayDistance && hit.transform.CompareTag("Player"))
        {
            Transform gunPoint = transform.Find("GunPoint").transform;
            m_shootTimeElapsed += Time.deltaTime;
            //Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
            if (m_shootTimeElapsed >= m_enemyData.getShootCd)
            {
                Instantiate(m_bulletPrefab, gunPoint.position, transform.rotation);
                m_shootTimeElapsed = 0f;
            }
        }



    }

    private void Escape()
    {
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        transform.position -= new Vector3(vectorToPlayer.normalized.x, 0f, 0f) * (m_enemyData.getSpeed * Time.deltaTime);
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

}
