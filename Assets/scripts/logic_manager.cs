using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class logic_manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI ScoreText;
    [SerializeField] private  GameObject _gameoverScreen;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private TextMeshProUGUI FinalScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    private bool isPaused = false;

    public void incScore(int amount)
    {
        score += amount;
        ScoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void homeScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
    }

    public void gameover()
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save(); 
            currentHighScore = score;
        }

        if(FinalScoreText != null)
        {
            FinalScoreText.text = score.ToString();
        }

        if (HighScoreText != null)
        {
            HighScoreText.text = currentHighScore.ToString();
        }
        _gameoverScreen.SetActive(true);       
    }

    public void togglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            _pauseMenuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            _pauseMenuPanel.SetActive(false);
        }
    }

}
