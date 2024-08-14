using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
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
            Vector2 impactVector = new Vector2(impactPoint.position.x, impactPoint.position.y);
            RaycastHit2D hit = Physics2D.Raycast(impactVector, (mouseWorldPos-impactVector).normalized,0.5f);
            if (hit.collider != null)
            {
                Instantiate(Dust,impactVector, Quaternion.identity);
            }
            rb.AddForce((mouseWorldPos-new Vector2(transform.position.x,transform.position.y)).normalized * -1 * pushPower, ForceMode2D.Impulse);
            cam.GetComponent<CameraScript>().Screenshake = true
        }
    }
    private void HandleMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(mouseWorldPos.x - rotationPoint.transform.position.x,mouseWorldPos.y - rotationPoint.transform.position.y) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.AngleAxis(lookAngle*-1, Vector3.forward);
    }
}
