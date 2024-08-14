using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGunScript : MonoBehaviour
{
    
    public GameObject nailPrefab;
    public Vector3 offset;
   
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
                Instantiate(rightNailPrefab, GetComponent<Transform>().position, Quaternion.identity);
                NailCount -= 1;
            }
            if (playerFacing == -1)

            {
                Instantiate(leftNailPrefab, GetComponent<Transform>().position, Quaternion.identity);
                NailCount -= 1;
            }
        }

        if (NailCount == 0)
        {
            Destroy(gameObject);
        }
        
    }
}
