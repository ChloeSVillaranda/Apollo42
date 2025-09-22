using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPlayerMovement : MonoBehaviour {
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Movement input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        // Shooting
        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
    }

    void FixedUpdate() {
        // Apply movement
        rb.velocity = moveInput * moveSpeed;

        // Lock Z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
