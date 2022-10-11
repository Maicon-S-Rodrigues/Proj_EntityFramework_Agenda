using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_EF_Agenda.Models
{
    internal class Numbers
    {
        public string Mobile { get; set; }
        public string Home { get; set; }

        public Numbers() { }
        public Numbers(string mobile, string home)
        {
            this.Mobile = mobile;
            this.Home = home;
        }
        public override string ToString()
        {
            return "Celular: " + this.Mobile + " | Telefone: " + this.Home ;
        }
    }
}
