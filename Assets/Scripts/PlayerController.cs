using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Class variables
    [SerializeField] Rigidbody rb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && gameManager.canDrop && gameManager.hasGameStarted)
        {
            rb.useGravity = true;
            gameManager.canDrop = false;
            gameManager.DecrementDrops();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameManager.hasGameStarted)
        {
            gameManager.PauseGame();
        }
    }

    public void ResetPlayer()
    {
        // Stop player gravity and reallow to drop
        rb.useGravity = false;
        gameManager.canDrop = true;
        // Reset player velocity and angular velocity
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // Reset player position to spawn point
        transform.position = gameManager.spawnPos;
    }
}
