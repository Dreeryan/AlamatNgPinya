using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriedClothes : MonoBehaviour
{
    [SerializeField] private Sprite[] dirtySprites;
    [SerializeField] private FoldedClothes foldedClothes;
    [SerializeField] private GameObject[] toFoldClothes;

    // Update is called once per frame
    void Update()
    {
        if (foldedClothes.clothesCounter == 1)
        {
            GetComponent<SpriteRenderer>().sprite = dirtySprites[0];
            toFoldClothes[0].gameObject.SetActive(true);
        }
    }
}
