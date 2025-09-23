using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLanding : MonoBehaviour {
    public GameObject moonPanel;

    private bool landed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Moon") && !landed) {
            landed = true;
            LandOnMoon(other.transform.position); // Pass the moon's position
        }
    }

    void LandOnMoon(Vector2 moonPosition) {
        // Stop movement
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        FindObjectOfType<ScrollingBackground>().enabled = false;

        // Show panel
        if (moonPanel != null) {
            moonPanel.SetActive(true);
        }

        // Optionally, you can use the moonPosition here if needed
        Debug.Log($"Rocket landed at position: {moonPosition}");
        Time.timeScale = 0f;
    }
}
