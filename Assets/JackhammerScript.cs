using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackhammerScript : MonoBehaviour
{
    public bool hasJackhammer;
    private Rigidbody2D rb;
    public float pushPower;
    public Vector2 mouseWorldPos;
    [SerializeField] Transform rotationPoint;
    [SerializeField] Transform impactPoint;
    public float lookAngle;
    [SerializeField] GameObject Dust;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMousePos();
        HandleUseJackHammer();  

    }
    private void HandleUseJackHammer()
    {
        
        if (Input.GetButtonDown("Fire1") && Physics2D.OverlapCircle(new Vector2(impactPoint.position.x, impactPoint.position.y), 0.1f,LayerMask.GetMask("Ground")))
        {
            rb.AddForce((mouseWorldPos-new Vector2(transform.position.x,transform.position.y)).normalized * -1 * pushPower, ForceMode2D.Impulse);
            Instantiate(Dust, impactPoint);
        }
    }
    private void HandleMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(mouseWorldPos.x - rotationPoint.transform.position.x,mouseWorldPos.y - rotationPoint.transform.position.y) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.AngleAxis(lookAngle*-1, Vector3.forward);
    }
}
