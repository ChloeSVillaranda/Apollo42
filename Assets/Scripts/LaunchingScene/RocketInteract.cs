using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RocketInteract : MonoBehaviour {
    public GameObject interactText;
    private bool playerInRange = false;

    public AudioSource rocketCountdownAudio; // First audio
    public AudioSource rocketLaunchSE; // Second audio

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
        } else {
            Debug.LogError("RocketInteract: secondAudio is not assigned!");
        }
    }
}
