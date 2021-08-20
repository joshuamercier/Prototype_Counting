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

    private void Start()
    {
        gameManager.score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.score += pointsValue;
        CounterText.text = "Score : " + gameManager.score;
        Destroy(other);
    }
}
