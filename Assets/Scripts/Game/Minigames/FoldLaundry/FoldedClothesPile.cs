using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoldedClothesPile : MonoBehaviour
{
    [SerializeField] private UnityEvent onClothingAdded;

    private int         clothesCounter = 0;

    public  UnityEvent  OnClothingAdded => onClothingAdded;
    public  int         ClothesCounter => clothesCounter;

    [SerializeField] private Counter            counter;
    [SerializeField] private GameObject[]       foldedSprites;
    [SerializeField] private ClothesToFold[]    clothesToFold;

    private void Start()
    {
        //if (manager == null) manager = FindObjectOfType<ProgressManager>();
        if (counter == null) counter = FindObjectOfType<Counter>();

        foreach (ClothesToFold clothing in clothesToFold)
        {
            clothing.OnCompleteFold.AddListener(ShowNextFoldedClothing);
        }
    }

    void ShowNextFoldedClothing()
    {
        clothesCounter++;
        foldedSprites[clothesCounter - 1].gameObject.SetActive(true);
        WinCheck.Instance.IncreaseProgress();
        onClothingAdded?.Invoke();
    }
}