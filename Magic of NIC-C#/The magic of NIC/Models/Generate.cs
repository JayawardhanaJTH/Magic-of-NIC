using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace The_magic_of_NIC.Models
{
    public class Generate
    {
        public static int ZERO = 0;
        public static int TWO = 2;
        public static int THREE = 3;
        public static int FOUR = 4;
        public static int FIVE = 5;

        private String _TempNumber;
        private Details _Details;
        private Validates _validate;


        public Details GenerateData(String number)
        {
            _validate = new Validates();

            if (_validate.Validate(number))
            {
                _TempNumber = number;
                _Details = new Details();

                GetYear();
                GetGender();

                return _Details;
            }
            else
            {
                return _Details;
            }
        }

        private void GetGender()
        {
            int Days;
            String DaysBlock;

            if (_validate.IsOldNumber(_TempNumber))
            {
                DaysBlock = _TempNumber.Substring(TWO, THREE);

                Days = Convert.ToInt32(DaysBlock);

                if (Days > 500)
                {
                    _Details.gender = "Female";
                    Days -= 500;
                }
                else
                {
                    _Details.gender = "Male";
                }
                GetMonthDate(Days);
            }
            else
            {
                DaysBlock = _TempNumber.Substring(FOUR, THREE);

                Days = Convert.ToInt32(DaysBlock);
                

                if (Days > 500)
                {
                    _Details.gender = "Female";
                    Days -= 500;
                }
                else
                {
                    _Details.gender = "Male";
                }

                GetMonthDate(Days);
            }
        }

        private void GetYear()
        {
            int year;
            String yearBlock;

            if (_validate.IsOldNumber(_TempNumber))
            {
                yearBlock = _TempNumber.Substring(ZERO, TWO);

                year = Convert.ToInt32(yearBlock);
                year += 1900;
            }
            else
            {
                yearBlock = _TempNumber.Substring(ZERO, FOUR);

                year = Convert.ToInt32(yearBlock);
            }

            _Details.year =  year;
        }

        private void GetMonthDate(int days)
        {
            bool IsLeapYear;
            int Month = 0;

            IsLeapYear = DateTime.IsLeapYear(_Details.year);//check is the year is leap or not

            //use that loop to identify the month and the date
            for (; days > 31;)
            {
                Month++;

                //31 days months
                if ((Month % 2) == 0 && Month > 8)
                {
                    days -= 31;
                }
                else if ((((Month % 2) != 0) && Month < 9) || Month == 8)
                {
                    days -= 31;
                }
                else if (Month == 2)
                {
                    if (IsLeapYear)
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
                    days -= 30;
                }
            }

            if (days != 0 && Month < 12)
            {
                Month += 1;
            }
            else
            {

                if ((Month % 2) == 0 && Month > 8)
                {
                    days = 31;

                }
                else if ((((Month % 2) != 0) && Month < 9) || Month == 8)
                {
                    days = 31;

                }
                else if (Month == 2)
                {
                    if (IsLeapYear)
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
                    days = 30;
                }
            }

            _Details.day = days;
            _Details.month = Month;
        }
    }
}