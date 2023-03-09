using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using System;

public class UIAmmoController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        UIManager.OnAmmoChange += UpdateUI;
    }

    private void UpdateUI(int currentAmmo, int maxAmmo)
    {
        TextMeshProUGUI textReference = gameObject.GetComponent<TextMeshProUGUI>();
        textReference.text = currentAmmo.ToString() + '/' + maxAmmo.ToString();
        Debug.Log("UI ammo updated");
    }
}
