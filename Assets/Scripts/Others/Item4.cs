using System;
using UnityEngine;

namespace Others
{
    public class Item4 : MonoBehaviour, IDestroy
    {
        [SerializeField] private GameObject wall;

        private void Start()
        {
            wall = GameObject.Find("PolyShape (20)");
        }

        public void DestroyItemObject()
        {
            Destroy(gameObject);
            Destroy(wall);
        }
    }
}
