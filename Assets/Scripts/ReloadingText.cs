using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingText : MonoBehaviour
{
    private GameObject playerInstance;
    [SerializeField] private float m_blinkSpeed;
    private float timeToBlink = 0f;
    // Start is called before the first frame update
    void Start()
    {
        playerInstance = GameObject.Find("Player_main");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = playerInstance.transform.position;
        transform.position = new Vector3(playerPosition.x, playerPosition.y*2 + 5f, playerPosition.z);
        timeToBlink += Time.deltaTime;
        if(timeToBlink > m_blinkSpeed)
        {
            timeToBlink = 0f;
            Blink();
        }
    }

    void Blink()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.enabled = !renderer.enabled;
    }

}


 