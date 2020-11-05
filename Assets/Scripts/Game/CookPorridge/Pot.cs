using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pot : MonoBehaviour
{
    [Header("UI")]
    public GameObject Meter;
    public Image progressBar;

    [Header("Variables")]
    [SerializeField] private float maxTemperature;
    [SerializeField] public float addTemperature;
    [SerializeField] public float uncookedTemp;
    [SerializeField] public float undercookedTemp;
    [SerializeField] public float cookedTemp;
    [SerializeField] public float burnedTemp;

    [SerializeField] TextMeshProUGUI cookStatus;

    [SerializeField] Porridge porridge;
    [SerializeField] Draggable draggable;

    public bool isOccupied;

    // Start is called before the first frame update
    void Start()
    {
        cookStatus = GameObject.Find("Cook Status").GetComponent<TextMeshProUGUI>();
        draggable = GameObject.FindGameObjectWithTag("Porridge").GetComponent<Draggable>();
    }

    // Update is called once per frame
    void Update()
    {
        // If pot is occupied and the porridge is placed
        if (isOccupied && draggable.isPlaced == true)
        {
            porridge.porridgeTemp += addTemperature * Time.deltaTime;

            if (porridge.porridgeTemp >= maxTemperature)
            {
                porridge.porridgeTemp = maxTemperature;
            }

            if (cookStatus != null) cookStatus.text = " " + porridge.CurrentState;
            if (progressBar != null) UpdateUI();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Porridge"))
        {
            porridge = collision.gameObject.GetComponent<Porridge>();
            isOccupied = true;

            if (cookStatus != null)
            {
                cookStatus.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Porridge"))
        {
            isOccupied = false;
            progressBar.fillAmount = 0;

            if (cookStatus != null)
            {
                cookStatus.gameObject.SetActive(false);
            }
        }
    }

    void UpdateUI()
    {
        progressBar.fillAmount = porridge.porridgeTemp / maxTemperature;
    }
}
