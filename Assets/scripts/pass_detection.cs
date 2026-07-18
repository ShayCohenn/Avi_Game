using UnityEngine;

public class pass_detection : MonoBehaviour
{
    public logic_manager logic;
    [SerializeField] private NewMonoBehaviourScript playerScript;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logic_manager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3 && playerScript.isPlayerAlive)
        {
            logic.incScore(1);
        }
    }
}
