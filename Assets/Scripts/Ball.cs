using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 minMaxAngle;
    public AudioClip[] hitClip;

    static Vector3 velocity;

    float heightLimit;

    void Start()
    {
        heightLimit = Camera.main.orthographicSize - transform.localScale.y / 2;

        float angle = Random.Range(minMaxAngle.x, minMaxAngle.y);
        velocity = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)) * speed; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
        if(transform.position.y > heightLimit || transform.position.y < -heightLimit)
        {
            velocity.y *= -1;
            AudioSource.PlayClipAtPoint(hitClip[0], Vector3.zero, 0.8f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        velocity.x *= -1.03f;
        velocity.y *= Random.Range(1, 1.5f);
        AudioSource.PlayClipAtPoint(hitClip[1], Vector3.zero, 1);
    }
}
