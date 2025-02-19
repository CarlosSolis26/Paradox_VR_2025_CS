using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Others
{
    public class Diamond : MonoBehaviour, IDestroy
    {
        public GameObject diamondMesh;
        public ParticleSystem particle;
        
        public void DestroyItemObject()
        {
            GameManager.Instance.UpdateDiamonds(1);
            //Destroy(gameObject);
            diamondMesh.SetActive(false);
            particle.Play();
            UIManager.Instance.ShowTxtDiamonds();
            StartCoroutine(IenDiamond());
        }

        //private void OnDestroy()
        //{
            //particle.gameObject.SetActive(true);
            //particle.Play();
        //}

        private IEnumerator IenDiamond()
        {
            yield return new WaitForSeconds(6);
            particle.Stop();
            UIManager.Instance.HideTxtDiamonds();
            Destroy(gameObject);
        }
    }
}
