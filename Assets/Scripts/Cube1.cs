using UnityEngine;

public class Cube1 : MonoBehaviour, IDamage
{
    public float health;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}