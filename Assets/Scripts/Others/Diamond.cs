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
        
        public void DestroyItemObject()
        {
            GameManager.Instance.UpdateDiamonds(1);
            //Destroy(gameObject);
            diamondMesh.SetActive(false);
            SoundManager.Instance.PlaySoundDiamond();
            particlePickupDiamond.Play();
            particle.Play();
            UIManager.Instance.ShowTxtItems("Has ganado un diamante");
            StartCoroutine(IenDiamond());
        }

        //private void OnDestroy()
        //{
            //particle.gameObject.SetActive(true);
            //particle.Play();
        //}

        private IEnumerator IenDiamond()
        {
            yield return new WaitForSeconds(5f);
            particle.Stop();
            UIManager.Instance.HideTxtItems();
            Destroy(gameObject);
        }
    }
}
