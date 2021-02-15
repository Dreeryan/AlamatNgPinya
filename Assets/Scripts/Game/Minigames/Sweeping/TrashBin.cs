using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashBin : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrashAdded;

    [SerializeField] private Counter counter;
    // Start is called before the first frame update
    void Start()
    {
        if (counter == null) counter = FindObjectOfType<Counter>();
    }

    public void ThrowTrash(GameObject trash)
    {
        trash.transform.parent = transform;
        transform.transform.position = transform.position;

        trash.SetActive(false);

        onTrashAdded?.Invoke();

        if (counter != null) counter.IncreaseProgress();
    }
}
