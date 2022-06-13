using System;

namespace Departament_project.Entities
{
    internal class Departament
    {
        public string Name { get; set; }
        
        public Departament()
        {

        }
        public Departament(string name)
        {
            Name = name;
        }
    }
}
