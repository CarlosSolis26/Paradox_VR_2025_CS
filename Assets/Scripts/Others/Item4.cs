using System.Collections;
using Managers;
using UnityEngine;

namespace Others
{
    public class Item4 : MonoBehaviour
    {
        public ParticleSystem particleExplosion;
        public GameObject item4Mesh;
        public string wall;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(wall))
            {
                GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(wall);
                foreach (GameObject obj in objectsToDestroy)
                {
                    Destroy(obj);
                }
                ShowParticleExplosion();
                SoundManager.Instance.PlaySoundCylinder();
                Destroy(other.gameObject);
                item4Mesh.SetActive(false);
                StartCoroutine(IenItem4());
            }
        }
        
        IEnumerator IenItem4()
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }

        private void ShowParticleExplosion()
        {
            Instantiate(particleExplosion, transform.position, Quaternion.identity);
            particleExplosion.Play();
        }
    }
}
