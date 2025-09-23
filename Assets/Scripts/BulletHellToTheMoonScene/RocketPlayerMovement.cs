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
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Movement input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        // Shooting
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime) {
            nextFireTime = Time.time + fireRate; // Set the next allowed fire time
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
