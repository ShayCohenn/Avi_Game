using UnityEngine;

public class obsticle_spawner : MonoBehaviour
{
    public GameObject obsticle;
    public float spawn_rate = 2;
    public float height_offset = 10;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawn_rate) timer += Time.deltaTime;
        else
        {
            spawn_obsticle();
            timer = 0;
        }
    }

    void spawn_obsticle()
    {
        float low_point = transform.position.y - height_offset;
        float high_point = transform.position.y + height_offset;

        Instantiate(obsticle, new Vector3(transform.position.x, Random.Range(low_point, high_point), 0), transform.rotation);
    }
}
