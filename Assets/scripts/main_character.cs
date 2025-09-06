using UnityEngine;

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
        if(is_player_alive && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.linearVelocity = Vector2.up * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_player_alive = false;
        logic.gameover();
    }
}
