using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketInteraction : MonoBehaviour {
    [Header("UI Elements")]
    public GameObject interactText; // Text prompting the player to press a key
    public GameObject overlayUI; // The overlay UI with buttons
    public Button backToEarthButton; // Button to go back to Earth
    public Button viewCreditsButton; // Button to view credits

    private bool playerInRange = false;

    void Start() {
        // Ensure the overlay and interaction text are hidden at the start
        if (overlayUI != null) {
            overlayUI.SetActive(false);
        } else {
            Debug.LogError("RocketInteract: overlayUI is not assigned in the Inspector!");
        }

        if (interactText != null) {
            interactText.SetActive(false);
        } else {
            Debug.LogError("RocketInteract: interactText is not assigned in the Inspector!");
        }

        // Assign button click events
        if (backToEarthButton != null) {
            backToEarthButton.onClick.AddListener(GoBackToEarth);
        } else {
            Debug.LogError("RocketInteract: backToEarthButton is not assigned in the Inspector!");
        }

        if (viewCreditsButton != null) {
            viewCreditsButton.onClick.AddListener(ViewCredits);
        } else {
            Debug.LogError("RocketInteract: viewCreditsButton is not assigned in the Inspector!");
        }
    }

    void Update() {
        // Show the overlay when the player presses F
        if (playerInRange && Input.GetKeyDown(KeyCode.F)) {
            ShowOverlay();
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"RocketInteraction: Object entered trigger - {other.name}");
        if (other.CompareTag("Player")) {
            if (interactText != null) {
                interactText.SetActive(true); // Show "Press 'F' to interact"
            }
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log($"RocketInteraction: Object exited trigger - {other.name}");
        if (other.CompareTag("Player")) {
            if (interactText != null) {
                interactText.SetActive(false); // Hide "Press 'F' to interact"
            }
            playerInRange = false;
        }
    }
    private void ShowOverlay() {
        if (overlayUI != null) {
            Debug.Log("RocketInteraction: Showing overlay UI.");
            overlayUI.SetActive(true); // Show the overlay UI
        } else {
            Debug.LogError("RocketInteraction: overlayUI is not assigned!");
        }
    }

    private void GoBackToEarth() {
        Debug.Log("RocketInteract: Go back to Earth selected.");
        SceneManager.LoadScene("EarthScene"); // Replace with the actual Earth scene name
    }

    private void ViewCredits() {
        Debug.Log("RocketInteract: View Credits selected.");
        SceneManager.LoadScene("CreditsScene"); // Replace with the actual Credits scene name
    }
}
