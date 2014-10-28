using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new CompanyContext())
            {
                var collaborator = new Collaborator()
                {
                    CollaboratorId = 1,
                    Name = "hello",
                    DepartmentId = 5,
                    ManagerCode = "xxx"
                };
                ctx.Collaborators.Add(collaborator);

                collaborator = new Collaborator()
                {
                    CollaboratorId = 1,
                    Name = "hello xcxsds",
                    DepartmentId = 7,
                    ManagerCode = "xxx sddss"
                };
                ctx.Collaborators.Add(collaborator);

                ctx.SaveChanges();

                Console.WriteLine(string.Format("Baza danych: {0}", ctx.Database.Exists()));
                Console.WriteLine(string.Format("Baza danych: {0}", ctx.Configuration));
            }
        }
    }
}
