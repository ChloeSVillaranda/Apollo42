using UnityEngine;

public class RocketHealth : MonoBehaviour {
    public int maxHealth = 3;
    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
        UIManager.Instance.UpdateHealth(currentHealth);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        UIManager.Instance.UpdateHealth(currentHealth);

        if (currentHealth <= 0) {
            GameManager.Instance.GameOver();
        }
    }
}
