using System;
using Managers;
using UnityEngine;

namespace Others
{
    public class Diamond : MonoBehaviour, IDestroy
    {
        public ParticleSystem particle;
        
        public void DestroyItemObject()
        {
            GameManager.Instance.UpdateDiamonds(1);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            particle.gameObject.SetActive(true);
            particle.Play();
        }
    }
}
