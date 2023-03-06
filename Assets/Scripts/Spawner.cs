using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private float m_rotationSpeed = 50f;
    [SerializeField] private List<Enemy_Class> m_enemiesToSpawn;
    [SerializeField] private Transform m_spawnPoint;

    void Start()
    {
        //foreach(GameObject enemy in m_enemiesToSpawn)
        //{
        //    Instantiate(enemy, m_spawnPoint);
        //}

        Enemy_Class enemyToInstantiate = m_enemiesToSpawn[Random.Range(0, m_enemiesToSpawn.Count)];
        Enemy_Class instantiated = Instantiate(enemyToInstantiate, m_spawnPoint);
    }

    void Update()
    {

    }
}
