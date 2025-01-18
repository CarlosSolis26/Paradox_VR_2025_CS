using UnityEngine;

namespace Scripts_2
{
    public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        // Helper function to initialize the singleton instance
    
        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T; // Assign the instance in Awake
                DontDestroyOnLoad(gameObject); // Persist across scenes
            }
            else
            {
                Destroy(gameObject); // Prevent duplicates
            }
        }

        public static T GetInstance()
        {
            if (Instance == null)
            {
                Instance = InitializeInstance(); // Initialize the instance if it doesn't exist
            }
            return Instance;
        }

        // Late initialization for the Instance property
        private static T InitializeInstance()
        {
            T instance = FindFirstObjectByType<T>(); // Try to find an existing instance
            if (instance == null)
            {
                // Create a new instance if none exists
                var singletonObject = new GameObject(typeof(T).Name);
                instance = singletonObject.AddComponent<T>();
            }
            return instance;
        }
    }
}