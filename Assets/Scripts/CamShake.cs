using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    private Vector3 shake;
    private float timer;

    void Start()
    {
        timer = Time.deltaTime+0.4f;
    }

    void Update()
    {
        if (timer <= Time.deltaTime)
        {
            shake = new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));
            this.transform.position += shake;

            timer = Time.deltaTime + 0.4f;
        }
    }
}
