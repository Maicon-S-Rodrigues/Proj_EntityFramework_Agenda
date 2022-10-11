using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_EF_Agenda.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Numbers PhoneNumbers { get; set; }
        public string Mail { get; set; }

        public Person() { }
        public Person(string name, Numbers num, string mail)
        {
            this.Name = name;
            this.PhoneNumbers = num;
            this.Mail = mail;
        }

        public override string ToString()
        {
            return   $"\nID: {this.Id}" +
                     $"\nNome: {this.Name}" +
                     $"\nTelefone {this.PhoneNumbers.Home}" +
                     $"\nCelular: {this.PhoneNumbers.Mobile}" +
                     $"\nE-mail: {this.Mail}" +
                     $"\n__________________________________________________";
        }
    }
}
