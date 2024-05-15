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
    public float slideDuration = 0.15f;
    public bool isSliding = false;
    public ForceMode2D forceMode;
    public AudioClip slideSFX2;
    public CapsuleCollider2D[] playerOneColliders;

    private float timePassed = 0.0f;
    private void Update()
    {
        timePassed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.RightShift) && !pC.OnWall() && slideCD < timePassed && !PauseMenu.isPaused)
            slide();

        if (isSliding && pC.OnWall())
        {
            stopNow();
        }
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
        yield return new WaitForSeconds(slideDuration);
        //animator.Play("");
        animator.SetBool("isSliding", false);
        regularColli.enabled = true;
        slideColli.enabled = false;
        isSliding = false;
        timePassed = 0.0f;
    }

    private void stopNow()
    {
        animator.SetBool("isSliding", false);
        regularColli.enabled = true;
        slideColli.enabled = false;
        isSliding = false;
        timePassed = 0.0f;
    }

    public bool getIsSliding() { return isSliding; }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.Equals(playerOneColliders[0]) || other.collider.Equals(playerOneColliders[1]))
        {
            slideColli.enabled = false;
        }
    }

}
