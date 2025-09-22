using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveInput.x, moveInput.y).normalized; // Fixed line
    }

    void FixedUpdate() {
        // Apply movement in physics step
        rb.velocity = moveInput * moveSpeed;

        // Keep the rocket locked on Z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }
}
