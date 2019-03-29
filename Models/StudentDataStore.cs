using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webcoreapi.Models
{
    public class StudentDataStore
    {
        public static StudentDataStore Current { get; } = new StudentDataStore();
        public List<Student> Students { get; set; }
        public StudentDataStore()
        {
            Students = new List<Student>()
            {
                new Student {id=1 , Name="shahnoor4" , Address="Bufferzone"},
                  new Student {id=2 , Name="shahnoor5" , Address="Bufferzone"},
                    new Student {id=3 , Name="shahnoor6" , Address="Bufferzone"}
            };
        }
    }
}
