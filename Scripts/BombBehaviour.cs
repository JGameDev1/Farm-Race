using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    int direction;
    public float speed;
    public float onCronoToChangeDirection;
    float cronoToChangeDirection;
    public GameObject effect;

    private void Awake()
    {
        direction = 1;
        cronoToChangeDirection = onCronoToChangeDirection;
    }

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, direction * Time.deltaTime * speed);
        cronoToChangeDirection -= Time.deltaTime;
        if (cronoToChangeDirection <= 0)
        {
            direction = -direction;
            cronoToChangeDirection = onCronoToChangeDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {collision.gameObject.GetComponent<PlayerController>().fading=true;
        GetComponent<SpriteRenderer>().enabled=false;
        GetComponent<CircleCollider2D>().enabled=false;
        GetComponent<AudioSource>().Play();
        effect.SetActive(true);}

    }
}
