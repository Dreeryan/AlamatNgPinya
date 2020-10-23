using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    PlayerController controller;
    PlayerMovement movement;
    TimerSystem timerSystem;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<PlayerController>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walking animation
        anim.SetBool("IsWalking", controller.isMoving);


        SwitchForAnim();
    }

    // For form changes (to be implemented later on once other scripts are made)
    void SwitchForAnim()
    {

    }
}
