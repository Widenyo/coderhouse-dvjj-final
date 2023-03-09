using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public static event Action<int, int> OnHealthChange;
    public static event Action<int, int> OnAmmoChange;
    public static event Action<string> OnStyleChange;
    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    public static void UpdateAmmo(int ammo, int maxAmmo)
    {
        OnAmmoChange?.Invoke(ammo, maxAmmo);
    }

    public static void UpdateHP(int hp, int maxHP)
    {
        OnHealthChange?.Invoke(hp, maxHP);
    }

    public static void UpdateStyle(string rank)
    {
        OnStyleChange?.Invoke(rank);
    }

}
