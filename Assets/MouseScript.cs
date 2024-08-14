using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{

    public float lookAngle;
    public Vector2 mouseWorldPos;
    private GameObject Player;
    private Vector3 playerLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerLocalScale = Player.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMousePos();
        HandlePlayerRotation();
    }
    private void HandleMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(mouseWorldPos.x - Player.transform.position.x, mouseWorldPos.y - Player.transform.position.y) * Mathf.Rad2Deg;
    }   
    private void HandlePlayerRotation()
    {
        if (lookAngle < 0f)
        {
            playerLocalScale.x = -1f;
        }
        else
        {
            playerLocalScale.x = 1f;
        }
        Player.transform.localScale = new Vector3(playerLocalScale.x,Player.transform.localScale.y, Player.transform.localScale.z);
    }
}
