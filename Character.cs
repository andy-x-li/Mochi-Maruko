using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Character : MonoBehaviour
{
    // from unity (controls player movement and animations)
    private Rigidbody2D rb; 
    private Animator anim;
    // help to move the character 
    private float moveSpeed;
    private float dirX;
    // help to flip character so it faces where it goes
    private bool facingRight = true;
    private Vector3 localScale;

    // use this for initialization 
    private void Start()
    {
        // gets rigidbody and animator components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // sets localScale and moveSpeed
        localScale = transform.localScale;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    private void Update()
    {
        /* pass a value to dirX depending on left or right arrow buttons 
        pressed and moveSpeed */
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        /* if jump button is pressed and our character is not going up or 
        down, then a force is passed upwards to the rigidbody with a factor 
        of 700 */
         if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 700f); 

        /* if character moves left or right and is not in the air then sets 
        isRunning to true or false if otherwise */
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
        
        /* if our character is not going up or down, then iJumping and
        isFalling is set to false and animation is set to idle or running */
        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        /* if our character is not moving at all, everything is set to false*/
        if (rb.velocity.y < 0 && Mathf.Abs(dirX) > 0)
        {
            anim.SetBool("isRunning", true);
        }

        /* if the character is going up then isJumping is set to true */
        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);
        
        /* if the character is falling down then its animation is switched
        from isJumping to isFalling */
        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        } 
    }

    // pass a velocity to rigidbody depending on dirX
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    /* flips a character depending on where it is going and where it is 
    currently facing */
    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
}
