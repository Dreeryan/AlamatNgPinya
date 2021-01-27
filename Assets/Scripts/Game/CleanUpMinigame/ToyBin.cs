using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToyBin : MonoBehaviour
{
    public UnityEvent onMinigameCompleted = new UnityEvent();

    private bool isHoveredOver;
    private bool isSelected = false;
    public bool IsSelected
    {
        get { return isSelected; }
    }

    [SerializeField] private Counter counter;

    #region temp
    private int curToys;
    private int toyCount;
    #endregion

    private void Start()
    {
        curToys = 0;
        toyCount = GameObject.FindGameObjectsWithTag("Toy").Length;
        if (counter == null) counter = FindObjectOfType<Counter>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isHoveredOver)  isSelected = true;
            else                isSelected = false;
        }
    }

    private void OnMouseOver()
    {
        isHoveredOver = true;
    }

    private void OnMouseExit()
    {
        isHoveredOver = false;
    }

    public void PlaceToy(Toy toy) 
    {
        toy.transform.parent = transform;
        toy.transform.position = transform.position;
        toy.GetComponent<Collider2D>().enabled = false;
        counter.objectsCollected++;
        curToys++;

        if (curToys >= toyCount) MinigameCompleted();
    }

    void MinigameCompleted()
    {
        onMinigameCompleted.Invoke();
    }
}
