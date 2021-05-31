using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;
    [SerializeField] int objAlive = 0;
    [SerializeField] int scoreToAdd = 0;
    [SerializeField] private TextMeshProUGUI UIScore;
    [SerializeField] private TextMeshProUGUI UIEnemies;
    [SerializeField] private TextMeshProUGUI UIExtras;
    [SerializeField] private Image UIHealth;
    [SerializeField] private GameObject PauseMenuUI;
    [SerializeField] private GameObject QuitMenuUI;
    [SerializeField] private GameObject GameOverMenuUI;

    private static bool pause = false;
    private static LevelManager _instanceLevelManager;
    private const int minLives = 1;
    public static LevelManager Get()
    {
        return _instanceLevelManager;
    }
    private void Awake()
    {
        if (_instanceLevelManager == null)
        {
            _instanceLevelManager = this;
        }
        else if (_instanceLevelManager != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetTimeScale(1);
        UIHealth.fillAmount = 1;
        UIEnemies.text = ("Left: " + objAlive);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && lives > 0)
        {
            SetPause();
        }

    }
    public void StartObj()
    {
        objAlive++;
        UIEnemies.text = ("Left: " + objAlive);
    }
    public void UpdateObj()
    {
        objAlive--;
        UIEnemies.text = ("Left: " + objAlive);
        if(objAlive<=0)
        {
            GameOver();
        }
    }
    public void UpdateScore()
    {
        score += scoreToAdd;
        UIScore.text = ("Score: " + score);
    }
    public void UpdateLives()
    {
        lives--;
        UIHealth.fillAmount -= 0.34f;
        if(lives< minLives)
        {
            GameOver();
        }
    }
    private void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
    private void GameOver()
    {
        SetTimeScale(0);
        GameOverMenuUI.SetActive(true);
    }
    public void SetPause()
    {
        pause = !pause;
        if (pause)
        {
            SetTimeScale(0);
            PauseMenuUI.SetActive(pause);
        }
        else
        {
            SetTimeScale(1);
            PauseMenuUI.SetActive(pause);
            QuitMenuUI.SetActive(pause);
        }
    }
}
