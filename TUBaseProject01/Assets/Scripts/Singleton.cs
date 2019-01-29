using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static object objectLock = new object();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if(applicationIsQuitting)
            {
                return null;
            }

            lock (objectLock)
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if(FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        return instance;
                    }

                    if(instance == null)
                    {
                        GameObject singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton) " + typeof(T).ToString();
                    }
                }

                return instance;
            }
        }
    }

    private void Awake()
    {
        applicationIsQuitting = false;
    }

    private void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
