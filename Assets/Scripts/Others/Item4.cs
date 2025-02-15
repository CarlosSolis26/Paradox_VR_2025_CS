using Enemy_NS;
using Managers;
using UnityEngine;

namespace Others
{
    public class Item4 : MonoBehaviour, IDestroy
    {
        //private Enemy enemy;
        
        [SerializeField] private GameObject wall;
        //[SerializeField] private GameObject info6;

        private void Start()
        {
            wall = GameObject.Find("PolyShape (20)");
            //info6 = GameObject.Find("info6");
        }

        public void DestroyItemObject()
        {
            Destroy(gameObject);
            Destroy(wall);
            //info6.SetActive(false);
        }
    }
}
