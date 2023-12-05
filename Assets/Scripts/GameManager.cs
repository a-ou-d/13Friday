using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject JasonPrefab;
    public GameObject SadakoPrefab;
    public GameObject PennywisePrefab;
    public GameObject SawPrefab;
    private int Life;

    private void Start()
    {

    }
    private void Awake()
    {
        GameObject sadako = Instantiate(SadakoPrefab, Vector3.zero, Quaternion.identity);
        PlayerController sadakoController = sadako.GetComponent<PlayerController>();
        ICharacterSkills sadakoSkills = sadako.GetComponent<ICharacterSkills>();
        sadakoController.SetCharacterSkills(sadakoSkills);
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

    private void GameOver()
    {
        // 게임 오버 시의 처리
        Debug.Log("Game Over");
    }
}
