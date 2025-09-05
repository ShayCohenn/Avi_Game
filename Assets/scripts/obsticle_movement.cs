using UnityEngine;

public class obsticle_movement : MonoBehaviour
{
    public float move_speed = 5;
    public int dead_zone = -30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * move_speed * Time.deltaTime);
        if (transform.position.x < dead_zone) Destroy(gameObject);
    }
}
