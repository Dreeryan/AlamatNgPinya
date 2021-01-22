using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DishCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text Counter;

    // Start is called before the first frame update
    void Start()
    {
        CleanDishRack rack = FindObjectOfType<CleanDishRack>();
        if (rack != null) rack.DishAdded.AddListener(OnDishCountUpdated);
    }

    void OnDishCountUpdated(int count) 
    {
        if(Counter != null) Counter.text = count.ToString();
    }
}
