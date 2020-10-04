using UnityEngine;
using UnityEngine.UI;

public class EMPScript : MonoBehaviour
{


    public CommandClass[] commands;

    [Space]

    int lastCommand = -1;

    [SerializeField] Text console;
    [SerializeField] InputField inpField;
    [SerializeField] GameObject canv;

    string currentText = "";

    public bool open = false;
    [SerializeField] int overflow = 20;

    bool currentlyWriting = false;
    int textPosCounter = 0;
    float currentDelay = 0f;
    string[] toWrite;

    void Update()
    {

        if (!open) return;

        if(Input.GetButtonDown("Submit"))
        {

            AddText(currentText);

            ExecuteCommand(currentText);
            currentlyWriting = true;

            currentText = "";
            inpField.text = "";
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
        if(!currentlyWriting) inpField.ActivateInputField();
    }

    public void GiveWrittenText(string theText)
    {

        currentText = theText;
    }

    void ExecuteCommand(string command)
    {

        toWrite = new string[0];

        foreach (CommandClass singleCommand in commands)
        {

            //Looking at each command
            if(singleCommand.command == command)
            {

                //We found our command
                toWrite = singleCommand.ExecuteCommand();
                currentDelay = singleCommand.actionDelay;
            }
        }

        //Print that the command wasn't found
        if(toWrite.Length < 1)
        {

            AddText("command not found");
            AddText(">");
            currentlyWriting = false;
            EnableUserWriting();
            return;
        }

        textPosCounter = 0;
        DoWriting();
    }

    void DoWriting()
    {

        if(textPosCounter >= toWrite.Length)
        {

            currentlyWriting = false;
            AddText(">");
            EnableUserWriting();
            return;
        }

        AddText(toWrite[textPosCounter]);
        textPosCounter++;

        Invoke("DoWriting", currentDelay);
    }

    void EnableUserWriting()
    {

        inpField.ActivateInputField();
    }

    void AddText(string text)
    {

        while(console.text.Split('\n').Length > overflow)
        {

            //Thanks stackoverflow! :)
            int index = console.text.IndexOf(System.Environment.NewLine);
            console.text = console.text.Substring(index + System.Environment.NewLine.Length);
        }

        if(text == ">")
        {

            console.text = console.text + text;
            return;
        }

        console.text = console.text + text + "\n";
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
