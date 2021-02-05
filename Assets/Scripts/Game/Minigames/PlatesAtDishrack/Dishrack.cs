using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dishrack : MonoBehaviour
{
    [SerializeField] Counter manager;

    private bool    isOccupied = false;
    public bool     IsOccupied
    {
        get { return isOccupied; }
    }
    private bool    isOverlapped = false;

    private void Start()
    {
        if (manager == null) manager = FindObjectOfType<Counter>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!IsOccupied && isOverlapped)
            {
                isOccupied = true;
                OnSlotFilled();
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isOccupied) return;
        if (collision.gameObject.GetComponent<CleanDish>())
        {
            isOverlapped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOccupied) return;
        else isOverlapped = false;
    }

    void OnSlotFilled()
    {
        manager.objectsCollected++;
    }
}