using Managers;
using UnityEngine;

namespace Scripts_2
{
    public class ObjectSoundPlayer : MonoBehaviour
    {
        private void OnMouseDown()
        {
            if (gameObject.name == "Object1")
                SoundManager.Instance.PlayObjectSound1();
            else if (gameObject.name == "Object2")
                SoundManager.Instance.PlayObjectSound2();
            else if (gameObject.name == "Object3")
                SoundManager.Instance.PlayObjectSound3();
        }
    }
}