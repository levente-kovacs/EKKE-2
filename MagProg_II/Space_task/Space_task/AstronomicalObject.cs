using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Space_task
{
    internal class AstronomicalObject
    {
        private string id;

        public string Id {
            get { return id; }
            private set
            {
                string regex = "^(?=.*-).{5,}$";
                if (Regex.IsMatch(value.ToString(), regex))
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("Invalid id. It should be at least 5 characters long and contain at least one '-' character.");
                }
            }
        }

        private string name;
        public string Name {
            get { return name; }
            private set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Invalid name. It should be at least 1 character long.");
                }
                name = value;
            }
        }

        private float age;
        public float Age {
            get { return age; }
            private set
            {
                age = value;
            }
        }

        public AstronomicalObject(string id, string name, float age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public AstronomicalObject(string id)
        {
            Id = id;
            Name = id.ToString();
            Age = 4600;
        }
    }
}
