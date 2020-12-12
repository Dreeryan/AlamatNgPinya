using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriedClothes : MonoBehaviour
{
    [SerializeField] private GameObject[] dirtySprites;
    [SerializeField] private FoldedClothes foldedClothes;
    [SerializeField] private GameObject[] toFoldClothes;

    // Update is called once per frame
    void Update()
    {
        if (foldedClothes.clothesCounter == 1)
        {
            dirtySprites[0].gameObject.SetActive(false);
            toFoldClothes[0].gameObject.SetActive(true);
        }

        if (foldedClothes.clothesCounter == 2)
        {
            dirtySprites[1].gameObject.SetActive(false);
            toFoldClothes[1].gameObject.SetActive(true);
        }

        if (foldedClothes.clothesCounter == 3)
        {
            dirtySprites[2].gameObject.SetActive(false);
            toFoldClothes[2].gameObject.SetActive(true);
        }

        if (foldedClothes.clothesCounter == 4)
        {
            dirtySprites[3].gameObject.SetActive(false);
            toFoldClothes[3].gameObject.SetActive(true);
        }
    }
}
