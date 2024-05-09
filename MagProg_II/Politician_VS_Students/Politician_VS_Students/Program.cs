using Politician_VS_Students.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politician_VS_Students
{
    class Program
    {
        static List<Person> ReadInput(string inputFileName)
        {
            List<Person> persons = new List<Person>();

            StreamReader reader = null;
            string[] tokens;

            try
            {
                reader = new StreamReader(inputFileName);
                while (!reader.EndOfStream)
                {
                    tokens = reader.ReadLine().Split(';');
                    switch (tokens.Length)
                    {
                        case 0:
                        case 1:
                            throw new ArgumentException("A txt fájl sora túl rövid");
                        case 2:
                            persons.Add(new Politician(
                                                    tokens[0],
                                                    byte.Parse(tokens[1])
                                                    ));
                            break;
                        default:
                            List<Competence> competences = new List<Competence>();
                            for (int i = 2; i < tokens.Length; i++)
                                competences.Add((Competence)Enum.Parse(typeof(Competence), tokens[i]));
                            persons.Add(new Student(
                                                    tokens[0],
                                                    byte.Parse(tokens[1]),
                                                    competences
                                                    ));
                            break;
                    }
                }
            }
            // KÜLÖNBÖZŐ KIVÉTELEK KEZELÉSE!!!
            catch (UnderagedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IncorrectNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NoCompetenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return persons;
        }

        static void Main(string[] args)
        {
            List<Person> persons = ReadInput("persons.txt");
            Random rnd = new Random();

            // MIN. 5 AUTÓVÁSÁRLÁS ÉS 5 KOMPETENCIA TANULÁSA
            foreach (Person person in persons)
            {
                if (person is Student)
                {
                    int i = 0;
                    while (i < 4)
                    {
                        Array values = Enum.GetValues(typeof(Competence));
                        Competence rndCompetence = (Competence)values.GetValue(rnd.Next(values.Length));
                        //Console.WriteLine(rndCompetence);
                        if ((person as Student).Learn(rndCompetence))
                            i++;
                    }
                }

                if (person is Politician)
                {
                    Politician politician = person as Politician;
                    for (int i = 0; i < 5; i++)
                    {
                        politician.BuyCar("AAA00" + i.ToString());
                    }

                }
            }

            // MINDENKI LERÉSZEGÍTÉSE RANDOM LEVEL-LEL
            // KÖZBEN HA VALAKINÉL KIVÉTEL DOBÓDIK, ÍRD KI A KÉPERNYŐRE, HOGY AZ ADOTT SZEMÉLY ELSZEGÉNYEDETT/ELHÜLYÜLT
            try
            {
                foreach (Person person in persons)
                {
                    person.GetDrunk((byte)rnd.Next(256));
                }
            }
            catch (NoCompetenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // EMBEREK KIÍRATÁSA
            foreach (Person person in persons)
            {
                Console.WriteLine(person.ToString());
            }

            Console.ReadKey();
        }
    }
}
