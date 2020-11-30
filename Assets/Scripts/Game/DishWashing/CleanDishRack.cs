using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDishRack : MonoBehaviour
{
    public int dishCounter = 0;
    [SerializeField] private Dish dish;
    [SerializeField] private Sprite[] cleanSprites;

    void Update()
    {
        if (dishCounter == 1)
        {
            GetComponent<SpriteRenderer>().sprite = cleanSprites[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DirtyDish"))
        {
            dish = collision.gameObject.GetComponent<Dish>();
            dishCounter++;
            dish.gameObject.GetComponent<Collider2D>().enabled = false;
        }

    }
}
