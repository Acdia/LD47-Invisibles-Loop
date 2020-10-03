using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    [SerializeField] AudioListener audioListener;
    [SerializeField] MeshRenderer render;

    [Space]

    [SerializeField] Material on;
    [SerializeField] Material off;


    bool activated = false;
    bool gotPressureAlready = false;

    // Start is called before the first frame update
    void Start()
    {

        audioListener.enabled = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(activated != gotPressureAlready)
        {

            SetListeningStuff(gotPressureAlready);
            activated = gotPressureAlready;
        }

        gotPressureAlready = false;
    }

    void SetListeningStuff(bool state)
    {

        audioListener.enabled = state;

        if(state)
        {

            render.material = on;
        }
        else
        {

            render.material = off;
        }
        //Debug.Log("Material switched!");
    }

    public void PushPressing()
    {

        gotPressureAlready = true;
    }
}
