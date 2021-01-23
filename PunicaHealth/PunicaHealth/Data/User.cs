using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PunicaHealth.Data
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string dob { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
    }
}
