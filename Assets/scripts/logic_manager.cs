using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class logic_manager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI score_text;
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
