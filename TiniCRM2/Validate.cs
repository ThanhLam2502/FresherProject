using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TiniCRM2
{
    public class Validate
    {
        public const string regexPhone = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4,5}$";
        public const string regexName = @"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$";
        public const string regexLocation = @"^[#.0-9a-zA-Z\s,-]+$";
        public const string regexEmail = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public bool IsValid(string phone, string regex)
        {
            return Regex.IsMatch(phone, regex);
        }

    }

}
