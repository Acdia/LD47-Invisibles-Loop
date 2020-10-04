using UnityEngine;

public class EMPLauncher : MonoBehaviour
{
    
    [SerializeField] EMPScript[] EMPs;
    [SerializeField] LayerMask buttonLayer;
    [SerializeField] Transform cam;
    [SerializeField] float dist = 25f;

    [SerializeField] GameObject UIActivateFirst;
    [SerializeField] GameObject UIWin;

    [SerializeField] GameManager gm;

    void Update()
    {
        
        if(Input.GetButtonDown("Fire1"))
        {

            if(Physics.Raycast(cam.position, cam.forward, dist, buttonLayer))
            {

                //Check if we can press the button already
                foreach(EMPScript emp in EMPs)
                {

                    if(!emp.readyToStart)
                    {

                        UIActivateFirst.SetActive(true);
                        Invoke("DisableUI", 5f);
                        return;
                    }
                }

                UIWin.SetActive(true);
                gm.Win();
            }
        }
    }

    void DisableUI()
    {

        UIActivateFirst.SetActive(false);
    }
}
