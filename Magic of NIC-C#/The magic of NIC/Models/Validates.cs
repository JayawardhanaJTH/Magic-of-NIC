using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace The_magic_of_NIC.Models
{
    public class Validates
    {
        public static  int ZERO = 0;
        public static  int NINE = 9;

        private String _TempNumber;

    public bool Validate(String number)
        {
            _TempNumber = number;

            if (IsValidLength(_TempNumber))
            {
                if (IsOldNumber(_TempNumber))
                {
                    if (IsValidNumber(_TempNumber, true))
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
                    if (IsValidNumber(_TempNumber, false))
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

    //check is the entered number length is valid or not
    public bool IsValidLength(String number)
        {
            if ((number.Length == 10) || (number.Length == 12))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    //check is the entered number is old type or not
    public bool IsOldNumber(String number)
        {
            if (number.Length == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    //check is the number part in the entered one is numbers or not
    public bool IsValidNumber(String number, bool isOld)
        {
            String NumberPart;
            String Pattern = "[0-9]+";
            Regex Regx = new Regex(Pattern);

            if (isOld)
            {
                NumberPart = number.Substring(ZERO, NINE);

                return Regx.IsMatch(NumberPart);
            }
            else
            {
                return Regx.IsMatch(number);
            }

        }
    }
}