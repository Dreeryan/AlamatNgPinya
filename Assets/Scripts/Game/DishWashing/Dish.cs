using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Dish : MonoBehaviour
{
    private UnityEvent  onDishAdded = new UnityEvent();
    public UnityEvent   OnDishAdded
    {
        get { return onDishAdded; }
    }

    [Header("Dish Settings")]
    [SerializeField] private float              maxDirtRate = 100f;
    [SerializeField] private float              minDirtRate = 0f;
    [SerializeField] private Transform          cleanDishRack;
    private float currentDirtRate = 0f;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI    dirtRateText;

    // Start is called before the first frame update
    void Start()
    {
        if (dirtRateText != null) dirtRateText.gameObject.SetActive(false);

        if (cleanDishRack == null) cleanDishRack = FindObjectOfType<CleanDishRack>().transform;

        currentDirtRate = maxDirtRate;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //A: Better if you can move this to after the currentDirtRate was changed

    public void ReduceDirtRate(float drainRate)
    {
        currentDirtRate -= drainRate;
        if (currentDirtRate <= minDirtRate) OnAllDishesCleaned();
    }

    private void OnAllDishesCleaned()
    {
        currentDirtRate = minDirtRate;

        transform.position = cleanDishRack.transform.position;

        transform.parent = cleanDishRack;
        if (dirtRateText != null) dirtRateText.gameObject.SetActive(false);
        onDishAdded.Invoke();
        GetComponent<Collider2D>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the dish is staying within the sponge
        if (collision.GetComponent<Sponge>())
        {
            if (dirtRateText != null) dirtRateText.gameObject.SetActive(true);
            dirtRateText.text = "Current dirt rate: " + currentDirtRate.ToString("f0") + "%";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Sponge>())
        {
            dirtRateText.gameObject.SetActive(false);
        }
    }
}
