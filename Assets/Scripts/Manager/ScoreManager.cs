using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : BaseManager<ScoreManager>
{
    [SerializeField] private ScoreDatabase scoreDB;

    public float GetFinalScore(string minigameId, float secsTaken)
    {
        if (scoreDB == null || scoreDB.GetData(minigameId) == null)
            return -1;

        return scoreDB.GetData(minigameId).GetResultingScore(secsTaken);
    }
}
