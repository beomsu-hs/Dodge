using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text scoreText;
    public Text recordText;
    public Text difficultyText;

    private float surviveTime;
    private float scoreUpdateTime;
    private int score;
    private bool isGameover;

    private string difficulty;

    void Start()
    {
        surviveTime = 0;
        scoreUpdateTime = 0;
        score = 0;
        isGameover = false;
        difficulty = "Eazy"; // 시작 난이도
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            scoreUpdateTime += Time.deltaTime;

            // 난이도 증가
            if (surviveTime >= 10f && difficulty == "Eazy") IncreaseDifficulty();
            else if (surviveTime >= 20f && difficulty == "Normal") IncreaseDifficulty();

            // 점수 증가: 1초마다 점수 추가
            if (scoreUpdateTime >= 1f)
            {
                int scoreIncrement = GetScoreIncrement();
                score += scoreIncrement;
                scoreUpdateTime = 0f;
            }

            scoreText.text = "Score: " + score;
            difficultyText.text = difficulty + " mode";
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void IncreaseDifficulty()
    {
        if (difficulty == "Eazy")
        {
            difficulty = "Normal";
        }
        else if (difficulty == "Normal")
        {
            difficulty = "Hard";
        }
    }

    int GetScoreIncrement()
    {
        if (difficulty == "Eazy") return 1;
        if (difficulty == "Normal") return 2;
        if (difficulty == "Hard") return 3;
        return 0;
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore");
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
        recordText.text = "Best Score: " + bestScore;
    }
}
