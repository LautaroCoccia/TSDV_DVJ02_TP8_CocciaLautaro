using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscore;
    int i = 0;
    public void UpdateHighscore()
    {
        i = SaveSystem.LoadHighscoreFile();
        highscore.text = ("" + i);
    }
}
