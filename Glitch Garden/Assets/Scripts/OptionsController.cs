using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class OptionsController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defualtVolume = 0.5f;


    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
        Debug.Log(difficultySlider.value);

    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("no music found");
        }
    }


    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<Level>().LoadMainMain();
    }
    public void Defualts()
    {
        volumeSlider.value = defualtVolume;
        difficultySlider.value = defaultDifficulty;

    }
}
