using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private float yPos;
    [SerializeField] private float riseRate;
    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        yPos += Time.deltaTime * riseRate;
        transform.position = new Vector3(transform.position.x,yPos, transform.position.z);
    }
}
