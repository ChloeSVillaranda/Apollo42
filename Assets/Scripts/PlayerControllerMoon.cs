using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMoon : MonoBehaviour {
    public float moveSpeed = 10.0f; // Corrected variable name
    private Vector3 moveDir;
    private Rigidbody rb; // Cache the Rigidbody reference

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>(); // Cache the Rigidbody component
    }

    // Update is called once per frame
    void Update() {
        // Get WASD input and normalize the direction
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate() {
        // Move the player using Rigidbody
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.fixedDeltaTime);
    }
}
