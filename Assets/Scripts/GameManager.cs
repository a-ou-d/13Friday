using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int destroyObjectCount = 0;
    public Text kill;

    public GameObject JasonPrefab;
    public GameObject SadakoPrefab;
    public GameObject PennywisePrefab;
    public GameObject JigsawPrefab;
    [SerializeField]private int Life = 3;
    public float speed;
    public int IncreaseDamage;

    public GameObject EnemySpawn;
    public GameObject PauseMenu;
    public GameObject SettingMenu;

    private bool isPaused = false;

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
        GameObject jason = Instantiate(JasonPrefab, Vector3.zero, Quaternion.identity);
        PlayerController jasonController = jason.GetComponent<PlayerController>();
        ICharacterSkills jasonSkills = jason.GetComponent<Jason>();
        jasonController.SetCharacterSkills(jasonSkills);

        //쏘우 게임매니저에서 생성 및 스킬 입력
        //GameObject Jigsaw = Instantiate(JigsawPrefab, Vector3.zero, Quaternion.identity);
        //PlayerController sawController = Jigsaw.GetComponent<PlayerController>();
        //ICharacterSkills sawSkills = Jigsaw.GetComponent<Jigsaw>();
        //sawController.SetCharacterSkills(sawSkills);

        GameObject enemySpawn = Instantiate(EnemySpawn, Vector3.zero, Quaternion.identity);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

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

    public static void ObjectDestroyed()
    {
        Instance.destroyObjectCount++;
        Instance.KillCount();
    }

    private void KillCount()
    {
        if (kill != null)
        {
            kill.text = destroyObjectCount.ToString();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    public void OnPauseButtonClicked()
    {
        TogglePause();
    }

    public void OnSettingButtonClicked()
    {
        ToggleSetting();
    }

    public void OnContinueButtonClicked()
    {
        ResumeGame();
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);        
    }

    void ToggleSetting()
    {
        isPaused = !isPaused;
        SettingMenu.SetActive(isPaused);        
    }

    void ResumeGame()
    {
        PauseMenu.SetActive(false);
        SettingMenu.SetActive(false);
        isPaused = false;
    }

    private void GameOver()
    {
        // 게임 오버 시의 처리
        SceneManager.LoadScene("DieScene");
        Debug.Log("Game Over");
    }

    public void Heal(int amount)
    {
        //포션 먹으면 회복
        Life += amount;
        Debug.Log(Life);
    }

    public void SpeedUp(float amount)
    {
        //포션 먹으면 속도 증가
        speed += amount;
        Debug.Log(speed);
    }
    public void DamageUp(int amount)
    {
        //포션 먹으면 속도 증가
        IncreaseDamage += amount;
        Debug.Log(IncreaseDamage);
    }
}
