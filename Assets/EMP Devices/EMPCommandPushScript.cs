using UnityEngine;

public class EMPCommandPushScript : MonoBehaviour
{

    [SerializeField] EMPScript emp;

    public void OpenInterface()
    {

        emp.PushOpening();
    }
}
