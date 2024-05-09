using Politician_VS_Students.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politician_VS_Students
{
    abstract class Person : IDrunk
    {
        public static Random rnd = new Random();

        private string name;
        public string Name {
            get => name;
            set
            {
                if (value != null && value.Length >= 5)
                    name = value;
                else
                    throw new IncorrectNameException();
            }
        }

        public virtual byte Age { get; set; }

        protected Person(string name, byte age)
        {
            Name = name;
            Age = age;
        }

        public abstract void GetDrunk(byte level);
    }
}
