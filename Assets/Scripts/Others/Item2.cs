using System.Collections;
using Managers;
using UnityEngine;

namespace Others
{
    public class Item2 : MonoBehaviour, IDestroy
    {
        public GameObject item2Mesh;
        [SerializeField] private GameObject wall;
        public ParticleSystem particle;

        public void DestroyItemObject()
        {
            item2Mesh.SetActive(false);
            Destroy(wall);
            SoundManager.Instance.PlaySoundSphere();
            particle.Play();
            UIManager.Instance.ShowTxtItems("Has destruido un muro");
            StartCoroutine(IenItem2());
        }
        
        IEnumerator IenItem2()
        {
            yield return new WaitForSeconds(5f);
            particle.Stop();
            UIManager.Instance.HideTxtItems();
            Destroy(gameObject);
        }
    }
}
