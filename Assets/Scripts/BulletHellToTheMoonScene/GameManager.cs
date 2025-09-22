using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public GameObject gameOverPanel;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void GameOver() {
        Time.timeScale = 0f; // pause game
        gameOverPanel.SetActive(true);
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}
