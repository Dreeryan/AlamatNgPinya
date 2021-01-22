using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDishRack : MonoBehaviour
{
    [SerializeField] private CleanDishRack rack;
    [SerializeField] private Sprite[] dirtySprites;
    [SerializeField] private GameObject[] dirtyDishes;

    private SpriteRenderer sRenderer;

    // Update is called once per frame

    //A: Dont do this per update. Do this everytime the dishcounter was changed
    //Can shorten to spriteRenderer.sprite = dirtySprites[dishCounter]
    //Null check before accessing SpriteRenderer and dirtySprites element

    private void Start()
    {
        if (sRenderer == null) sRenderer = GetComponent<SpriteRenderer>();
        if (rack == null) rack = FindObjectOfType<CleanDishRack>();
        if (rack != null) rack.OnDishCleaned.AddListener(OnDishCleaned);
    }

    private void OnDishCleaned()
    {
        if (sRenderer == null || rack == null) return;

        int dishCount = rack.DishCounter - 1;

        if (dishCount < dirtyDishes.Length && dirtyDishes[dishCount] != null)
        { 
            sRenderer.sprite = dirtySprites[dishCount];
            dirtyDishes[dishCount].SetActive(true);
        }
    }
}
