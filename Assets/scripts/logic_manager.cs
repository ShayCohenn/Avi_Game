using UnityEngine;
using UnityEngine.UI;

public class logic_manager : MonoBehaviour
{
    public int score;
    public Text score_text;

    public void inc_score()
    {
        score++;
        score_text.text = score.ToString();
    }
}
