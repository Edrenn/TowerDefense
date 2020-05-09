using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public const string MUSICVOLUME_KEY = "music_volume";
    public const string SOUNDVOLUME_KEY = "sound_volume";

    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundVolumeSlider;

    private void Start()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSICVOLUME_KEY);

        soundVolumeSlider.value = PlayerPrefs.GetFloat(SOUNDVOLUME_KEY);
    }

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat(MUSICVOLUME_KEY, musicVolumeSlider.value);
        PlayerPrefs.SetFloat(SOUNDVOLUME_KEY, soundVolumeSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void ResetSave()
    {
        SaveSystem.ResetSave();
        FindObjectOfType<LevelLoader>().ReloadGame();
    }
}
