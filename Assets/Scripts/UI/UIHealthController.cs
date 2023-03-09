using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using System;

public class UIHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        UIManager.OnHealthChange += UpdateUI;
    }

    private void UpdateUI(int current, int max)
    {
        TextMeshProUGUI textReference = gameObject.GetComponent<TextMeshProUGUI>();
        textReference.text = current.ToString() + '/' + max.ToString();
        Debug.Log("UI health updated");
    }
}
