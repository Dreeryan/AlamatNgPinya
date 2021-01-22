using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanDishRack : MonoBehaviour
{
    private UnityEvent  onDishCleaned = new UnityEvent();
    public UnityEvent   OnDishCleaned 
    {
        get { return onDishCleaned; }
    }

    private int         dishCounter = 0;
    public int          DishCounter
    {
        get { return dishCounter; }
    }


    [SerializeField] private Dish[] dirtyDishes;
    [SerializeField] private Sprite[] cleanSprites;

    [Header("References")]
    [SerializeField] ProgressManager progressManager;

    private SpriteRenderer sRenderer;

    private void Start()
    {
        if (sRenderer == null) sRenderer = GetComponent<SpriteRenderer>();
        foreach (Dish dish in dirtyDishes)
        {
            dish.OnDishAdded.AddListener(DishCleaned);
        }
    }

    void Update()
    {
		//A: Dont do this per update. Do this everytime the dishcounter was changed
		//Can shorten to spriteRenderer.sprite = cleanSprites[dishCounter]
		//Null check before accessing SpriteRenderer and cleanSprites element
		
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
        progressManager.AddProgress();
        onDishCleaned.Invoke();
    }
}
