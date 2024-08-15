using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ItemScript : MonoBehaviour
{
    public GameObject item;

    float speed = 5f;
    float height = 0.5f;
    float ogY;
    Vector3 pos;

    void Start()
    {
        item = this.gameObject;
        pos = transform.position;
        ogY = pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = Mathf.Sin(Time.time * speed);
        transform.position = new Vector2(pos.x, ogY+newY * height);
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(item = GameObject.Find("JackhammerItem"))
            {
                collision.gameObject.GetComponent<JackhammerScript>().hasJackhammer = true;
            }
            if (item = GameObject.Find("NailGunItem"))
            {
                collision.gameObject.GetComponent<JackhammerScript>().hasNailGun = true;
            }
            Destroy(gameObject);
        }
    }
}
