using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFApp
{
    public class Collaborator : Person
    {
        public int CollaboratorId { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string ManagerCode { get; set; }
        //public virtual Manager Manager { get; set; }
    }
}
