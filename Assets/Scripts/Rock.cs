using System;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        var damageableObj = other.gameObject.GetComponent<IDamage>();
        if (damageableObj != null)
        {
            damageableObj.TakeDamage(damage);
        }
    }
}