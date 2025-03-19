using System.Collections;
using Managers;
using UnityEngine;

namespace Others
{
    public class Item4 : MonoBehaviour
    {
        public ParticleSystem particleExplosion;
        public GameObject item4Mesh;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                ShowParticleExplosion();
                SoundManager.Instance.PlaySoundCylinder();
                Destroy(other.transform.parent.gameObject);
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
