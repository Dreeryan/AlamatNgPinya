using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrashAdded;

    public void ThrowTrash(GameObject trash)
    {
        trash.transform.parent = transform;
        transform.transform.position = transform.position;

        trash.SetActive(false);

        onTrashAdded?.Invoke();

        WinCheck.Instance.IncreaseProgress();
    }
}
