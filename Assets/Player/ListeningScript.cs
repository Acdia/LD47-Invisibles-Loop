using UnityEngine;

public class ListeningScript : MonoBehaviour
{

    [SerializeField] GameObject[] enemies;
    [SerializeField] float maxDist = 10f;

    [Space]

    [SerializeField] LayerMask raycastLayer;
    [SerializeField] Transform cam;
    [SerializeField] AudioListener mainListener;

    bool listening = false;
    bool wasListening = false;

    // Update is called once per frame
    void Update()
    {

        listening = false;

        if(Input.GetButton("Fire1"))
        {

            if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, maxDist, raycastLayer))
            {

                //We hit a button and now want to start listening from the new position
                if(hit.collider.CompareTag("Button"))
                {

                    listening = true;
                    TellEnemiesThatWeAreListening(true);
                    mainListener.enabled = false;
                    //Debug.Log("Started Listening");

                    //Push the pressing - This is maybe not really performant ... let's see!
                    hit.collider.gameObject.GetComponent<ButtonScript>().PushPressing();
                }
            }
        }

        if (!listening)
        {

            NotListening();
        }



        wasListening = listening;
    }

    void NotListening()
    {

        //Stop listening
        if (wasListening)
        {

            listening = false;
            TellEnemiesThatWeAreListening(false);
            //Debug.Log("Stopped listening");

            mainListener.enabled = true;
        }
    }

    void TellEnemiesThatWeAreListening(bool state)
    {

        foreach(GameObject go in enemies)
        {

            go.GetComponent<EnemyScript>().SetListeningState(state);
        }
    }
}
