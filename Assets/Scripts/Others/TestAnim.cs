using UnityEngine;

namespace Others
{
    public class TestAnim : MonoBehaviour
    {
        [SerializeField] private bool isAnimEnabled;
        [SerializeField] private Animator animator;
        
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            PlayTextAnim();
        }

        private void PlayTextAnim()
        {
            animator.SetBool("PlayAnim", isAnimEnabled);
        }
    }
}
