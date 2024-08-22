using ProiectCofetarie.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCofetarie.Library
{
    public class AppCofetarie
    {
      
        public User? LoggedInUser { get; set; }
        public bool IsLoggedIn { get; set; }
        public AppCofetarie() {
            LoggedInUser = null;
            IsLoggedIn = false;
        }
    }
}
