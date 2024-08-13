using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailGunScript : MonoBehaviour
{
    
    public GameObject nailPrefab;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(nailPrefab, GetComponent<Transform>().position, Quaternion.identity);
        }
        
    }
}
