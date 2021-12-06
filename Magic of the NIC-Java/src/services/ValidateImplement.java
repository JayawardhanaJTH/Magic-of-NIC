package services;

public class ValidateImplement implements IValidate
{
    public static final int ZERO = 0;
    public static final int NINE = 9;

    private String TempNumber;

    @Override
    public boolean Validate(String number)
    {
        TempNumber = number;

        if(IsValidLength(TempNumber))
        {
            if(IsOldNumber(TempNumber))
            {
                if(IsValidNumber(TempNumber, true))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if(IsValidNumber(TempNumber, false))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }

    @Override
    //check is the entered number length is valid or not
    public boolean IsValidLength(String number)
    {
        if((number.length() == 10) || (number.length() == 12))
        {
           return true;
        }
        else
        {
            return false;
        }

    }

    @Override
    //check is the entered number is old type or not
    public boolean IsOldNumber(String number)
    {
        if(number.length() == 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    @Override
    //check is the number part in the entered one is numbers or not
    public boolean IsValidNumber(String number, boolean isOld)
    {
        String _NumberPart;
        String _Pattern = "[0-9]+";

        if(isOld)
        {
            _NumberPart = number.substring(ZERO, NINE);

            return _NumberPart.matches(_Pattern);
        }
        else
        {
            return number.matches(_Pattern);
        }

    }
}
