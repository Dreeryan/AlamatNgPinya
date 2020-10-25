using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
	//A: Explicitly private the variables and methods
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
		//A: Null check anim first before accessing
		//A: You will want to do specific triggers than keeping this in update		
        // Walking animation
        anim.SetBool("IsWalking", controller.isMoving);


        SwitchForAnim();
    }

    // For form changes (to be implemented later on once other scripts are made)
    void SwitchForAnim()
    {

    }
}
