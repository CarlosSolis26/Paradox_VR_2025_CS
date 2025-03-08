using UnityEngine;

namespace Others
{
    public class Info : MonoBehaviour
    {
        public GameObject activateInfo;
        
        public void DestroyInfo(GameObject info)
        {
            Destroy(info);
        }

        public void DestroyInfoAndActivateInfo(GameObject info)
        {
            Destroy(info);
            activateInfo.SetActive(true);
        }
    }
}
