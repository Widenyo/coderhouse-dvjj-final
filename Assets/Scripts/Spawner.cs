using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private float m_rotationSpeed = 50f;
    [SerializeField] private GameObject[] m_enemiesToSpawn;
    [SerializeField] private Transform m_spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject enemy in m_enemiesToSpawn)
        {
            Instantiate(enemy, m_spawnPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
