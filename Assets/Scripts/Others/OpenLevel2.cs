using System.Collections;
using Managers;
using UnityEngine;

namespace Others
{
    public class OpenLevel2 : MonoBehaviour
    {
        public ParticleSystem particleNextLevel;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                particleNextLevel.Play();
                StartCoroutine(IenLevel2());
                //GameManager.Instance.Level2();
            }
        }

        IEnumerator IenLevel2()
        {
            yield return new WaitForSeconds(2f);
            SoundManager.Instance.PlaySoundWin();
            //particleNextLevel.Stop();
            GameManager.Instance.Level2();
        }
    }
}
