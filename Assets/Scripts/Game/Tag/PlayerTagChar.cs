using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTagChar : TagCharacter
{
    protected override void OnMinigameCompleted()
    {
        PlayerController controller = GetComponent<PlayerController>();
        if (controller != null) controller.CanMove = false;
    }
}
