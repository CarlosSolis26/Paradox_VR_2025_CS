using UnityEngine;

public class TestCube : MonoBehaviour
{
    public GameObject cube1;
    
    void Start()
    {
        //DestroyCube();
        Invoke("EnableCube", 3f);
        //EnableCube();
    }

    public void DestroyCube()
    {
        Destroy(gameObject, 3f);
    }

    public void EnableCube()
    {
        //gameObject.SetActive(true);
        cube1.SetActive(true);
    }
}
