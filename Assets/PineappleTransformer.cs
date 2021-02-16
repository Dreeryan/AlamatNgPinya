using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleTransformer : MonoBehaviour
{
    public Sprite                     playerSprite;
    [SerializeField] private int      maximumAmountToAsk;
    [SerializeField] private Sprite[] pineappleTransformation;
    private void TransformPlayer()
    {
        // probably modify this later and make it singleton
        TaskListManager.Instance.AddNumberOfTimesAsked();
        playerSprite = pineappleTransformation[TaskListManager.Instance.numberOfTimesAsked];
    }

}
