using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepingMinigame : MonoBehaviour
{
    [SerializeField] private GameObject sweepingMinigame;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        sweepingMinigame.SetActive(false);
        winScreen.SetActive(false);
    }

    public void ActivateMinigame()
    {
        sweepingMinigame.SetActive(true);
        player.SetActive(false);
    }

    public void DeactivateMinigame()
    {
        sweepingMinigame.SetActive(false);
        player.SetActive(true);
        winScreen.SetActive(false);
    }
}
