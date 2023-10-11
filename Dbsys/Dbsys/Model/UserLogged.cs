using Dbsys.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dbsys
{
    public class UserLogged
    {
        private static UserLogged instance;
        public UserAccount UserAccount { get; set; }

        private UserLogged()
        { }

        public static UserLogged GetInstance()
        {
            if (instance == null)
                instance = new UserLogged();
            return instance;
        }
    }
}
