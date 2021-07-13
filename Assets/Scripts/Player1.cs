using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed = 25f;

    float widthLimit;
    float heightLimit;

    private void Start()
    {
        heightLimit = Camera.main.orthographicSize;
        widthLimit = Camera.main.aspect * heightLimit;

        widthLimit -= transform.localScale.x / 2;
        heightLimit -= transform.localScale.y / 2;

        transform.position = new Vector3(-widthLimit, 0);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.S)){
            input.y = -1 * speed;
        }
        if (Input.GetKey(KeyCode.W)) {
            input.y = 1 * speed;
        }

        transform.Translate(input * Time.deltaTime); 

        if (transform.position.y > heightLimit) {
            transform.position = new Vector3(-widthLimit, heightLimit);
        }
        if (transform.position.y < -heightLimit)
        {
            transform.position = new Vector3(-widthLimit, -heightLimit);
        }
    }
}
