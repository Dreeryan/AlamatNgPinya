using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesBasket : MonoBehaviour
{
    [SerializeField] private List<ClothesToHang> Clothes;

    private int curClothing;
    // Start is called before the first frame update
    void Start()
    {
        curClothing = 0;
        // start at the second piece of clothing
        for (int x = 1; x < Clothes.Count; x++)
        {
            Clothes[x].DisableClothing();
        }
    }

    public void EnableNextClothing()
    {
        curClothing++;
        if (curClothing >= Clothes.Count) return;

        Clothes[curClothing].EnableClothing();
    }
}
