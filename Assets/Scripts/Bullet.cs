using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speedOfBullet = 15f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        // dont want to FindAnyObjectByType in update method to search every frame
        player = FindAnyObjectByType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * speedOfBullet;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
