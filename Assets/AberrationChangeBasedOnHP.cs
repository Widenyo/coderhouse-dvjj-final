using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AberrationChangeBasedOnHP : MonoBehaviour
{
    [SerializeField] private Volume m_volume;
    // Start is called before the first frame update
    void Awake()
    {
        UIManager.OnHealthChange += ChangeAberrationIntensity;
    }

    private void ChangeAberrationIntensity(int hp, int maxHP)
    {
        if(hp > 0)
        {
            //Forma de sacar la intensidad provisoria
            float newIntensity = (float)Math.Log(maxHP / hp);
            FloatParameter intensityParam = new FloatParameter(newIntensity);
            if (m_volume.profile.TryGet(out ChromaticAberration aberration))
            {
                aberration.intensity.Override(intensityParam.value);
            }
        }
    }

}
