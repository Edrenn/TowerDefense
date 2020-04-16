using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;

    public void SetInteractable(bool isInteractable)
    {
        GetComponent<Button>().interactable = isInteractable;
    }
}
