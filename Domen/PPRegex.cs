using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pp_test;

namespace pp_test.Controllers;


public static class PPRegex{

     public static bool PhoneRegex(string phone)
    {
        //+7XXX-XXX-XX-XX
        try
        {
            return Regex.IsMatch(phone,
                @"\+7\d{3}-\d{3}-\d{2}-\d{2}",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }


    public static bool PostamatRegex(string postamatnum)
    {
        //XXXX-XXX
        try
        {
            return Regex.IsMatch(postamatnum,
                @"\d{4}-\d{3}",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}