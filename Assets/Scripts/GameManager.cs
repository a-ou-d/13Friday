using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;        
    private int life;

    public GameObject PauseMenu;
    public GameObject SettingMenu;
    public Text timeText;
    private bool isGamePaused = false;
    private bool isPaused = false;
    float limit = 0f;

    public Text scoreText;
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
        timeText.text = limit.ToString("N2");
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    public void OnPauseButtonClicked()
    {
        // 버튼 클릭 시 일시정지 토글
        TogglePause();
    }
    public void OnSettingButtonClicked()
    {
        // 버튼 클릭 시 일시정지 토글
        ToggleSetting();
    }

    public void OnContinueButtonClicked()
    {
        // 계속하기 버튼 클릭 시 게임 재개
        ResumeGame();
    }   

    void TogglePause()
    {
        // 일시정지 상태 전환
        isPaused = !isPaused;

        // 일시정지 시 일시정지 메뉴 활성화
        PauseMenu.SetActive(true);

        if (isGamePaused)
        {
            // 게임 재개
            Time.timeScale = 1f;
        }
        else
        {
            // 게임 일시정지
            Time.timeScale = 0f;
        }

        // isGamePaused의 값을 토글(toggle)하는 코드
        isGamePaused = !isGamePaused;
    }

    void ToggleSetting()
    {        
        isPaused = !isPaused;
        
        SettingMenu.SetActive(true);

        if (isGamePaused)
        {            
            Time.timeScale = 1f;
        }
        else
        {            
            Time.timeScale = 0f;
        }
                
        isGamePaused = !isGamePaused;
    }

    void ResumeGame()
    {
        // 일시정지 메뉴 비활성화
        PauseMenu.SetActive(false);
        SettingMenu.SetActive(false);

        if (isGamePaused)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }

        isGamePaused = !isGamePaused;
    }

    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    private void GameOver()
    {
        // 게임 오버 시의 처리
        Debug.Log("Game Over");
    }
}
