using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_task
{
    internal class Space
    {
        private List<AstronomicalObject> astroObjects = new List<AstronomicalObject>();

        public void AddObject(AstronomicalObject astroObject)
        {
            if (!astroObjects.Any(obj => obj.Id == astroObject.Id))
            {
                astroObjects.Add(astroObject);
            }
            else
            {
                throw new Exception($"[ERROR] There is already an astronomical object in the memory with \"{astroObject.Id}\" identifier.");
            }
        }

        public void RemoveObject(string id)
        {
            if (astroObjects.Any(obj => obj.Id == id))
            {
                foreach (AstronomicalObject astroObject in astroObjects)
                {
                    if (astroObject.Id == id)
                    {
                        astroObjects.Remove(astroObject);
                    }
                }
            }
            else
            {
                throw new Exception($"[ERROR] There is no astronomical object in the memory with \"{id}\" identifier.");
            }
        }

        private void checkIfListIsEmpty(List<AstronomicalObject> list)
        {
            if (astroObjects.Count == 0)
            {
                throw new Exception($"[ERROR] There is no astronomical object in the memory.");
            }                
        }

        public float GetAvgPlanetDistance()
        {
            checkIfListIsEmpty(astroObjects);

            //float avgPlanetDistance = 0;
            float sumPlanetDistances = 0;
            int planetCount = 0;

            foreach (AstronomicalObject astroObject in astroObjects)
            {
                if (astroObject is Planet)
                {
                    planetCount++;
                    sumPlanetDistances += (astroObject as Planet)!.DistanceFromSun;
                }
            }

            return sumPlanetDistances / planetCount;
        }

        public List<Star> GetStarsByClass(StarClass starClass)
        {
            checkIfListIsEmpty(astroObjects);

            List<Star> starsByClass = new List<Star>();

            foreach (AstronomicalObject astroObject in astroObjects)
            {
                if (astroObject is Star)
                {
                    if ((astroObject as Star)?.Class == starClass)
                    {
                        starsByClass.Add(astroObject as Star);
                    }
                }
            }

            if (starsByClass.Count == 0)
            {
                Console.WriteLine($"[ERROR] There is no star of this class in the memory.");
            }

            return starsByClass;
        }

        //public override string? ToString()
        //{
        //    string result = "";
        //    foreach (AstronomicalObject astroObject in astroObjects)
        //    {
        //        result += $"";
        //    }
        //    return $"";
        //}
    }
}
