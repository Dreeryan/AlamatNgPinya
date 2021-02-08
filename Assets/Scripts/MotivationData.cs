using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MotivationData")]
public class MotivationData : ScriptableObject
{
    [Header("Chore Requirements")]
    [SerializeField] private int reqMotivation;

    [Header("Motivation Increments")]
    [SerializeField] private int baseGain;
    [SerializeField] private int baseReduction;

    public int ReqMotivation    => reqMotivation;
    public int BaseGain         => baseGain;
    public int BaseReduction    => baseReduction;
}
