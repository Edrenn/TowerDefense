using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        FindObjectOfType<MusicManager>().LaunchMenuSong();
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }
}
