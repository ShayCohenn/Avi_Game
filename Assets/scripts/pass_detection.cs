using UnityEngine;

public class pass_detection : MonoBehaviour
{
    public logic_manager logic;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic_manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewMonoBehaviourScript playerScript = collision.GetComponent<NewMonoBehaviourScript>();
        if(collision.gameObject.layer == 3 && playerScript.isPlayerAlive)
        {
            Debug.Log(playerScript.isPlayerAlive.ToString());
            logic.incScore(1);
        }
    }
}
