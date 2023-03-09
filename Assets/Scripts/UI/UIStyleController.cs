using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStyleController : MonoBehaviour
{
    void Awake()
    {
        UIManager.OnStyleChange += UpdateUI;
    }
    private void UpdateUI(string rank)
    {
        TextMeshProUGUI textReference = gameObject.GetComponent<TextMeshProUGUI>();
        textReference.text = rank;
        Debug.Log("UI style updated");
    }

}
