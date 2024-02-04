using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    bool wasCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindAnyObjectByType<GameSession>().AddToScore(pointsForCoinPickup);

            // in 3D it is good to play sound in one side or another, but in 2D it is the best to play sound in camera
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 0.6f);
            // make inactive game object like coin or another objects
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
