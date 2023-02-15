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
    [SerializeField] private int m_maxHp = 10;
    public int hp;
    [SerializeField] private State state = State.Idle;
    [SerializeField] private float m_timeToHeal = 5.0f;
    private float timeElapsedToHeal;
    //private float rotationSpeed = 2.0f;
    private float speed = 6.0f;
    [SerializeField] private GameObject m_bulletPrefab;
    private GameObject player;
    [SerializeField] private float m_shootCd = 1.5f;
    [SerializeField] private float m_shootTimeElapsed = 0f;
    [SerializeField] private float rayDistance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        hp = m_maxHp;
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
        if (m_maxHp != hp)
        {
            timeElapsedToHeal += Time.deltaTime;
            if (timeElapsedToHeal >= m_timeToHeal)
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

        if (Physics.Raycast(ray, out hit) && hit.distance < rayDistance && hit.transform.CompareTag("Player"))
        {
            Transform gunPoint = transform.Find("GunPoint").transform;
            m_shootTimeElapsed += Time.deltaTime;
            //Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
            if (m_shootTimeElapsed >= m_shootCd)
            {
                Instantiate(m_bulletPrefab, gunPoint.position, transform.rotation);
                m_shootTimeElapsed = 0f;
            }
        }



    }

    private void Escape()
    {
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        transform.position -= new Vector3(vectorToPlayer.normalized.x, 0f, 0f) * (speed * Time.deltaTime);
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

}
