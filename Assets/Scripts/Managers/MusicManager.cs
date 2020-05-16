using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource currentAudioSource;
    [SerializeField] AudioClip menuSong;
    [SerializeField] AudioClip gameSong;
    [SerializeField] AudioClip endSong;
    [SerializeField] AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
        if (MusicManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
            currentAudioSource = GetComponent<AudioSource>();
            LaunchMenuSong();
            currentAudioSource.volume = PlayerPrefs.GetFloat(OptionManager.MUSICVOLUME_KEY);
        }

    }

    public void LaunchMenuSong()
    {
        currentAudioSource.clip = menuSong;
        currentAudioSource.Play();
        currentAudioSource.loop = true;
    }

    public void LaunchGameSong()
    {
        currentAudioSource.clip = gameSong;
        currentAudioSource.Play();
        currentAudioSource.loop = true;
    }

    public void LaunchWinSong()
    {
        currentAudioSource.loop = false;
        currentAudioSource.clip = winSound;
        currentAudioSource.Play();
    }

    public void LaunchEndSong()
    {
        currentAudioSource.loop = true;
        currentAudioSource.clip = endSong;
        currentAudioSource.Play();
    }
}
