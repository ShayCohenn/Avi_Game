using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logic_manager : MonoBehaviour
{
    public int score;
    public Text score_text;
    public GameObject gameover_screen;

    public void inc_score(int amount)
    {
        score += amount;
        score_text.text = score.ToString();
    }

    public void restart_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameover()
    {
        gameover_screen.SetActive(true);            
    }

}
