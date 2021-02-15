using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTagChar : TagCharacter
{
    [SerializeField] private UnityEvent onPlayerTag;

    protected override void TagTarget(TagCharacter target)
    {
        base.TagTarget(target);

        onPlayerTag?.Invoke();
    }

    protected override void OnMinigameCompleted()
    {
        PlayerController controller = GetComponent<PlayerController>();
        if (controller == null) return;
        
        controller.CanMove = false;
        controller.PlayerAnim.DisableAnimation();
    }
}
