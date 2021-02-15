using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseManager<GameManager>
{
    public bool IsPaused { get; set; } = false;

    public float Score { get; set; } = 0f;

    public void UpdateScore(float val)
    {
        Score += val;
    }
}
