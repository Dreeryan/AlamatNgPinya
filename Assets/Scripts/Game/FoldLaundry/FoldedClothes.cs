using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoldedClothes : MonoBehaviour
{
    private UnityEvent  onClothingAdded = new UnityEvent();
    public UnityEvent   OnClothingAdded
    {
        get { return onClothingAdded; }
    }

    private int         clothesCounter = 0;
    public int          ClothesCounter
    {
        get { return clothesCounter; }
    }

    [SerializeField] private ProgressManager    manager;
    [SerializeField] private GameObject[]       foldedSprites;
    [SerializeField] private Clothing[]         clothesToFold;

    private void Start()
    {
        if (manager == null) manager = FindObjectOfType<ProgressManager>();

        foreach (Clothing clothing in clothesToFold)
        {
            clothing.OnClothingFolded.AddListener(ShowNextFoldedClothing);
        }
    }

    void ShowNextFoldedClothing()
    {
        clothesCounter++;
        foldedSprites[clothesCounter - 1].gameObject.SetActive(true);
        manager.AddProgress();
        OnClothingAdded.Invoke();
    }
}