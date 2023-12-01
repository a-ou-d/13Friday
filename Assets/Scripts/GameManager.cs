using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text timeText;
    public Text scoreText;
    private int life;
    float limit = 0f;
    int totalScore;

    private void Awake()
    {
        if (Instance == null)
        {
            
            
            life = 3;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DecreaseLife(int amount)
    {
        life -= amount;

        if (life <= 0)
        {
            //라이프가 0이하가 됬을시 게임오버씬 부르기
            GameOver();
        }
    }

    void Update()
    {
        limit += Time.deltaTime;
        timeText.text = limit.ToString();
    }

    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString("N2");
    }

    private void GameOver()
    {
        // 게임 오버 시의 처리
        Debug.Log("Game Over");
    }
}
