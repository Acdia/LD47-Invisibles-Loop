[System.Serializable]
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

    public string[] ExecuteCommand()
    {

        executing = true;

        if(EMP.CheckForCommands(conditions))
        {

            if(isAnswer)
            {

                if(EMP.CheckLastCommand(questionNumber))
                {

                    executed = true;
                    return positiveActions;
                }
                else
                {

                    return new string[] { "command not found" };
                }
            }

            executed = true;
            return positiveActions;
        }
        else
        {

            return negativeOutput;
        }
    }
}
