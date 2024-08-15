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

    public AudioSource audioSource;
    [SerializeField] public AudioClip[] itemSounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuManager.isPaused)
        {
            HandleMousePos();
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (hasNailGun && !usingNailGun)
                {
                    usingNailGun = true;
                    usingJackhammer = false;
                }
                else if (hasJackhammer && !usingJackhammer)
                {
                    usingJackhammer = true;
                    usingNailGun = false;
                }
            }
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
    }
    private void HandleUseJackHammer()
    {
        
        if (Input.GetButtonDown("Fire1") && Physics2D.OverlapCircle(new Vector2(jackhammerImpactPoint.position.x, jackhammerImpactPoint.position.y), 0.1f,LayerMask.GetMask("Ground")))
        {
            
            Vector2 impactVector = new Vector2(jackhammerImpactPoint.position.x, jackhammerImpactPoint.position.y);
            AudioSource.PlayClipAtPoint(itemSounds[0], new Vector2(jackhammerImpactPoint.position.x,jackhammerImpactPoint.position.y));
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
        if(Input.GetButtonDown("Fire1") && nailGunFireRate >= 0.25f)
        {
            AudioSource.PlayClipAtPoint(itemSounds[1],new Vector2(nailFirePoint.position.x,nailFirePoint.position.y));
            nailGunFireRate = 0f;
            Vector2 dir = new Vector2(mouseWorldPos.x - nailFirePoint.position.x, mouseWorldPos.y - nailFirePoint.position.y);
            nailScript nail = Instantiate(nailPrefab, new Vector3(nailFirePoint.position.x, nailFirePoint.position.y, nailFirePoint.position.z),Quaternion.Euler(0,0,0-lookAngle));
            nail.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 15f, ForceMode2D.Impulse);
        }
    }
    private void HandleMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(mouseWorldPos.x - rotationPoint.transform.position.x,mouseWorldPos.y - rotationPoint.transform.position.y) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.AngleAxis(lookAngle*-1, Vector3.forward);
    }
}
