using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Project>? Projects { get; set; }

        public Portfolio()
        {
            Projects = new List<Project>();
        }
    }
}
