using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSpawner : MonoBehaviour {
    public GameObject moonPrefab;
    public float spawnY = 50f;
    public float scrollSpeed = 2f;
    private bool moonSpawned = false;

    private GameObject spawnedMoon;

    void Update() {
        // Spawn the moon if it hasn't been spawned yet
        if (!moonSpawned) {
            Vector2 moonPos = new Vector2(0, spawnY);
            spawnedMoon = Instantiate(moonPrefab, moonPos, Quaternion.identity); // Assign the spawned moon to the variable
            moonSpawned = true;
        }

        // Move the spawned moon downward
        if (spawnedMoon != null) {
            spawnedMoon.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        }
    }
}
