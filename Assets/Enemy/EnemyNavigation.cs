using UnityEngine;

public class EnemyNavigation : MonoBehaviour
{

    [SerializeField] LayerMask navLayer;
    [SerializeField] float newPointDistance = 10f;

    [Space]

    [SerializeField] GameObject north;
    [SerializeField] GameObject south;
    [Space]
    [SerializeField] GameObject east;
    [SerializeField] GameObject west;

    [Space]

    [SerializeField] float maxWaitTime = 20f;
    [SerializeField] int maxSteps = 10;
    [SerializeField] float crossChance = 0.35f;
    [SerializeField] float maxSpeed = 15f;
    [SerializeField] float attackSpeed = 50f;

    Transform currentDestination;
    bool doingStuff = false;
    int stepsLeft = 0;
    bool resting = true;
    float currentSpeed = 0f;
    float timeLeftWaiting = 0f;

    // Update is called once per frame
    void Update()
    {
        
        if(!doingStuff)
        {

            //Find something to do!
            if(resting)
            {

                //Start walking around
                PreapareWalking();
            }
            else
            {

                //Have some rest. It was a hard day!
                PrepareRest();
            }
        }

        if(doingStuff && !resting)
        {

            Walk();
        }

        if(doingStuff && resting)
        {

            Rest();
        }
    }

    void Rest()
    {

        if(timeLeftWaiting < 0f)
        {

            //We can stop resting!
            doingStuff = false;
            return;
        }

        timeLeftWaiting -= Time.deltaTime;
    }

    void PrepareRest()
    {

        resting = true;
        doingStuff = true;

        timeLeftWaiting = Random.Range(maxWaitTime / 2f, maxWaitTime);
    }

    void Walk()
    {

        //We walk a tiny little bit

        if(currentDestination != null && Vector3.Distance(transform.position, currentDestination.position) < newPointDistance)
        {

            FindDestination();
        }

        transform.position = Vector3.MoveTowards(transform.position, currentDestination.position, currentSpeed * Time.deltaTime);
    }

    void PreapareWalking()
    {

        resting = false;
        doingStuff = true;
        
        stepsLeft = Random.Range(maxSteps / 2, maxSteps);
        currentSpeed = Random.Range(maxSpeed / 2, maxSpeed);

        FindDestination();
    }

    void FindDestination()
    {

        //If we finished walking we stop it
        if(stepsLeft <= 0)
        {

            doingStuff = false;
            return;
        }

        if(currentDestination != null && currentDestination.CompareTag("Cornerpoint"))
        {

            if(Random.Range(0f, 1f) < crossChance)
            {

                CrossWalk();
                return;
            }
        }

        Collider[] colls = Physics.OverlapSphere(transform.position, 85f, navLayer);  //85 makes sure we get only the points nearby
        Collider chosenOne;

        do
        {
            
            chosenOne = colls[Random.Range(0, colls.Length)];
        } while (currentDestination && chosenOne.transform == currentDestination && colls.Length > 1);


        currentDestination = chosenOne.transform;

        stepsLeft--;
    }

    void CrossWalk()
    {

        //We walk across the control room! Thats fun!
        /*switch(currentDestination)
        {

            case north.transform: 
        }*/

        if(currentDestination == north.transform)
        {

            currentDestination = south.transform;
            Debug.Log("south");
            return;
        }
        if (currentDestination == south.transform)
        {

            currentDestination = north.transform;
            Debug.Log("north");
            return;
        }
        if (currentDestination == east.transform)
        {

            currentDestination = west.transform;
            Debug.Log("west");
            return;
        }
        if (currentDestination == west.transform)
        {

            currentDestination = east.transform;
            Debug.Log("east");
            return;
        }

        Debug.LogError("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA!!!!!");

    }
}
