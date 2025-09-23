using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For scene loading
using TMPro;

public class RocketInteract : MonoBehaviour {
    public GameObject interactText;
    private bool playerInRange = false;

    public AudioSource rocketCountdownAudio; // First audio
    public AudioSource rocketLaunchSE; // Second audio

    public Image fadeOverlay; // UI Image for fading to black
    public float fadeDuration = 2f; // Duration of the fade effect
    public string nextSceneName; // Name of the next scene to load

    private bool hasLaunched = false; // To ensure the launch happens only once

    void Start() {
        if (interactText != null) {
            interactText.SetActive(false); // Hide at start
            Debug.Log("RocketInteract: interactText successfully hidden at start.");
        } else {
            Debug.LogError("RocketInteract: interactText is not assigned in the Inspector!");
        }

        if (rocketCountdownAudio != null) {
            rocketCountdownAudio.enabled = false;
            Debug.Log("RocketInteract: rocketLaunchAudio is disabled at start.");
        } else {
            Debug.LogError("RocketInteract: rocketLaunchAudio is not assigned in the Inspector!");
        }

        if (rocketLaunchSE != null) {
            rocketLaunchSE.enabled = false;
            Debug.Log("RocketInteract: secondAudio is disabled at start.");
        } else {
            Debug.LogError("RocketInteract: secondAudio is not assigned in the Inspector!");
        }

        if (fadeOverlay != null) {
            fadeOverlay.color = new Color(0, 0, 0, 0); // Ensure the overlay is fully transparent at the start
        } else {
            Debug.LogError("RocketInteract: fadeOverlay is not assigned in the Inspector!");
        }
    }

    void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.F) && !hasLaunched) {
            Debug.Log("RocketInteract: Player pressed F to start the rocket launch.");
            StartRocketLaunch();
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"RocketInteract: OnTriggerEnter called with {other.gameObject.name}.");
        if (other.CompareTag("Player")) {
            Debug.Log("RocketInteract: Player entered the trigger zone.");
            if (interactText != null) {
                interactText.SetActive(true);
                Debug.Log("RocketInteract: interactText set to active.");
            }
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log($"RocketInteract: OnTriggerExit called with {other.gameObject.name}.");
        if (other.CompareTag("Player")) {
            Debug.Log("RocketInteract: Player exited the trigger zone.");
            if (interactText != null) {
                interactText.SetActive(false);
                Debug.Log("RocketInteract: interactText set to inactive.");
            }
            playerInRange = false;
        }
    }

    private void StartRocketLaunch() {
        if (rocketCountdownAudio != null) {
            rocketCountdownAudio.enabled = true; // Enable the AudioSource
            rocketCountdownAudio.Play(); // Play the rocket launch audio
            Debug.Log("RocketInteract: Rocket launch audio started playing.");

            // Schedule the second audio to play after the first audio finishes
            Invoke(nameof(PlaySecondAudio), rocketCountdownAudio.clip.length);
        } else {
            Debug.LogError("RocketInteract: rocketLaunchAudio is not assigned!");
        }

        hasLaunched = true; // Ensure the launch happens only once
    }

    private void PlaySecondAudio() {
        if (rocketLaunchSE != null) {
            rocketLaunchSE.enabled = true; // Enable the second AudioSource
            rocketLaunchSE.Play(); // Play the second audio
            Debug.Log("RocketInteract: Second audio started playing.");

            // Schedule the fade to black and scene transition after the second audio finishes
            Invoke(nameof(FadeToBlackAndLoadScene), rocketLaunchSE.clip.length);
        } else {
            Debug.LogError("RocketInteract: secondAudio is not assigned!");
        }
    }

    private void FadeToBlackAndLoadScene() {
        if (fadeOverlay != null) {
            StartCoroutine(FadeToBlack());
        } else {
            Debug.LogError("RocketInteract: fadeOverlay is not assigned!");
        }
    }

    private System.Collections.IEnumerator FadeToBlack() {
        Debug.Log("RocketInteract: Starting fade to black.");
        float elapsedTime = 0f;

        // Gradually increase the alpha value of the fade overlay
        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            fadeOverlay.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        Debug.Log("RocketInteract: Fade to black complete. Loading next scene.");
        SceneManager.LoadScene(nextSceneName); // Load the next scene
    }
}
