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
    public GameObject winningPanel;

    [Header("Variables")]
    [SerializeField] private float maxTemperature;
    [SerializeField] public float addTemperature;
    [SerializeField] private float decreaseTemperature;
    [SerializeField] public float uncookedTemp;
    [SerializeField] public float undercookedTemp;
    [SerializeField] public float cookedTemp;
    [SerializeField] private float secondsToWin;

    [SerializeField] TextMeshProUGUI cookStatus;

    [SerializeField] Porridge porridge;

    public bool isOccupied;

    // Start is called before the first frame update
    void Start()
    {
        cookStatus = GameObject.Find("Cook Status").GetComponent<TextMeshProUGUI>();
        if (winningPanel != null) winningPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If pot is occupied and the porridge is placed
        if (isOccupied)
        {
            if (Input.GetMouseButton(0))
            {
                porridge.porridgeTemp += addTemperature * Time.deltaTime;

                if (porridge.porridgeTemp >= maxTemperature)
                {
                    porridge.porridgeTemp = maxTemperature;
                }

                StartCoroutine(Countdown());
                //if (cookStatus != null) cookStatus.text = " " + porridge.CurrentState;
                //if (progressBar != null) UpdateUI();
            }

            else
            {
                porridge.porridgeTemp -= decreaseTemperature * Time.deltaTime;

                if(porridge.porridgeTemp <= 0)
                {
                    porridge.porridgeTemp = 0;
                }
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

    IEnumerator Countdown()
    {
        while (porridge.porridgeTemp > undercookedTemp)
        {
            yield return new WaitForSeconds(secondsToWin);
            if (winningPanel != null)
                winningPanel.SetActive(true);
            porridge.porridgeTemp = progressBar.fillAmount;
        }
    }
}
