using Politician_VS_Students.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Politician_VS_Students
{
    class Student : Person, ILearn
    {
        private List<Competence> competences = new List<Competence>();

        public override byte Age
        {
            get => base.Age;
            set
            {
                if (value < 18)
                    throw new UnderagedException();
                base.Age = value;
            }
        }

        public Student(string name, byte age, List<Competence> competences) : base(name, age)
        {
            if (competences.Count == 0)
                throw new NoCompetenceException();
            this.competences = competences;
            Age = age;
        }

        private void CheckIfCompetecesEmpty()
        {
            if (competences.Count == 0)
                throw new NoCompetenceException();
        }

        public bool Learn(Competence competence)
        {
            if (!competences.Contains(competence))
            {
                competences.Add(competence);
                return true;
            }
            return false;
        }

        public override void GetDrunk(byte level)
        {
            CheckIfCompetecesEmpty();
            int lostCompsCount = level / 10;
            for (int i = 0; i < lostCompsCount; i++)
            {
                int randomIndex = rnd.Next(competences.Count);
                competences.RemoveAt(randomIndex);
                CheckIfCompetecesEmpty();
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Age}) cars: {string.Join(", ", competences)}";
        }

    }
}
