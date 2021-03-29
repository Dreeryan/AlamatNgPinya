using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dishrack : MonoBehaviour
{
    [SerializeField] private UnityEvent onPlatePlaced;

    [SerializeField] Counter counter;

    private bool    isOccupied = false;
    public bool     IsOccupied => isOccupied;

    private void Start()
    {
        if (counter == null) counter = FindObjectOfType<Counter>();
    }

    public void PlacePlate(CleanDish dish)
    {
        dish.transform.parent = transform;
        dish.transform.position = transform.position;

        if (isOccupied) return;

        isOccupied = true;
        OnSlotFilled();

        onPlatePlaced?.Invoke();
    }

    void OnSlotFilled()
    {
        WinCheck.Instance.IncreaseProgress();
    }
}