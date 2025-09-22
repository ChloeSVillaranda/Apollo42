using System.Collections;
using System.Collections.Generic;
using TMPro; // Use TextMeshPro namespace
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    public TMP_Text scoreText;
    private int score = 0;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points) {
        score += points;
        scoreText.text = "Score: " + score.ToString(); // Update the score text
    }
}
