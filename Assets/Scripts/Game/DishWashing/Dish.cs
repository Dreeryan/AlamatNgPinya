using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dish : MonoBehaviour
{
	//A: Explicitly private
    [SerializeField] Sponge sponge;

    [Header("Variables")]
    [SerializeField] public float currentCleanRate;
    [SerializeField] Transform dishRack;
    [SerializeField] float maxRate;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI cleanRateText;

    // Start is called before the first frame update
    void Start()
    {
		//A: Null check
        cleanRateText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		//A: Is it not possible to do this into a method thats called when the player cleans it
		// rather than per frame
		
        // If the current clean rate is equal to the max clean rate
        if (currentCleanRate > maxRate)
        {
            currentCleanRate = maxRate;
            // The clean dish will be put into the rack
            transform.position = new Vector2(dishRack.transform.position.x, dishRack.transform.position.y);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the dish is staying within the sponge
        if (collision.gameObject.CompareTag("Sponge"))
        {
			//A: Null check
            cleanRateText.gameObject.SetActive(true);
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
