using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // Class variables
    public Text CounterText;

    [SerializeField] GameObject player;
    [SerializeField] int pointsValue;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        // Add score and update UI
        gameManager.IncrementScore(pointsValue);
        // Reset player
        player.GetComponent<PlayerController>().ResetPlayer();
        // Stop player gravity and reallow to drop
        other.attachedRigidbody.useGravity = false;
        gameManager.canDrop = true;
        // Reset player velocity and angular velocity
        other.attachedRigidbody.velocity = Vector3.zero;
        other.attachedRigidbody.angularVelocity = Vector3.zero;
        // Reset player position to spawn point
        other.transform.position = gameManager.spawnPos;

        // Check if game is over
        if (gameManager.drops == 0)
        {
            gameManager.GameOver();
        }
    }
}
