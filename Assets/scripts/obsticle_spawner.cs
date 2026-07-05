using UnityEngine;

public class obsticle_spawner : MonoBehaviour
{
    public logic_manager logic;
    public GameObject obsticle;
    [SerializeField] private float spawn_rate = 3;
    [SerializeField] private float height_offset = 10;
    private float timer = 0;
    private int lastMilestoneScore = 0;

    // Update is called once per frame
    void Update()
    {
        if (logic.score > 0 && logic.score % 20 == 0 && logic.score != lastMilestoneScore)
    {
        spawn_rate -= 0.1f; // Decrease the delay between spawns
        lastMilestoneScore = logic.score; // Record this milestone so it only fires once
        
        // Safety check: Prevent spawn_rate from going below a reasonable limit (e.g., 0.2 seconds)
        if (spawn_rate < 2) 
        {
            spawn_rate = 2.2f;
        }
    }
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
