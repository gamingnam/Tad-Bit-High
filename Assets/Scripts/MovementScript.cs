using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private float Vertical;
    private float Horizontal;
    private Vector2 movement;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        
        movement = new Vector2 (Horizontal*speed, Vertical*speed);
        
        
    }
    private void FixedUpdate()
    {
        rb.velocity = movement;
    }
}
