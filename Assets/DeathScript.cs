using UnityEngine;

public class DeathScript : MonoBehaviour
{

    bool dying = false;
    GameObject en;

    [SerializeField] GameObject cam;

    [Space]

    [SerializeField] float turnSpeed = 180f;

    public void StartDying(GameObject enemy)
    {

        dying = true;

        en = enemy;
        GetComponent<MainMovement>().enabled = false;
    }

    void Update()
    {
    
        if(dying)
        {

            Vector3 targetDirection = en.transform.position - cam.transform.position;
            float step = turnSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(cam.transform.forward, targetDirection, step, 0f);
            cam.transform.rotation = Quaternion.LookRotation(newDirection);
            Debug.Log(newDirection);
        }
    }
}
