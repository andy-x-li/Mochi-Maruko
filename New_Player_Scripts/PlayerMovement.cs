using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * runSpeed;

        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") == 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown("w"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        // Debug.Log(CrossPlatformInputManager.GetButtonDown("Jump"));

        if (CrossPlatformInputManager.GetButtonDown("Crouch") || Input.GetKeyDown("s"))
        {
            crouch = true;
        } 
        else if (CrossPlatformInputManager.GetButtonUp("Crouch") || Input.GetKeyUp("s"))
        {
            crouch = false;
        }
    }
    
    void FixedUpdate()
    {
        // Move our character 
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
}
