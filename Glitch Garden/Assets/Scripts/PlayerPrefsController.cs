using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master valume";
    const string DIFFICULT_KEY = "difficulty";


    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;


    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;


    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }


        else
        {
            Debug.LogError("master volume is out of range");
        }
    }


    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }


    public static void SetDifficulty(float difficult)
    {
        if (difficult >= MIN_DIFFICULTY && difficult <= MAX_DIFFICULTY)
        {
            Debug.Log("difficulty set to " + difficult);
            PlayerPrefs.SetFloat(DIFFICULT_KEY, difficult);
        }


        else
        {
            Debug.LogError("Difficult is out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULT_KEY);
    }
}