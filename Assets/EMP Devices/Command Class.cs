using UnityEngine;

public class CommandClass
{

    public EMPScript EMP;

    public string command;
    public int identifierNumber;

    public string[] positiveActions;
    public float actionDelay;

    public int[] conditions;

    public string[] negativeOutput;

    public bool executed = false;
    public bool executing = false;

    public bool isAnswer = false;
    public int questionNumber = -1;

    string[] ExecuteCommand()
    {

        executing = true;

        if(EMP.CheckForCommands(conditions))
        {

            if(isAnswer)
            {


            }
        }
        else
        {

            return negativeOutput;
        }
    }
}
