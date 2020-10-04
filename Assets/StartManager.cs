using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    [SerializeField] GameObject det;

    public void ShowDetails()
    {

        det.SetActive(true);
    }

    public void HideDetails()
    {

        det.SetActive(false);
    }

    public void ChangeVolume(float val)
    {

        PlayerPrefs.SetFloat("Volume", val);

        AudioListener.volume = val;
    }

    public void SetMiddleCrossing(bool val)
    {

        if(val)
        {

            PlayerPrefs.SetInt("Crossing", 1);
        }
        else
        {

            PlayerPrefs.SetInt("Crossing", 0);
        }
        
    }

    public void StartAdventure()
    {

        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
}
