using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class Savekeys
{
    public static string remainingHealthKey = "Remaining Health";
    public static string positionKey = "Current Position";
}

public class PlayerController : Player_Class
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int m_maxHealth;
    public int m_currentHealth;
    private bool canJump;
    private GameObject stageCamera;

    void SaveData()
    {
        Vector3 l_position = transform.position;
        PlayerPrefs.SetInt(Savekeys.remainingHealthKey, m_currentHealth);
        PlayerPrefs.SetFloat(Savekeys.positionKey, l_position.x);
    }

    void LoadData()
    {
        m_currentHealth = PlayerPrefs.GetInt(Savekeys.remainingHealthKey, m_maxHealth);
        float l_x = PlayerPrefs.GetFloat(Savekeys.positionKey, 0);
        transform.position = new Vector3(l_x, transform.position.y);
    }

    private void Awake()
    {
        stageCamera = GameObject.Find("Stage Camera");
        m_currentHealth = m_maxHealth;
        UIManager.UpdateHP(m_currentHealth, m_maxHealth);
    }

    void Update()
    {
        Schhmovin();
        checkFall();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadData();
        }
    }

    [ContextMenu ("Receive Damage")] public void TakeDamage()
    {
        m_currentHealth -= 1;
        UIManager.UpdateHP(m_currentHealth, m_maxHealth);
        GameManager.instance.DecreaseStyle(5f);
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
        rb.MovePosition(transform.position + movement);

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
            Debug.Log("Player died, resetting style in UI");
            GameManager.instance.ResetStyle();
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
