using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] AudioSource myNoise;

    bool makingNoise = false;

    public void SetListeningState(bool state)
    {

        makingNoise = state;
        if(state)
        {

            myNoise.mute = false;
        }
        else
        {

            myNoise.mute = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        myNoise.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
