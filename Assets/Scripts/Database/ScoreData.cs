using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData : BaseData
{
    [Header("WinCheck")]
    [SerializeField] private int goal;
    [Tooltip("Words before it shows progress, [phrase] : [current] / [goal] ")]
    [SerializeField] private string phrase;

    public int Goal => goal;
    public string Phrase => phrase;

    [Header("MotivationManager")]
    [SerializeField] private MotivationType motivationType;
    
    public MotivationType MotivationType => motivationType;

    [Header("ScoreData")]
    [SerializeField] private float  baseScoreValue;
    [SerializeField] private float  secondsTarget;
    public float BaseScoreValue => baseScoreValue;
    public float SecondsTarget => secondsTarget;

    public float GetResultingScore(float secondsTaken)
    {
        return baseScoreValue * (secondsTarget / secondsTaken);
    }
}
