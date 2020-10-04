using UnityEngine;
using UnityEngine.UI;

public class EMPScript : MonoBehaviour
{

    [SerializeField] Text console;
    [SerializeField] InputField inpField;
    [SerializeField] GameObject canv;

    string currentText = "";

    public bool open = false;

    void Update()
    {

        if (!open) return;

        if(Input.GetButtonDown("Submit"))
        {

            console.text = console.text + "\n" + currentText;
            currentText = "";
            inpField.text = "";
            inpField.ActivateInputField();
        }

        if(Input.GetButtonDown("Cancel"))
        {

            open = false;
            canv.SetActive(false);
        }
    }

    public void PushOpening()
    {

        open = true;
        canv.SetActive(true);
        inpField.ActivateInputField();
    }

    public void GiveWrittenText(string theText)
    {

        currentText = theText;
    }

    public bool CheckForCommands(int[] numbersNeeded)
    {

        return true; // Hopefully I'll change this!!!
    }

    public bool CheckLastCommand(int number)
    {

        return true; //This also
    }
}
