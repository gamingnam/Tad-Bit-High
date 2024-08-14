using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleScript : MonoBehaviour
{
    private float lifeTime = 3f;
    private float lifeTimer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= lifeTime && gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
