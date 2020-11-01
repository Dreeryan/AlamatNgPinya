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
		
		//A: Make it check if dishRack is null before finding. This is expensive
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
				//A: Just assign directly instead of making an new vector if possible
				// This can cause memory issues
                transform.position = new Vector2(dishRack.transform.position.x, dishRack.transform.position.y);
            }

            if (cleanRateText != null) cleanRateText.gameObject.SetActive(true);
            sponge = collision.gameObject.GetComponent<Sponge>();
			
			//A: Put this inside the nullcheck scope. This is still amounting to not nullchecking
            cleanRateText.text = "Current clean rate: " + currentCleanRate.ToString("f0") + "%";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sponge"))
        {
			//A: Nullcheck
            cleanRateText.gameObject.SetActive(false);
        }
    }
}
