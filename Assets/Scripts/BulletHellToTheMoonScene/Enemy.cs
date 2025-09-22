using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 2f;
    public int health = 1;
    public int damage = 1;

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6f) // If enemy goes off screen
        {
            Destroy(gameObject); // Destroy it
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collided with: " + collision.name);

        if (collision.CompareTag("Bullet")) {
            health--;
            Destroy(collision.gameObject);

            if (health <= 0) {
                Destroy(gameObject);
            }

            ScoreManager.instance.AddScore(10);
        }

        if (collision.CompareTag("RocketPlayer")) {
            RocketHealth rocket = collision.GetComponent<RocketHealth>();
            if (rocket != null) {
                rocket.TakeDamage(damage);
            }
        }
    }
}
