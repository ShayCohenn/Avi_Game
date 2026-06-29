using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float flapSpeed = 30f;
    [SerializeField] private TextMeshProUGUI countdownTxt;
    private Rigidbody2D rb;
    public logic_manager logic;
    private bool isPlayerAlive = true;
    private bool isInteractable = false; 
    private int startDelay = 3; // measured in seconds 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic_manager>();
        StartCoroutine(StartGracePeriod());
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerAlive && Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;
            if(isInteractable && touch.press.wasPressedThisFrame)
            {
                Flap();
            }
        }
        if(isPlayerAlive && (transform.position.y > 45 || transform.position.y < -45))
            end_game();
    }

    private void Flap()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, flapSpeed);
    }

    private void end_game()
    {
        isPlayerAlive = false;
        logic.gameover();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        end_game();
    }

    private IEnumerator StartGracePeriod()
    {
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        isInteractable = false;

        while(startDelay > 0)
        {
            countdownTxt.text = startDelay.ToString();
            yield return new WaitForSeconds(1f);
            startDelay--;
        }

        countdownTxt.text = "YALLA!";

        rb.gravityScale = originalGravity;
        isInteractable = true;

        yield return new WaitForSeconds(1f);
        countdownTxt.gameObject.SetActive(false);
    }
}
