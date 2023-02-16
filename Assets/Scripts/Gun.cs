using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private int m_clipSize = 8;
    [SerializeField] private float m_reloadTime = 2f;
    [SerializeField] private GameObject m_reloadingText;
    private int clip;
    private bool reloading;
    private float reloadTimeElapsed = 0f;
    private GameObject reloadingTextInstace;

    void Start()
    {
        reloadTimeElapsed = 0f;
        clip = m_clipSize;
        reloading = false;
    }

    void Update()
    {
        if (reloading)
        {
            reloadTimeElapsed += Time.deltaTime;
            if(reloadTimeElapsed > m_reloadTime)
            {
                reloading = false;
                Destroy(reloadingTextInstace);
                clip = m_clipSize;
                reloadTimeElapsed = 0f;
            }
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Transform gunPoint = transform.Find("GunPoint").transform;
            Instantiate(m_bulletPrefab, gunPoint.position, gunPoint.rotation);
            clip--;
            if(clip == 0)
            {
                reloading = true;
                reloadingTextInstace = Instantiate(m_reloadingText);
            }
        }
    }
}
