using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] Image[] skullScoreTab;
    public  void SetSkullScore(int score)
    {
        for (int i = 0; i < score; i++)
        {
            skullScoreTab[i].color = Color.white;
        }
    }
}
