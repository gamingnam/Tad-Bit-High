using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Vector3 leftForce;
    public Vector3 rightForce;
    public Vector3 upForce;
    public Vector3 jumpForce;

    public GameObject groundCheck;
    //public Transform groundCheckVisual;
    public float groundCheckRange;
    public bool jumpCheck;
    public float jumpingTimer;
    public float wallJumpingTimer;
    public bool wallJumpCheck;
    public Animator animatorOne;

    public float slidingDuration;
    public float slidingCooldown;
    public Rigidbody2D rb;
    public bool slideCheck;
    public BoxCollider2D defaultCollider;
    public BoxCollider2D slideCollider;



    // Start is called before the first frame update
    void Start()
    {
        defaultCollider.enabled = true;
        slideCollider.enabled = false;
        jumpCheck = true;
        wallJumpCheck = false;
        slideCheck = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        slidingCooldown += Time.deltaTime;
        animatorOne.SetBool("isRunning", false);
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(leftForce);
            animatorOne.SetBool("isRunning", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(rightForce);
            animatorOne.SetBool("isRunning", true);
        }
        //Regular Jump
        if (Input.GetKey(KeyCode.W) && jumpCheck && Physics2D.OverlapCircle(new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y), 0.5f))
        {
            animatorOne.SetBool("isJumping", true);
            GetComponent<Rigidbody2D>().AddForce(upForce);
        }

        //Wall Jump
        if (Input.GetKey(KeyCode.W) && wallJumpCheck)
        {
            animatorOne.SetBool("isJumping", true);
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
            wallJumpingTimer += Time.deltaTime;
        }
        if (wallJumpingTimer > 0)
        {
            wallJumpCheck = false;
        }
        //Sliding
        //Create the sliding animation, disabling the main collider for the sliding one (and later activating the main one again), and then lowering the linear drag
        if (slidingCooldown >= 2f)
        {
            if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                defaultCollider.enabled = false;
                slideCollider.enabled = true;
                animatorOne.SetBool("isSliding", true);
                slidingDuration += Time.deltaTime;
                slideCheck = true;
                if (slidingDuration >= 0.5f)
                {
                    rb.drag = 3;
                }
                if (slidingDuration >= 1f)
                {
                    rb.drag = 5;
                }
                if (slidingDuration >= 1.5f)
                {
                    rb.drag = 8;
                }
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.W) || slidingDuration >= 1.8f)
            {
                defaultCollider.enabled = true;
                slideCollider.enabled = false;
                slideCheck = false;
                animatorOne.SetBool("isSliding", false);
                rb.drag = 1.75f;
                slidingDuration = 0;
                slidingCooldown = 0;
            }
        }

    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckVisual.position, groundCheckRange);
    }
    */
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animatorOne.SetBool("isJumping", false);
            wallJumpingTimer = 0;
            jumpCheck = true;
            wallJumpCheck = false;
        }
        if (collision.gameObject.tag == "WallJump")
        {
            animatorOne.SetBool("isJumping", false);
            wallJumpingTimer = 0;
            wallJumpCheck = true;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        jumpCheck = false;
    }
}
