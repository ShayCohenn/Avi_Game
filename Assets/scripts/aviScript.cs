using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.linearVelocity = Vector2.up * speed;
        }
    }
}
