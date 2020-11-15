using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dish : MonoBehaviour
{
    [SerializeField] private Sponge sponge;

	//A: Dont do headers this way. Make it more specific (UI, Move Settings, etc)
    [Header("Variables")]
    [SerializeField] public float currentDirtRate;
    [SerializeField] private float minDirtRate = 0f;
    [SerializeField] private Transform dishRack;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI cleanRateText;

    public bool isPlaced;
    // Start is called before the first frame update
    void Start()
    {
        if (cleanRateText != null)
        cleanRateText.gameObject.SetActive(false);
        cleanRateText = GameObject.Find("Current dirt rate").GetComponent<TextMeshProUGUI>();


        dishRack = GameObject.Find("Dish Rack").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // If the current clean rate is equal to the max clean rate
        if (currentDirtRate < minDirtRate)
        {
            currentDirtRate = minDirtRate;
            // The clean dish will be put into the rack
            transform.position = dishRack.transform.position;
            isPlaced = true;
			
			//A: Nullcheck
            cleanRateText.gameObject.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the dish is staying within the sponge
        if (collision.gameObject.CompareTag("Sponge"))
        {
            if (cleanRateText != null)
            cleanRateText.gameObject.SetActive(true);
            sponge = collision.gameObject.GetComponent<Sponge>();
			
			//A: Move this into the nullcheck scope. This is still dangerouse
            cleanRateText.text = "Current dirt rate: " + currentDirtRate.ToString("f0") + "%";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sponge"))
        {
            cleanRateText.gameObject.SetActive(false);
        }
    }
}
