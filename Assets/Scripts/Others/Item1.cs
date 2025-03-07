using System.Collections;
using Managers;
using UnityEngine;

namespace Others
{
    public class Item1 : MonoBehaviour, IDestroy
    {
        public GameObject item1Mesh;
        [SerializeField] private GameObject wall;
        public ParticleSystem particle;
        public GameObject info4;

        public void DestroyItemObject()
        {
            item1Mesh.SetActive(false);
            info4.SetActive(false);
            Destroy(wall);
            SoundManager.Instance.PlaySoundSphere();
            particle.Play();
            UIManager.Instance.ShowTxtItems("Has destruido un muro");
            StartCoroutine(IenItem1());
        }

        IEnumerator IenItem1()
        {
            yield return new WaitForSeconds(5f);
            particle.Stop();
            UIManager.Instance.HideTxtItems();
            Destroy(gameObject);
        }
    }
}
