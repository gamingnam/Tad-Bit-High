using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 velocity = Vector3.zero;
    public float smooth = 0.25f;

    public bool Screenshake = false;
    [SerializeField] private AnimationCurve curve;
    private float duration = 1f;

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

        if (Screenshake)
        {
            Screenshake = false;
            StartCoroutine(Shake());
        }

    }
    IEnumerator Shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float mag = curve.Evaluate(elapsedTime / duration);
            Vector2 offset = Random.insideUnitCircle * mag;
            transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, transform.position.z);
            yield return null;
        }

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
