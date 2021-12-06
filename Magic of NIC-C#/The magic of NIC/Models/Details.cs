using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace The_magic_of_NIC.Models
{
    public class Details
    {
        #region Private Member Variables
        private int _Year { get; set; }
        private int _Month { get; set; }
        private int _Day { get; set; }
        private string _Gender { get; set; }
        #endregion

        public int year
        {
            get
            {
                return _Year;
            }
            set
            {
                _Year = value;
            }
        }

        public int month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
            }
        }

        public int day
        {
            get
            {
                return _Day;
            }
            set
            {
                _Day = value;
            }
        }

        public string gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

    }
}