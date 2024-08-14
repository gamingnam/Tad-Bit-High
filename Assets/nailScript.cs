using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailScript : MonoBehaviour
{
    public Vector3 nailDirection;
    public float nailForce = 5f;
    public float nailTimer;
    private Rigidbody2D rb2d;

    private RigidbodyConstraints2D originalConstraints;
   
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalConstraints = rb2d.constraints;

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position += nailMove;
        nailTimer += Time.deltaTime;
        if (nailTimer > 5f)
        {
            //rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
            rb2d.constraints = originalConstraints;
            rb2d.gravityScale = 1;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")

        {
           // Ammo.GetComponent<AmmoScript>().NailCount -= 1;

            nailMove = new Vector3(0, 0, 0);
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;

        }

        /*else if (collision.gameObject.tag == "nail")
        {
            
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        */
    }
    
}
