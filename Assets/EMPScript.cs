using UnityEngine;
using UnityEngine.UI;

public class EMPScript : MonoBehaviour
{

    [SerializeField] CommandClass[] commands;

    [Space]

    int lastCommand = -1;

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

            ExecuteCommand(currentText);

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

    void ExecuteCommand(string command)
    {

        foreach(CommandClass singleCommand in commands)
        {

            //Looking at each command
            if(singleCommand.command == command)
            {

                //We found our command
                string[] toWrite = singleCommand.ExecuteCommand();
            }
        }

        //Print that the command wasn't found
    }

    public bool CheckForCommands(int[] numbersNeeded)
    {

        int counter = 0;

        foreach(CommandClass comm in commands)
        {

            if (comm.executed)
            {

                foreach (int i in numbersNeeded)
                {

                    if (i == comm.identifierNumber)
                    {

                        counter++;
                    }
                }
            }
        }

        if(counter == numbersNeeded.Length)
        {

            return true;
        }

        if (counter > numbersNeeded.Length) Debug.LogError("There are more numbers than expected: " + counter);

        return false;
    }

    public bool CheckLastCommand(int number)
    {

        if(lastCommand == number)
        {

            return true;
        }

        return false;
    }
}
