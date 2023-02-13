using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubBG : MonoBehaviour
{
    [SerializeField] private float m_scrollingSpeed;
    [SerializeField] private float m_resetTime;
    private float m_timeElapsed;
    private Vector3 m_startPosition;
    // Start is called before the first frame update
    void Start()
    {
        m_startPosition = transform.position;
        m_timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_timeElapsed > m_resetTime)
        {
            transform.position = m_startPosition;
            m_timeElapsed = 0f;
            return;
        }
        m_timeElapsed += Time.deltaTime;
        transform.position += new Vector3(1f, 0f, -1f) * m_scrollingSpeed * Time.deltaTime;
    }
}
