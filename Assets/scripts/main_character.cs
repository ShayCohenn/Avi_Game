using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public logic_manager logic;
    private bool is_player_alive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(is_player_alive && Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;
            if(touch.press.wasPressedThisFrame)
            {
                rb.linearVelocity = Vector2.up * speed;
            }
        }
        if(is_player_alive && (transform.position.y > 45 || transform.position.y < -45))
            end_game();
    }

    private void end_game()
    {
        is_player_alive = false;
        logic.gameover();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        end_game();
    }
}
