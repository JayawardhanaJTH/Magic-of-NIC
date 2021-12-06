package services;

import models.Details;

import java.time.Year;

public class Generate
{
    public static final int ZERO = 0;
    public static final int TWO = 2;
    public static final int FOUR = 4;
    public static final int FIVE = 5;
    public static final int SEVEN = 7;

    private String TempNumber;
    private Details details;
    private IValidate validate;


    public Details GenerateData(String number)
    {
        validate = new ValidateImplement();

        if(validate.Validate(number))
        {
            TempNumber = number;
            details = new Details();

            GetYear();
            GetGender();

            return details;
        }
        else
        {
            return details;
        }
    }

    private void GetGender()
    {
        int _days;
        String _daysBlock;

        if(validate.IsOldNumber(TempNumber))
        {
            _daysBlock = TempNumber.substring(TWO, FIVE);

            _days = Integer.parseInt(_daysBlock);

            if(_days > 500 )
            {
                details.setGender("Female");
                _days -= 500;
            }
            else
            {
                details.setGender("Male");
            }

            GetMonthDate(_days);
        }
        else
        {
            _daysBlock = TempNumber.substring(FOUR, SEVEN);

            _days = Integer.parseInt(_daysBlock);

            if(_days > 500 )
            {
                details.setGender("Female");
                _days -= 500;
            }
            else
            {
                details.setGender("Male");
            }

            GetMonthDate(_days);
        }
    }

    private void GetYear()
    {
        int _year;
        String _yearBlock;

        if(validate.IsOldNumber(TempNumber))
        {
            _yearBlock = TempNumber.substring(ZERO,TWO);

            _year = Integer.parseInt(_yearBlock);
            _year += 1900;
        }
        else
        {
            _yearBlock = TempNumber.substring(ZERO,FOUR);

            _year = Integer.parseInt(_yearBlock);
        }

        details.setYear(_year);
    }

    private void GetMonthDate(int days)
    {
        boolean _isLeapYear;
        int _month = 0;

        Year _year = Year.of(details.getYear());
        _isLeapYear = _year.isLeap();//check is the year is leap or not

        //use that loop to identify the month and the date
        for( ;days > 31; )
        {
            _month ++;

            //31 days months
            if((_month % 2) == 0 && _month > 8)
            {
                days -= 31;
            }
            else if((((_month % 2) != 0) && _month < 9)|| _month == 8)
            {
                days -= 31;
            }
            else if( _month == 2)
            {
                if (_isLeapYear)
                {
                    days -= 29;
                }
                else
                {
                    days -= 28;
                }
            }
            else
            {
                days -=30;
            }
        }

        if(days != 0 && _month < 12)
        {
            _month +=1;
        }
        else
        {

            if((_month % 2) == 0 && _month > 8)
            {
                days = 31;

            }
            else if((((_month % 2) != 0) && _month < 9)|| _month == 8)
            {
                days = 31;

            }
            else if( _month == 2)
            {
                if(_isLeapYear)
                {
                    days = 29;
                }
                else
                {
                    days = 28;
                }
            }
            else
            {
                days =30;
            }
        }

        details.setDay(days);
        details.setMonth(_month);
    }
}
