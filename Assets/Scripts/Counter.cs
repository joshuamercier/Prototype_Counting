using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // Class variables
    public Text CounterText;

    [SerializeField] int pointsValue;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject ball;

    private void Start()
    {
        gameManager.score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Increment score by value
        gameManager.score += pointsValue;
        // Update UI
        CounterText.text = "Score : " + gameManager.score;
        // Stop player gravity and reallow to drop
        other.attachedRigidbody.useGravity = false;
        gameManager.canDrop = true;
        // Reset player velocity and angular velocity
        other.attachedRigidbody.velocity = Vector3.zero;
        other.attachedRigidbody.angularVelocity = Vector3.zero;
        // Reset player position to spawn point
        other.transform.position = gameManager.spawnPos;
    }
}
