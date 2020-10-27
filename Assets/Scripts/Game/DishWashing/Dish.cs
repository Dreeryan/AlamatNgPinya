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
    [SerializeField] Transform dishRack;
    [SerializeField] private float maxRate;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI cleanRateText;

    // Start is called before the first frame update
    void Start()
    {
        if (cleanRateText != null) cleanRateText.gameObject.SetActive(false);
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
                transform.position = new Vector2(dishRack.transform.position.x, dishRack.transform.position.y);
            }

            if (cleanRateText != null) cleanRateText.gameObject.SetActive(true);
            sponge = collision.gameObject.GetComponent<Sponge>();
            cleanRateText.text = "Current clean rate: " + currentCleanRate.ToString("f0") + "%";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dish"))
        {
            cleanRateText.gameObject.SetActive(false);
        }
    }
}
