using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Space_task
{
    internal class Planet : AstronomicalObject
    {
        private bool isRockyPlanet;
        public bool IsRockyPlanet {
            get { return isRockyPlanet; }
            set
            {
                isRockyPlanet = value;
            }
        }

        private float distanceFromSun;
        public float DistanceFromSun {
            get { return distanceFromSun; }
            set
            {
                distanceFromSun = value;
            }
        }

        public Planet(string id, string name, float age, bool isRockyPlanet, float distanceFromSun) : base(id, name, age)
        {
            IsRockyPlanet = isRockyPlanet;
            DistanceFromSun = distanceFromSun;
        }
    }
}
