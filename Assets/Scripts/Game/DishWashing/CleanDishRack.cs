using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDishRack : MonoBehaviour
{
    public int dishCounter = 0;
    [SerializeField] private Dish dish;
    [SerializeField] private Sprite[] cleanSprites;

    [Header("References")]
    [SerializeField] ProgressManager progressManager;
    [SerializeField] DishPlayerPrefs dishPlayerPrefs;

    void Update()
    {
		//A: Dont do this per update. Do this everytime the dishcounter was changed
		//Can shorten to spriteRenderer.sprite = cleanSprites[dishCounter]
		//Null check before accessing SpriteRenderer and cleanSprites element
		
        if (dishCounter == 1)
        {
            GetComponent<SpriteRenderer>().sprite = cleanSprites[0];
        }

        if (dishCounter == 2)
        {
            GetComponent<SpriteRenderer>().sprite = cleanSprites[1];
        }

        if (dishCounter == 3)
        {
            GetComponent<SpriteRenderer>().sprite = cleanSprites[2];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DirtyDish"))
        {
            dish = collision.gameObject.GetComponent<Dish>();
            dishCounter++;
			
			//A: Null check before accessing 
            dish.gameObject.GetComponent<Collider2D>().enabled = false;

            // add progress
            progressManager.AddProgress();
            dishPlayerPrefs.AddCounter();
        }
    }
}
