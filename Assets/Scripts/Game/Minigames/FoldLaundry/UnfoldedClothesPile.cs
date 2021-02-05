using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnfoldedClothesPile : MonoBehaviour
{
    [SerializeField] private FoldedClothesPile  foldedClothesPile;
    [SerializeField] private GameObject[]       unfoldedSprites;
    [SerializeField] private Clothing[]         clothesToFold;

    private void Start()
    {
        foldedClothesPile.OnClothingAdded.AddListener(ShowNextClothing);
        for (int x = 1; x < clothesToFold.Length; x++)
        {
            clothesToFold[x].GetComponent<SpriteRenderer>().enabled = false;
        }
        clothesToFold[0].EnableClothing();
    }

    void ShowNextClothing()
    {
        if (foldedClothesPile == null) return;

        int currentCounter = foldedClothesPile.ClothesCounter;

        if (currentCounter - 1 < unfoldedSprites.Length &&
            unfoldedSprites[currentCounter - 1] != null)
        {
            unfoldedSprites[currentCounter - 1].SetActive(false);
        }

        if (currentCounter < clothesToFold.Length &&
            clothesToFold[currentCounter] != null)
        {
            //clothesToFold[currentCounter].SetActive(true);
            clothesToFold[currentCounter].EnableClothing();
        }
    }
}
