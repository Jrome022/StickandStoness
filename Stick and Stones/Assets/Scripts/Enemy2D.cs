using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    // Reference to the player game object
    public Transform player;

    // Enemy movement speed
    public float speed = 2.0f;

    // Enemy attack range
    public float attackRange = 1.0f;

    // Enemy attack damage
    public int damage = 10;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Calculate the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        rb.velocity = direction * speed;

        }
}