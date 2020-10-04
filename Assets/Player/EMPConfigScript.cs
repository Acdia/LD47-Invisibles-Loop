using UnityEngine;

public class EMPConfigScript : MonoBehaviour
{

    [SerializeField] LayerMask EMPLayer;
    [SerializeField] float distance = 15f;

    [SerializeField] Transform cam;

    MainMovement movement;


    bool interfaceOpen = false;

    void Start()
    {

        movement = GetComponent<MainMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, distance, EMPLayer))
        {

            //We are sensing the EMP. By the way - day two started... I'm exited!
            if(Input.GetButtonDown("Fire1"))
            {

                //The player pressed and wants to interact with the EMP
                OpenEMPInterface();
                EMPCommandPushScript pusher = hit.collider.GetComponent<EMPCommandPushScript>();
                if(pusher != null)
                {

                    pusher.OpenInterface();
                }
            }
        }

        if(interfaceOpen && Input.GetButtonDown("Cancel"))
        {

            CloseEMPInterface();
        }
    }

    void CloseEMPInterface()
    {

        interfaceOpen = false;
        movement.enabled = true;
    }

    void OpenEMPInterface()
    {

        interfaceOpen = true;
        movement.enabled = false;
    }
}
