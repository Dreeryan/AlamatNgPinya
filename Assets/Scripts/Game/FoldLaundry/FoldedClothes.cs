using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoldedClothes : MonoBehaviour
{
    public int clothesCounter = 0;
    [SerializeField] private Laundry laundry;
    [SerializeField] private Sprite[] foldedSprites;

    void Update()
    {
        if (clothesCounter == 1)
        {
            GetComponent<SpriteRenderer>().sprite = foldedSprites[0];
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
