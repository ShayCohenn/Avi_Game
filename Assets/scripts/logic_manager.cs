using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class logic_manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI ScoreText;
    [SerializeField] private  GameObject _gameoverScreen;
    [SerializeField] private GameObject _pauseMenuPanel;
    private bool isPaused = false;

    public void incScore(int amount)
    {
        score += amount;
        ScoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameover()
    {
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
