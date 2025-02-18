using System;
using UnityEngine;

namespace Others
{
    public class DiamondParticles : MonoBehaviour
    {
        [SerializeField] private float timeToDestroy;
        
        private void OnEnable()
        {
            Invoke("DestroyDiamondParticles", timeToDestroy);
        }

        private void DestroyDiamondParticles()
        {
            Destroy(gameObject);
        }
    }
}
