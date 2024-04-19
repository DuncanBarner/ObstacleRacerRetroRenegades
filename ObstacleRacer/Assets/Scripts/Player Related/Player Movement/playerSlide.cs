using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlide: MonoBehaviour
{
    public PlatformPlayerController pC;
    public Rigidbody2D rb;
    public Animator animator;
    public CapsuleCollider2D regularColli;
    public CapsuleCollider2D slideColli;
    public float slideSpeed = 800f;
    public bool isSliding = false;
    public ForceMode2D forceMode;


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !pC.OnWall())
            slide();
    }

    private void slide()
    {
        isSliding = true;

        animator.SetBool("isSliding", true);

        regularColli .enabled = false;
        slideColli .enabled = true;

        if (pC.getHorizontalInput() > 0 && !PauseMenu.isPaused)
            {
             rb.AddForce(Vector2.right * slideSpeed,forceMode); // Facing right
            }
        else
            {
             rb.AddForce(Vector2.left * slideSpeed,forceMode); // Facing Left
            }

        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(1.5f);
        //animator.Play("");
        animator.SetBool("isSliding", false);
        regularColli.enabled = true;
        slideColli.enabled = false;
        isSliding = false;
    }

}
