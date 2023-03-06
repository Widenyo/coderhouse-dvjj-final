using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int life;
    [SerializeField] private int speed;
    [SerializeField] private int damage;
    [SerializeField] private int rayDistance;
    [SerializeField] private int shootCd;
    [SerializeField] private int timeToHeal;

    public int getLife { get { return life; } }
    public int getSpeed { get { return speed; } }
    public int getDamage { get { return damage; } }
    public int getRayDistance { get { return rayDistance; } }
    public int getShootCd { get { return shootCd; } }

    public int getTimeToHeal { get { return timeToHeal; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
