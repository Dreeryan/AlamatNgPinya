using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldedClothes : MonoBehaviour
{
    public int clothesCounter = 0;
    [SerializeField] private Laundry laundry;
    [SerializeField] private GameObject[] foldedSprites;

    void Update()
    {
		//A: Simplify. See DriedClothes.cs
		//Do this after clothesCounter was changed instead
        if (clothesCounter == 1)
        {
            foldedSprites[0].gameObject.SetActive(true);
        }

        if (clothesCounter == 2)
        {
            foldedSprites[1].gameObject.SetActive(true);
        }

        if (clothesCounter == 3)
        {
            foldedSprites[2].gameObject.SetActive(true);
        }

        if (clothesCounter == 4)
        {
            foldedSprites[3].gameObject.SetActive(true);
        }

        if (clothesCounter == 5)
        {
            foldedSprites[4].gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Clothes"))
        {
            laundry = collision.gameObject.GetComponent<Laundry>();
            clothesCounter++;
            laundry.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}