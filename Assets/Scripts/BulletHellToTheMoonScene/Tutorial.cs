using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour {
    [Header("UI References")]
    public GameObject moveText;   // "WASD to move"
    public GameObject fireText;   // "Spacebar to fire"

    [Header("Game References")]
    public GameObject enemySpawner;
    public GameObject moon;

    private bool tutorialDone = false;

    void Start() {
        // Validate references
        if (!ValidateReferences()) return;

        // Hide enemies & moon at the start
        enemySpawner.SetActive(false);
        moon.SetActive(false);

        // Start tutorial
        StartCoroutine(RunTutorial());
    }

    private System.Collections.IEnumerator RunTutorial() {
        // Step 1: Show move instructions
        ShowInstruction(moveText);
        yield return new WaitUntil(() => IsMovementKeyPressed());
        HideInstruction(moveText);

        // Step 2: Show fire instructions
        ShowInstruction(fireText);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        HideInstruction(fireText);

        // Tutorial done - enable gameplay
        tutorialDone = true;
        EnableGameplay();
    }

    private void ShowInstruction(GameObject instruction) {
        if (instruction != null) {
            instruction.SetActive(true);
        }
    }

    private void HideInstruction(GameObject instruction) {
        if (instruction != null) {
            instruction.SetActive(false);
        }
    }

    private bool IsMovementKeyPressed() {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
               Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    private void EnableGameplay() {
        if (enemySpawner != null) enemySpawner.SetActive(true);
        if (moon != null) moon.SetActive(true);
    }

    private bool ValidateReferences() {
        if (moveText == null) {
            Debug.LogError("TutorialManager: MoveText is not assigned in the Inspector!");
            return false;
        }
        if (fireText == null) {
            Debug.LogError("TutorialManager: FireText is not assigned in the Inspector!");
            return false;
        }
        if (enemySpawner == null) {
            Debug.LogError("TutorialManager: EnemySpawner is not assigned in the Inspector!");
            return false;
        }
        if (moon == null) {
            Debug.LogError("TutorialManager: Moon is not assigned in the Inspector!");
            return false;
        }
        return true;
    }
}
