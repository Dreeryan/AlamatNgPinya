using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool isShuttingDown = false;

    public static bool IsShuttingDown => isShuttingDown;

    private static T instance;

    public static T Instance
    {
        get
        {
            if (IsShuttingDown)
            {
                Debug.LogError("Game already shutting down! Returning null");
                return null;
            }

            if (instance == null)
                instance = (T)FindObjectOfType(typeof(T));

            if(instance == null)
            {
                Debug.LogErrorFormat("{0} cannot be found", typeof(T));
                return null;
            }

            return instance;
        }
    }

    protected virtual void OnApplicationQuit()
    {
        isShuttingDown = true;
    }

    protected virtual void OnDestroy()
    {
        isShuttingDown = true;
    }

    protected virtual void Start()
    {
        isShuttingDown = false;
        DontDestroyOnLoad(this.gameObject);
    }

    protected virtual void OnEnable()
    {
        isShuttingDown = false;
    }
}
