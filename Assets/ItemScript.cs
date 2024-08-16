using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ItemScript : MonoBehaviour
{
    [SerializeField] public Sprite[] itemSprites;
    public SpriteRenderer sr;

    float speed = 5f;
    float height = 0.5f;
    float ogY;
    Vector3 pos;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
            if(sr.sprite == itemSprites[0])
            {
                collision.gameObject.GetComponent<JackhammerScript>().hasJackhammer = true;
            }
            if (sr.sprite == itemSprites[1])
            {
                collision.gameObject.GetComponent<JackhammerScript>().hasNailGun = true;
            }
            Destroy(gameObject);
        }
    }
}
