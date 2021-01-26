using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDishRack : MonoBehaviour
{
    [SerializeField] private CleanDishRack  rack;
    [SerializeField] private Sprite[]       dirtySprites;
    [SerializeField] private Dish[]         dirtyDishes;

    private SpriteRenderer sRenderer;

    // Update is called once per frame

    private void Start()
    {
        if (sRenderer == null) sRenderer = GetComponent<SpriteRenderer>();
        if (rack == null) rack = FindObjectOfType<CleanDishRack>();
        if (rack != null) rack.DishAdded.AddListener(OnDishCleaned);

        for (int x = 0; x < dirtyDishes.Length; x++)
        {
            dirtyDishes[x].DisableDish();
        }
    }

    private void OnDishCleaned(int count)
    {
        int dishCount = count - 1;

        if (dishCount < dirtyDishes.Length && dirtyDishes[dishCount] != null)
        { 
            if (sRenderer != null) sRenderer.sprite = dirtySprites[dishCount];
            dirtyDishes[dishCount].EnableDish();
        }
    }
}
