using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClassification_Add_in.UI
{
    public class User
    {
        public int Code { get; set; }
        public string Name_user { get; set; }
        public int ID_premissionLevel { get; set; }
        public Nullable<int> ID_category { get; set; }
        public string ID_user { get; set; }
        public string Password { get; set; }

        public User(int code, string nameManager, int id_pl, int id_category, string id_user, string password)
        {
            this.Code = code;
            this.Name_user = nameManager;
            this.ID_premissionLevel = id_pl;
            this.ID_category = id_category;
            this.ID_user = id_user;
            this.Password = password;
        }
    }
}
