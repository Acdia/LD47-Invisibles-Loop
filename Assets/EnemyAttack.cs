using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] float attackSpeed = 20f;
    [SerializeField] float attackDistance = 35f;
    [SerializeField] float stopdistance = 5f;

    [Space]

    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject player;
    [SerializeField] MeshRenderer[] rendere;
    [SerializeField] GameObject particles;
    [SerializeField] AudioSource aud;

    [SerializeField] GameManager gm;

    float fadeValue = 0f;
    [SerializeField] float fadeSpeed = 150f;
    [SerializeField] float activateParticles = 100f;

    bool killingStarted = false;
    bool effectDone = false;

    void Start()
    {

        foreach (MeshRenderer r in rendere)
        {

            r.enabled = false;
            r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, 0f);
        }
    }

    void Update()
    {
        
        if(!killingStarted && Vector3.Distance(transform.position, playerCam.transform.position) < attackDistance)
        {

            Debug.Log("The player is dead!");

            killingStarted = true;
            player.GetComponent<DeathScript>().StartDying(gameObject);

            GetComponent<EnemyNavigation>().enabled = false;

            aud.Play();
        }

        if(killingStarted && Vector3.Distance(transform.position, playerCam.transform.position) < stopdistance)
        {

            gm.EndGame();
        }

        if(killingStarted)
        {

            transform.LookAt(playerCam.transform);
            transform.position = Vector3.MoveTowards(transform.position, playerCam.transform.position, attackSpeed * Time.deltaTime);

            if (effectDone) return;

            fadeValue += fadeSpeed * Time.deltaTime;

            if(fadeValue > 255f)
            {

                effectDone = true;
                return;
            }

            foreach(MeshRenderer r in rendere)
            {

                r.enabled = true;

                r.material.color = new Color(r.material.color.r, r.material.color.g, r.material.color.b, fadeValue);
            }

            if(fadeValue > activateParticles && !particles.activeSelf)
            {

                particles.SetActive(true);
            }
        }

    }
}
