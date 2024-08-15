using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideScript : MonoBehaviour
{
    public Sprite[] itemSprites;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponentInParent<JackhammerScript>().usingNailGun == true){
            sr.sprite = itemSprites[0];
        }
        else if (GetComponentInParent<JackhammerScript>().usingJackhammer == true){
            sr.sprite = itemSprites[1];
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
