using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Slide : MonoBehaviour
{
    public Player2Movement pC;
    public Rigidbody2D rb;
    public Animator animator;
    public CapsuleCollider2D regularColli;
    public CapsuleCollider2D slideColli;
    public float slideSpeed = 800f;
    public float slideCD = 1.5f;
    public bool isSliding = false;
    public ForceMode2D forceMode;
    public AudioClip slideSFX2;

    private float timePassed = 0.0f;
    private void Update()
    {
        timePassed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.RightShift) && !pC.OnWall() && slideCD < timePassed && !PauseMenu.isPaused)
            slide();
    }

    private void slide()
    {
        isSliding = true;

        animator.SetBool("isSliding", true);

        regularColli.enabled = false;
        slideColli.enabled = true;

        if (pC.getHorizontalInput() > 0)
            rb.AddForce(Vector2.right * slideSpeed, forceMode);
        else
            rb.AddForce(Vector2.left * slideSpeed, forceMode);

        SoundFXManager.instance.PlaySoundFXCLip(slideSFX2,transform, 1f);

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
        timePassed = 0.0f;
    }

    public bool getIsSliding() { return isSliding; }

}
