using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 velocity = Vector3.zero;
    public float smooth = 0.25f;

    // Start is called before the first frame update
    void Start()
    {        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerPos.x = player.transform.position.x;
        playerPos.y = player.transform.position.y;
        playerPos.z = -1f;
        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smooth);
    }
}
