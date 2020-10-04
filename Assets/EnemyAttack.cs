using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] float attackSpeed = 20f;
    [SerializeField] float attackDistance = 35f;

    [Space]

    [SerializeField] GameObject player;
    [SerializeField] Animation anim;

    bool killingStarted = false;

    void Update()
    {
        
        if(!killingStarted && Vector3.Distance(transform.position, player.transform.position) < attackDistance)
        {

            Debug.Log("The player is dead!");
            player.GetComponent<DeathScript>().StartDying(gameObject);

            GetComponent<EnemyNavigation>().enabled = false;
        }

        if(killingStarted)
        {

            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, attackSpeed * Time.deltaTime);
        }
    }
}
