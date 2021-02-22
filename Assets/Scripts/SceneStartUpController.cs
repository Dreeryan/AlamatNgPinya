using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneStartUpController : MonoBehaviour
{
    [SerializeField] private UnityEvent onStart;

    private void Start()
    {
        onStart?.Invoke();
    }

    public void MinigameStartup()
    {
        SceneLoader.Instance.LoadScene("MinigameConfirmation", true);
    }

    public void ResetMotivation()
    {
        MotivationManager.Instance.ResetMotivation();
    }
}
