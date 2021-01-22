using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnfoldedClothesPile : MonoBehaviour
{
    [SerializeField] private FoldedClothes  foldedClothesPile;
    [SerializeField] private GameObject[]   unfoldedSprites;
    [SerializeField] private GameObject[]   clothesToFold;

    private void Start()
    {
        foldedClothesPile.OnClothingAdded.AddListener(ShowNextClothing);
    }

    void ShowNextClothing()
    {
        if (foldedClothesPile == null) return;

        int currentCounter = foldedClothesPile.ClothesCounter - 1;

        if (currentCounter < unfoldedSprites.Length
            && unfoldedSprites[currentCounter] != null)
        {
            unfoldedSprites[currentCounter].SetActive(false);
        }

        if (currentCounter < clothesToFold.Length
            && clothesToFold[currentCounter] != null)
        {
            clothesToFold[currentCounter].SetActive(true);
        }
    }
}
