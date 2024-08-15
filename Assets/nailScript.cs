using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailScript : MonoBehaviour
{
    public Vector3 nailDirection;
    public float nailForce = 10f;
    public float nailTimer;
    public float destroyTimer;
    private Rigidbody2D rb2d;

    public bool collided;

    private RigidbodyConstraints2D originalConstraints;
   
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        originalConstraints = rb2d.constraints;
        nailTimer = 0f;
        destroyTimer = 0f;
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!collided)
        {
            rb2d.AddForce(nailDirection * nailForce * Time.deltaTime, ForceMode2D.Impulse);
        }
        else if (collided)
        {
            nailTimer += Time.deltaTime;
            if (nailTimer > 5f)
            {
                //rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
                rb2d.constraints = originalConstraints;
                rb2d.gravityScale = 1;
                destroyTimer += Time.deltaTime;
                if (destroyTimer > 5f)
                {
                    Destroy(gameObject);
                }
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)

        {
            rb2d.velocity = Vector3.zero;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            collided = true;
        }

        /*else if (collision.gameObject.tag == "nail")
        {
            
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        */
    }
    
}
