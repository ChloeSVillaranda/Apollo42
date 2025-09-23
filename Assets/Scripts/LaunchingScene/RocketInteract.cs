using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RocketInteract : MonoBehaviour {
    public GameObject interactText;
    private bool playerInRange = false;

    void Start() {
        if (interactText != null) {
            interactText.SetActive(false); // hide at start
        }
    }

    void Update() {
        if (playerInRange && Input.GetKeyDown(KeyCode.F)) {
            // Add mount logic here
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (interactText != null) {
                interactText.SetActive(true);
            }
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (interactText != null) {
                interactText.SetActive(false);
            }
            playerInRange = false;
        }
    }
}
