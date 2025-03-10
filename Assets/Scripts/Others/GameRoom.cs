using UnityEngine;

namespace Others
{
    public class GameRoom : MonoBehaviour
    {
        public GameObject infoGameRoom;
        public GameObject infoContinue;
        public GameObject item2;
        private bool enter;
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (enter) return;
            infoGameRoom.SetActive(false);
            infoContinue.SetActive(true);
            item2.SetActive(true);
            enter = true;
        }
    }
}
