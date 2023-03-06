using UnityEngine;



[CreateAssetMenu(fileName = "New Bullet Data", menuName = "Bullet Data")]
public class BulletData : ScriptableObject
{
    [SerializeField] private int speed;
    [SerializeField] private int damage;
    [SerializeField] private int duration;
    public int getSpeed { get { return speed; } }
    public int getDamage { get { return damage; } }

    public int getDuration { get { return duration;} }
}
