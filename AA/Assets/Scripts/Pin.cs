﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    private bool isPinned = false;

    private void Update()
    {
        if(!isPinned)
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
        // The above function allows us to move the rigidbody while still checking for physics
        // A lot better to use than transform.translate because it won't work well with collisions
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Rotator"))
        {
            this.transform.SetParent(collision.transform);
            
            // To flip the direction every time a pin is fired
            // collision.GetComponent<Rotator>().speed *= -1;

            // To increase the speed every time a pin is fired
            // collision.GetComponent<Rotator>().speed += 5f;
            isPinned = true;
        } else if (collision.CompareTag("Pin"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
