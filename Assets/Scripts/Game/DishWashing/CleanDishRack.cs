using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanDishRack : MonoBehaviour
{
    public class OnDishAdded : UnityEvent<int> { }
    private OnDishAdded dishAdded = new OnDishAdded();
    public OnDishAdded  DishAdded
    {
        get { return dishAdded; }
    }

    private int         dishCounter = 0;

    [SerializeField] private Dish[]     dirtyDishes;
    [SerializeField] private Sprite[]   cleanSprites;

    [Header("References")]
    //[SerializeField] private ProgressManager    progressManager;
    [SerializeField] private Counter            counter;
    private SpriteRenderer sRenderer;

    private void Start()
    {
        if (sRenderer == null) sRenderer = GetComponent<SpriteRenderer>();
        foreach (Dish dish in dirtyDishes)
        {
            dish.OnDishCleaned.AddListener(DishCleaned);
        }
    }

    private void ChangeSprite()
    {
        if (sRenderer == null ||
            cleanSprites[dishCounter - 1] == null) return;

        GetComponent<SpriteRenderer>().sprite = cleanSprites[dishCounter - 1];
    }

    private void DishCleaned()
    {
        dishCounter++;
        ChangeSprite();
        //progressManager.AddProgress();
        counter.objectsCollected++;
        dishAdded.Invoke(dishCounter);
    }
}
