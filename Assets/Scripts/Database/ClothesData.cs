using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClothesData : BaseData
{
    [SerializeField] public Directions[] clothesFoldingDirection;
    [SerializeField] public Sprite[] foldedClothesSprite;
    public Directions[] GetFoldDirections()
    {
        return clothesFoldingDirection;
    }

    public Sprite[] GetFoldedClothesSprite()
    {
        return foldedClothesSprite;
    }
}

