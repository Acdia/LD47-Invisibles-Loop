using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject UI;

    public void EndGame()
    {

        UI.SetActive(true);
    }
}
