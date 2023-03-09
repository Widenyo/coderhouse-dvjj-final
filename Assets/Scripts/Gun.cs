using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private int m_clipSize = 8;
    [SerializeField] private float m_reloadTime = 2f;
    [SerializeField] private GameObject m_reloadingText;
    [SerializeField] private Transform m_gunPoint;
    private int clip;
    private bool reloading;
    private float reloadTimeElapsed = 0f;
    private GameObject reloadingTextInstace;
    private GameObject stageCamera;

    void Start()
    {
        stageCamera = GameObject.Find("Stage Camera");
        reloadTimeElapsed = 0f;
        clip = m_clipSize;
        reloading = false;
        updateAmmoUI();
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
                updateAmmoUI();
            }
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(m_bulletPrefab, m_gunPoint.position, m_gunPoint.rotation);
            clip--;
            if(clip == 0)
            {
                reloading = true;
                reloadingTextInstace = Instantiate(m_reloadingText);
            }
            updateAmmoUI();
        }
    }

    private void updateAmmoUI()
    {
        Debug.Log("Gun updating ammo");
        UIManager.UpdateAmmo(clip, m_clipSize);
    }

}
