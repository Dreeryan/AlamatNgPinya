using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData : BaseData
{
    [SerializeField] private string minigameId;
    [SerializeField] private float  baseScoreValue;
    [SerializeField] private float  secondsTarget;

    public string MinigameId => minigameId;
    public float BaseScoreValue => baseScoreValue;
    public float SecondsTarget => secondsTarget;

    public float GetResultingScore(float secondsTaken)
    {
        return baseScoreValue * (secondsTarget / secondsTaken);
    }
}
