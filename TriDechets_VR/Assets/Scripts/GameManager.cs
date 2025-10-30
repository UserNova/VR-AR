using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro; // si tu utilises TextMeshPro, sinon change en UnityEngine.UI

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        // Rendre le GameManager accessible depuis d'autres scripts
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void SubtractScore(int amount)
    {
        score -= amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score;
        }
    }
}
