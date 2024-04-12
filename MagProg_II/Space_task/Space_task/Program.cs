namespace Space_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Space space = new Space();
            StreamReader reader = new StreamReader("space.txt");
            while (!reader.EndOfStream)
            {
                string[] lineParts = reader.ReadLine().Split(';');

                try
                {
                    if (lineParts.Length == 1)
                    {
                        space.AddObject(new AstronomicalObject(lineParts[0]));
                    }
                    else
                    {
                        float age;
                        if (!float.TryParse(lineParts[3], out age))
                        {
                            throw new Exception("[ERROR] The 4th value could not be parsed.");
                        }

                        if (lineParts[0] == "b")
                        {
                            bool isRockyPlanet;
                            if (!bool.TryParse(lineParts[4], out isRockyPlanet))
                            {
                                throw new Exception("[ERROR] The 5th value could not be parsed.");
                            }

                            float distanceFromSun;
                            if (!float.TryParse(lineParts[5], out distanceFromSun))
                            {
                                throw new Exception("[ERROR] The 6th value could not be parsed.");
                            }

                            space.AddObject(new Planet(lineParts[1], lineParts[2], age, isRockyPlanet, distanceFromSun));
                        }
                        else if (lineParts[0] == "c")
                        {
                            //StarClass starClass;
                            //if ((StarClass)Enum.TryParse(typeof(StarClass), lineParts[5], out starClass))
                            //{
                            //    throw new Exception("[ERROR] The 6th value could not be parsed.");
                            //}

                            float diameterComparedToSun;
                            if (!float.TryParse(lineParts[5], out diameterComparedToSun))
                            {
                                throw new Exception("[ERROR] The 6th value could not be parsed.");
                            }

                            space.AddObject(new Star(lineParts[1], lineParts[2], age, (StarClass)Enum.Parse(typeof(StarClass), lineParts[4]), diameterComparedToSun));
                        }
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            reader.Close();

            
            Console.WriteLine($"A bolygók átlagos keringési távolsága: {space.GetAvgPlanetDistance()} csillagászati egység.");

            List<Star> redGiantStars = space.GetStarsByClass(StarClass.RedGiant);
            Star biggestRedGiant = redGiantStars.MaxBy(x => x.DiameterComparedToSun);
            Console.WriteLine($"\nA vörös óriások közül a maximális átmérőjű csillag adatai:\n\t{biggestRedGiant.Id}\t{biggestRedGiant.Name}\t{biggestRedGiant.Age}\t{biggestRedGiant.Class}\t{biggestRedGiant.DiameterComparedToSun}");
        }
    }
}