using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mom : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEating;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Spoon>())
        {
            Spoon spoon = collision.GetComponent<Spoon>();
            if (spoon.IsSpoonFull)
            {
                spoon.EmptySpoon();
            }
            WinCheck.Instance.IncreaseProgress();

            OnEating?.Invoke();
        }
    }
}
