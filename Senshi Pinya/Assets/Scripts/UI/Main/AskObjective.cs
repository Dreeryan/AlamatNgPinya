using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskObjective : MonoBehaviour
{
    [SerializeField] private GameObject objectives;
    [SerializeField] private float currentSeconds;
    [SerializeField] private float resetTime;
    // Start is called before the first frame update
    void Start()
    {
        currentSeconds = 0;
        objectives.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Time remaining until objective disappears: " + currentSeconds);
        currentSeconds -= 1 * Time.deltaTime;

        if (currentSeconds <= 0)
        {
            currentSeconds = 0;
            objectives.SetActive(false);
        }
    }

    public void StartTime()
    {
        currentSeconds = resetTime;
        objectives.SetActive(true);
    }
}
