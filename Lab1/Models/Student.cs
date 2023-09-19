using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return this.Id + " - " + this.Name + " - " + this.Gender + " - " + this.Email;
        }

    }
}
