using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Sponge : MonoBehaviour
{
    [SerializeField] private Draggable   draggable;

    private Dish dish;
    private bool isPlayingAudio;

    [Header("Sponge Settings")]
    [SerializeField] private float      drainRate;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI    guideText;

    [SerializeField] private UnityEvent onScrubbingDish;
    [SerializeField] private UnityEvent onStopScrubbing;
    
    void Start()
    {
        if (draggable == null) draggable = GetComponent<Draggable>();
        if (guideText != null) guideText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (draggable.HasMovedEnough && dish != null)
        {
            if (!isPlayingAudio)
            {
                onScrubbingDish?.Invoke();
                isPlayingAudio = true;
            }
            dish.ReduceDirtRate(drainRate * Time.deltaTime);
        }
        else
        {
            if (isPlayingAudio)
            {
                onStopScrubbing?.Invoke();
                isPlayingAudio = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (dish != null) return;
        // Checks if the collided object is a dirty dish
        if (collision.gameObject.GetComponent<Dish>() == null) return;

        dish = collision.gameObject.GetComponent<Dish>();
        if (guideText != null) guideText.gameObject.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Checks if the exiting collision is the current dish
        if (collision.GetComponent<Dish>() && 
            collision.gameObject == dish.gameObject)
        {
            dish = null;
        }
    }
}
