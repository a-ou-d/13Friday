using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject JasonPrefab;
    public GameObject SadakoPrefab;
    public GameObject PennywisePrefab;
    public GameObject JigsawPrefab;
    [SerializeField]private int Life = 3;

    public GameObject EnemySpawn;
    public GameObject PauseMenu;
    public GameObject SettingMenu;

    public Text timeText;
    float limit = 0f;

    private bool isGamePaused = false;
    private bool isPaused = false;    

    public Text kill;

    private void Awake()
    {
        GameManager.Instance = this;    

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
        GameObject Jigsaw = Instantiate(JigsawPrefab, Vector3.zero, Quaternion.identity);
        PlayerController sawController = Jigsaw.GetComponent<PlayerController>();
        ICharacterSkills sawSkills = Jigsaw.GetComponent<Saw>();
        sawController.SetCharacterSkills(sawSkills);

        GameObject enemySpawn = Instantiate(EnemySpawn, Vector3.zero, Quaternion.identity);

    }

    private void Start()
    {
        PlayerPrefs.SetInt(CharacterLock.UnlockKey + "Sadako", 0);
        PlayerPrefs.SetInt(CharacterLock.UnlockKey + "Pennywise", 0);
        PlayerPrefs.SetInt(CharacterLock.UnlockKey + "Jigsaw", 0);
        PlayerPrefs.Save();
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
        timeText.text = limit.ToString("N2");
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
        Debug.Log("1");
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
        PauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            // 게임 일시정지
            Time.timeScale = 0f;
        }
        else
        {
            // 게임 재개
            Time.timeScale = 1f;
        }
    }

    void ToggleSetting()
    {        
        isPaused = !isPaused;
        
        SettingMenu.SetActive(isPaused);

        if (isPaused)
        {            
            Time.timeScale = 0f;
        }
        else
        {            
            Time.timeScale = 1f;
        }
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

    private void GameOver()
    {
        // 게임 오버 시의 처리
        SceneManager.LoadScene("DieScene");
        Debug.Log("Game Over");
    }
}
