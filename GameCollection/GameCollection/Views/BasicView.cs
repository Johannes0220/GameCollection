using System.Collections;

namespace GameCollection.Views;

public abstract class BasicView
{
    public abstract object Show();

    protected bool HandleNumericInput(string input, int lowerBound, int upperBound)
    {
        var inputNum = 0;
        try
        {
            inputNum = int.Parse(input);
        }
        catch (Exception e)
        {
            Console.WriteLine(input + " is Not a Number");
            return false;
        }

        if (inputNum >= lowerBound && inputNum <= upperBound)
        {
            return true;
        }

        Console.WriteLine(inputNum + " is not in the List");
        return false;
    }

    protected int ReadNumericInput(string question, int lowerBound, int upperBound)
    {
        var valid = false;
        var input = "Keine Eingabe";
        while (!valid)
        {
            Console.Write(question);
            input = Console.ReadLine();
            valid = HandleNumericInput(input, lowerBound, upperBound);
        }

        return int.Parse(input);
    }

    protected string ReadTextInput(string question)
    {
        var valid = false;
        var input = "Keine Eingabe";
        while (!valid)
        {
            Console.Write(question);
            input = Console.ReadLine();
            valid = HandleTextInput(input);
        }

        return input;
    }

    protected bool HandleTextInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        return true;
    }
}