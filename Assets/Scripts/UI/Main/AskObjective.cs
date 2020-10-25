using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskObjective : MonoBehaviour
{
    [SerializeField] private GameObject objectives;
    [SerializeField] private float      currentSeconds;
    [SerializeField] private float      resetTime;
    // Start is called before the first frame update
    void Start()
    {
		//A: Nullcheck
        currentSeconds = 0;
        objectives.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentSeconds -= 1 * Time.deltaTime;

        // Hides the objectives UI if time runs out 
        if (currentSeconds <= 0)
        {
            currentSeconds = 0;
            objectives.SetActive(false);
        }
    }

    // Resets seconds and shows objectives UI
    public void StartTime()
    {
        currentSeconds = resetTime;
        objectives.SetActive(true);
    }
}
