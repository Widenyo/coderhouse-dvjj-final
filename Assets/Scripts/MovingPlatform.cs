using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> m_waypoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float distanceThreshold;
    [SerializeField] private float pauseBetweenTransitions = 1f;
    private int currentWaypoint;
    private float timeElapsed;
    private bool arrived = false;
    // Start is called before the first frame update
    private void Awake()
    {
        currentWaypoint = 0;
        timeElapsed = 0;
        arrived = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FloatIfTimePassed();
    }

    private void FloatIfTimePassed()
    {

        if (!arrived)
        {
            FloatInWaypointDirection();
            return;
        }
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= pauseBetweenTransitions)
        {
            timeElapsed = 0;
            arrived = false;
        }
    }

    private void FloatInWaypointDirection()
    {
        Transform l_currentWaypoint = m_waypoints[currentWaypoint];
        Vector3 difference = l_currentWaypoint.position - transform.position;
        Vector3 direction = difference.normalized;
        Move(direction);
        float distanceToNextWaypoint = difference.magnitude;
        if (distanceToNextWaypoint <= distanceThreshold)
        {
            NextWaypoint();
        }
    }

    private void NextWaypoint()
    {
        arrived = true;
        currentWaypoint++;
        if(currentWaypoint >= m_waypoints.Count)
        {
            currentWaypoint = 0;
        }
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }

}
