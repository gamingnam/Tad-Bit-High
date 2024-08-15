using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterScript : MonoBehaviour
{
    private float yPos;
    [SerializeField] private float riseRate;
    [SerializeField] public Canvas canvas;
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
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            canvas.GetComponent<MenuManager>().Lose();
        }
    }
}
