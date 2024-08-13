using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Vector3 leftForce;
    public Vector3 rightForce;
    public Vector3 upForce;
    public GameObject groundCheck;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(leftForce);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(rightForce);
        }
        if (Input.GetKey(KeyCode.W) && Physics2D.OverlapCircle(new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y), 0.5f, LayerMask.GetMask("Ground")))
        {
            GetComponent<Rigidbody2D>().AddForce(upForce);
        }
    }
}
