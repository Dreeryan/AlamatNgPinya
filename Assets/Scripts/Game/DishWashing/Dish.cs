using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dish : MonoBehaviour
{
    [SerializeField] private Sponge sponge;

    [Header("Variables")]
    [SerializeField] public float currentCleanRate;
    [SerializeField] private Transform dishRack;
    [SerializeField] private float maxRate;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI cleanRateText;

    // Start is called before the first frame update
    void Start()
    {
        if (cleanRateText != null) cleanRateText.gameObject.SetActive(false);
		
        if (dishRack != null)
		//Also very risky using gameobject name to assign. This can break in build
        dishRack = GameObject.Find("Dish Rack").transform;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the dish is staying within the sponge
        if (collision.gameObject.CompareTag("Sponge"))
        {
            if (currentCleanRate > maxRate)
            {
                currentCleanRate = maxRate;
                // The clean dish will be put into the rack
                transform.position = dishRack.transform.position;
            }

            if (cleanRateText != null)
            {
                cleanRateText.gameObject.SetActive(true);
                sponge = collision.gameObject.GetComponent<Sponge>();
                cleanRateText.text = "Current clean rate: " + currentCleanRate.ToString("f0") + "%";
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sponge"))
        {
            if (cleanRateText != null)
            cleanRateText.gameObject.SetActive(false);
        }
    }
}
