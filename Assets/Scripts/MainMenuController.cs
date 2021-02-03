using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private UnityEvent onStart;

    private void Start()
    {
        onStart?.Invoke();
    }


}
