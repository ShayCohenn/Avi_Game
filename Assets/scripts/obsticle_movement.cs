using UnityEngine;

public class obsticle_movement : MonoBehaviour
{
    public logic_manager logic;
    public float move_speed = 5;
    public int dead_zone = -40;
    
    void Update()
    {
        transform.position = transform.position + (Vector3.left * move_speed * Time.deltaTime);
        if (transform.position.x < dead_zone) Destroy(gameObject);
    }
}
