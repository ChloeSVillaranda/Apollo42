using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 2f;
    public int health = 1;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6f) // If enemy goes off screen
        {
            Destroy(gameObject); // Destroy it
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collided with: " + collision.name); // test log
        if (collision.CompareTag("Bullet")) {
            health--;
            Destroy(collision.gameObject); // Destroy the bullet

            if (health <= 0) {
                Destroy(gameObject); // Destroy enemy if health is 0
            }
        }

        ScoreManager.instance.AddScore(10); // add 10 points
    }
}
