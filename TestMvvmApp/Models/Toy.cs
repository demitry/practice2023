using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestMvvmApp.Models
{
    public class Toy
    {
        public Guid Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public string Size { get; }
        public bool IsValid { get; }

        public Toy(Guid id, string name, string description, string size, bool isValid)
        {
            Id = id;
            Name = name;
            Description = description;
            Size = size;
            IsValid = isValid;
        }
    }
}
