using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    

    public void ChangeVolume(float val)
    {

        PlayerPrefs.SetFloat("Volume", val);

        AudioListener.volume = val;
    }

    public void StartAdventure()
    {

        SceneManager.LoadScene(1);
    }
}
