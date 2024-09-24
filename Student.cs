using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Demo_Webapi
{
    public class Student
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int RollNumber { get; set; }

        public string Student_Name { get; set; }
        public string Department { get; set; }
        public string Student_Email { get; set; }
        public string Student_Phone { get; set; }
        public string Student_Address { get; set; }


    }
}
