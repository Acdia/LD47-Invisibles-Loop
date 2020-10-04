using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject UI;

    public void EndGame()
    {

        UI.SetActive(true);
        Invoke("NewScene", 5f);
    }

    void NewScene()
    {

        SceneManager.LoadScene(0);
    }

    public void Win()
    {

        Invoke("NewScene", 8f);
    }
}
