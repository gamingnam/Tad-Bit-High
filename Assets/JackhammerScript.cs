using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class JackhammerScript : MonoBehaviour
{
    public bool hasJackhammer;
    public bool hasNailGun;


    private Rigidbody2D rb;
    [SerializeField] GameObject Dust;
    [SerializeField] Transform rotationPoint;

    [SerializeField] Transform jackhammerImpactPoint;
    public float pushPower;

    public Vector2 mouseWorldPos;
    public float lookAngle;
    
    private Camera cam;

    public nailScript nailPrefab;
    public Transform nailFirePoint;
    public int NailCount;
    public float nailGunFireRate;

    public bool usingNailGun;
    public bool usingJackhammer;

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
        if (usingJackhammer)
        {
            HandleUseJackHammer();
        }
        else if (usingNailGun)
        {
            HandleUseNailGun();
            nailGunFireRate += Time.deltaTime;
        }
        

    }
    private void HandleUseJackHammer()
    {
        
        if (Input.GetButtonDown("Fire1") && Physics2D.OverlapCircle(new Vector2(jackhammerImpactPoint.position.x, jackhammerImpactPoint.position.y), 0.1f,LayerMask.GetMask("Ground")))
        {
            Vector2 impactVector = new Vector2(jackhammerImpactPoint.position.x, jackhammerImpactPoint.position.y);
            RaycastHit2D hit = Physics2D.Raycast(impactVector, (mouseWorldPos-impactVector).normalized,0.5f);
            if (hit.collider != null)
            {
                Instantiate(Dust,impactVector, Quaternion.identity);
            }
            rb.AddForce((mouseWorldPos-new Vector2(transform.position.x,transform.position.y)).normalized * -1 * pushPower, ForceMode2D.Impulse);
            cam.GetComponent<CameraScript>().Screenshake = true;
        }
    }
    private void HandleUseNailGun()
    {
        if(Input.GetButtonDown("Fire1") && hasNailGun && nailGunFireRate >= 1f)
        {
            nailGunFireRate = 0f;
            Vector2 dir = new Vector2(mouseWorldPos.x - nailFirePoint.position.x, mouseWorldPos.y - nailFirePoint.position.y);
            nailScript nail = Instantiate(nailPrefab, new Vector3(nailFirePoint.position.x, nailFirePoint.position.y, nailFirePoint.position.z),Quaternion.identity);
            nail.nailDirection = dir;
        }
    }
    private void HandleMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(mouseWorldPos.x - rotationPoint.transform.position.x,mouseWorldPos.y - rotationPoint.transform.position.y) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.AngleAxis(lookAngle*-1, Vector3.forward);
    }
}
