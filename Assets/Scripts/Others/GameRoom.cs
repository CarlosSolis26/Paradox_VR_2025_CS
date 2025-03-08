using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Others
{
    public class GameRoom : MonoBehaviour
    {
        public GameObject infoGameRoom;
        public GameObject infoContinue;
        private bool enter;
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (enter) return;
            infoGameRoom.SetActive(false);
            infoContinue.SetActive(true);
            enter = true;
        }
    }
}
