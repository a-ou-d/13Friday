using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject JasonPrefab;
    public GameObject SadakoPrefab;
    public GameObject PennywisePrefab;
    public GameObject SawPrefab;
    public GameObject EnemySpawn;
    private int Life;

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
        //사다코 게임매니저에서 생성 및 스킬 입력
        //GameObject sadako = Instantiate(SadakoPrefab, Vector3.zero, Quaternion.identity);
        //PlayerController sadakoController = sadako.GetComponent<PlayerController>();
        //ICharacterSkills sadakoSkills = sadako.GetComponent<Sadako>();
        //sadakoController.SetCharacterSkills(sadakoSkills);
        
        //패니와이저 게임매니저에서 생성 및 스킬 입력
        //GameObject pennywise = Instantiate(PennywisePrefab, Vector3.zero, Quaternion.identity);
        //PlayerController pennywiseController = pennywise.GetComponent<PlayerController>();
        //ICharacterSkills pennywiseSkills = pennywise.GetComponent<Pennywise>();
        //pennywiseController.SetCharacterSkills(pennywiseSkills);

        //제이슨 게임매니저에서 생성 및 스킬 입력
        //GameObject jason = Instantiate(JasonPrefab, Vector3.zero, Quaternion.identity);
        //PlayerController jasonController = jason.GetComponent<PlayerController>();
        //ICharacterSkills jasonSkills = jason.GetComponent<Jason>();
        //jasonController.SetCharacterSkills(jasonSkills);

        //쏘우 게임매니저에서 생성 및 스킬 입력
        GameObject saw = Instantiate(SawPrefab, Vector3.zero, Quaternion.identity);
        PlayerController sawController = saw.GetComponent<PlayerController>();
        ICharacterSkills sawSkills = saw.GetComponent<Saw>();
        sawController.SetCharacterSkills(sawSkills);

        GameObject enemySpawn = Instantiate(EnemySpawn, Vector3.zero, Quaternion.identity);

        if (Instance == null)
        {

            Life = 3;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DecreaseLife(int amount)
    {
        Life -= amount;

        if (Life <= 0)
        {
            //라이프가 0이하가 됬을시 게임오버씬 부르기
            GameOver();
        }
    }

    void Update()
    {
        limit += Time.deltaTime;
        //timeText.text = limit.ToString("N2");
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
        // 일시정지, 셋팅 메뉴 비활성화
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
