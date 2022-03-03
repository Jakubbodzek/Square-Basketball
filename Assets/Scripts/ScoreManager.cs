using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerScore;
    private int score = 0;

    public void Start()
    {
        playerScore.text = "Score: 0";
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            playerScore.text = "Score: " + ++score;
        }
    }
}
