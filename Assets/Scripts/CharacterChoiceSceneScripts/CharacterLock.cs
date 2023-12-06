using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLock : MonoBehaviour // 캐릭터 잠금 상태 관리
{
    public const string UnlockKey = "CharacterUnlocked_";

    public static bool IsCharacterUnlocked(string characterName)
    {
        return PlayerPrefs.GetInt(UnlockKey + characterName, 0) == 1;
    }

    public static void UnlockCharacter(string characterName)
    {
        PlayerPrefs.SetInt(UnlockKey + characterName, 1);
        PlayerPrefs.Save();
    }
}