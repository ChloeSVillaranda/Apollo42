using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    public static UIManager Instance;

    public TMP_Text healthText;
    public TMP_Text scoreText;

    private int score = 0;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpdateHealth(int health) {
        healthText.text = "Health: " + health;
    }

    public void AddScore(int points) {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
