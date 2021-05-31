using UnityEngine.SceneManagement;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    int Highscore = 0;
    private static GameManager _instanceGameManager;
    public static GameManager Get()
    {
        return _instanceGameManager;
    }
    private void Awake()
    {
        if (_instanceGameManager == null)
        {
            _instanceGameManager = this;
        }
        else if (_instanceGameManager != this)
        {
            Destroy(gameObject);
        }
        SaveSystem.CreateHighscoreFile();
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
    public int GetHighscore()
    {
        Highscore = SaveSystem.LoadHighscoreFile();
        return Highscore;
    }
    public void UpdateHighscore(int score)
    {
        SaveSystem.SaveHighscore(score);
    }
}