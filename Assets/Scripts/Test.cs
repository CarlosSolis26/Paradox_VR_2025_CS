using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject wall;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisi�n detectada con: " + collision.gameObject.name);
        Destroy(collision.gameObject);
        Destroy(wall);
    }
}
