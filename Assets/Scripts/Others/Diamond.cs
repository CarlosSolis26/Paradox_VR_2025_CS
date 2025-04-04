using System.Collections;
using Managers;
using UnityEngine;

namespace Others
{
    public class Diamond : MonoBehaviour, IDestroy
    {
        public GameObject diamondMesh;
        public ParticleSystem particle;
        public ParticleSystem particlePickupDiamond;
        public GameObject item1;
        
        public void DestroyItemObject()
        {
            GameManager.Instance.UpdateDiamonds(1);
            diamondMesh.SetActive(false);
            SoundManager.Instance.PlaySoundDiamond();
            particlePickupDiamond.Play();
            particle.Play();
            UIManager.Instance.ShowTxtItems("Has ganado un diamante");
            StartCoroutine(IenDiamond());
        }

        private IEnumerator IenDiamond()
        {
            yield return new WaitForSeconds(5f);
            particle.Stop();
            UIManager.Instance.HideTxtItems();
            item1.SetActive(true);
            Destroy(gameObject);
        }
    }
}
