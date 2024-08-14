using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGunScript : MonoBehaviour
{
    
    public GameObject nailPrefab;
    public Transform firePoint;
   
    public GameObject leftNailPrefab;
    public GameObject rightNailPrefab;
    public int playerFacing;
    public int NailCount;
    public bool isNailGunAvailable;





    // Start is called before the first frame update
    void Start()
    {
        NailCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            playerFacing = 1;
        }

        if(Input.GetKey(KeyCode.D))
        {
            playerFacing = -1;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(playerFacing == 1)
            { 
                Instantiate(rightNailPrefab,new Vector2(firePoint.transform.position.x,firePoint.transform.position.y), Quaternion.identity);
                NailCount -= 1;
            }
            if (playerFacing == -1)

            {
                Instantiate(leftNailPrefab, new Vector2(firePoint.transform.position.x, firePoint.transform.position.y), Quaternion.identity);
                NailCount -= 1;
            }
        }

        if (NailCount == 0)
        {
            Destroy(gameObject);
        }
        
    }
}
