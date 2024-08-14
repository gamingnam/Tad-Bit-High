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
    
    // Start is called before the first frame update
    void Start()
    {
        jumpCheck = true;
        wallJumpCheck = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(NailGunPrefab, GetComponent<Transform>().position, Quaternion.identity);
        }
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
        if (Input.GetKey(KeyCode.W) && jumpCheck && Physics2D.OverlapCircle(new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y), 0.5f, LayerMask.GetMask("Ground")))
        {
            GetComponent<Rigidbody2D>().AddForce(upForce);
        }

        //Wall Jump
        if (Input.GetKey(KeyCode.W) && wallJumpCheck)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
            wallJumpingTimer += Time.deltaTime;
        }
        if (wallJumpingTimer > 0)
        {
            wallJumpCheck = false;
        }
        //Sliding
        /*
        if (Input.GetKey(KeyCode.S))
        {
            Create the sliding animation, disabling the main collider for the sliding one (and later activating the main one again), and then lowering the linear drag
        }
        */
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
            //jumpingTimer = 0;
            wallJumpingTimer = 0;
            jumpCheck = true;
            wallJumpCheck = false;
        }
        if (collision.gameObject.tag == "WallJump")
        {
            //jumpingTimer = 0;
            wallJumpingTimer = 0;
            wallJumpCheck = true;
            //jumpCheck = false;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        jumpCheck = false;
    }
}
