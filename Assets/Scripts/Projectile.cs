using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 25;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Asegúrate de que el proyectil se mueve hacia adelante al ser instanciado
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el proyectil impacta un enemigo o alguna otra cosa
        if (other.CompareTag("Enemy"))
        {
            // Suponiendo que el enemigo tenga un script que maneje daño
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject); // Destruye el proyectil al impactar
        }
    }
}
