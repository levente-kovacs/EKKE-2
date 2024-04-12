using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Space_task
{
    enum StarClass
    {
        Average,
        RedGiant,
        BrownDwarf,
        Neutron
    }


    internal class Star : AstronomicalObject
    {

        private StarClass classField;
        public StarClass Class {
            get { return classField; }
            set
            {
                classField = value;
            }
        }

        private float diameterComparedToSun;
        public float DiameterComparedToSun {
            get  { return diameterComparedToSun; }
            set
            {
                diameterComparedToSun = value;
            }
        }

        public Star(string id, string name, float age, StarClass classField, float diameterComparedToSun) : base(id, name, age)
        {
            Class = classField;
            DiameterComparedToSun = diameterComparedToSun;
        }
    }
}
