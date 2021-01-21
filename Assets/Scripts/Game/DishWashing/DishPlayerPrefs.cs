using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DishPlayerPrefs : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dishCountText;
    [SerializeField] private int counter;
    [SerializeField] CleanDishRack cleanDishRack;
    [SerializeField] private GameObject cleanDishes;

    // Start is called before the first frame update
    void Start()
    {
        if (cleanDishes != null) cleanDishes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDishCount();
    }

    public void AddCounter()
    {
        counter++;
    }

    public void SetDishCount()
    {
        PlayerPrefs.SetInt("dish", counter);
    }

    public void GetDishCount()
    {
        counter = PlayerPrefs.GetInt("dish");
    }

    public void CurrentDishCount()
    {
		//A: Null check
        dishCountText.text = "Dish: " + counter;
    }
}
