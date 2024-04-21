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


    private void Update()
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

        rb.AddForce(new Vector2(rb.velocity.x * slideSpeed,rb.velocity.y), forceMode);

        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.1f);
        //animator.Play("");
        animator.SetBool("isSliding", false);
        regularColli.enabled = true;
        slideColli.enabled = false;
        isSliding = false;
    }

    public bool getIsSliding() { return isSliding; }

}
