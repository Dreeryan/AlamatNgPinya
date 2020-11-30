using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyDishRack : MonoBehaviour
{
    [SerializeField] private Sprite[] dirtySprites;
    [SerializeField] private CleanDishRack rack;
    [SerializeField] private GameObject[] dirtyDishes;

    // Update is called once per frame
    void Update()
    {
        if (rack.dishCounter == 1)
        {
            GetComponent<SpriteRenderer>().sprite = dirtySprites[0];
            dirtyDishes[0].gameObject.SetActive(true);
        }
    }
}
