using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

/*
namespace WPFapp
{
    public class DataHandler
    {
        private string dataFileName;

        public string DataFileName
        {
            get { return dataFileName; }
        }
        public DataHandler(string dataFileName)
        {
            this.dataFileName = dataFileName;
        }
        public void SaveEmployee(Employee employee)
        {
            using StreamWriter sw = new StreamWriter(DataFileName);
            string lineToSave = employee.MakeTitle();
            sw.WriteLine(lineToSave);
        }
        public Person LoadPerson()
        {
            using StreamReader sr = new StreamReader(DataFileName);
            string lineToLoad = sr.ReadLine();

            string[] personTraits = lineToLoad.Split(';');
            string Name = personTraits[0];
            DateTime BirthDate = DateTime.Parse(personTraits[1]);
            double Height = double.Parse(personTraits[2]);
            bool IsMarried = bool.Parse(personTraits[3]);
            int NoOfChildren = int.Parse(personTraits[4]);

            Person person = new Person(Name, BirthDate, Height, IsMarried, NoOfChildren);
            return person;
        }
        public void SavePersons(Person[] persons)
        {
            using StreamWriter sw = new StreamWriter(DataFileName);
            for (int i = 0; i < persons.Length; i++)
            {
                string lineToSave = persons[i].MakeTitle();
                sw.WriteLine(lineToSave);
            }
        }
        public Person[] LoadPersons()
        {
            using StreamReader sr = new StreamReader(DataFileName);
            Person[] persons = new Person[6]; //arrayets længde er 6 fordi der i testmetoden er defineret 6 linjer
            int i = 0;

            while (!sr.EndOfStream)
            {
                string lineToLoad = sr.ReadLine();

                string[] personTraits = lineToLoad.Split(';');

                string Name = personTraits[0];
                DateTime BirthDate = DateTime.Parse(personTraits[1]);
                double Height = double.Parse(personTraits[2]);
                bool IsMarried = bool.Parse(personTraits[3]);
                int NoOfChildren = int.Parse(personTraits[4]);

                persons[i] = new Person(Name, BirthDate, Height, IsMarried, NoOfChildren);

                i++;
            }
            return persons;
        }
        
         
         
         namespace Persistens2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Anders Andersen", new DateTime(1975, 8, 24), 175.9, true, 3);
            
            DataHandler handler = new DataHandler("Data.txt");
            handler.SavePerson(person);

            Console.Write("Writing Person: ");
            Console.WriteLine(person.MakeTitle());

            Console.ReadLine();
        }
    }
}
         
         
    }
}
*/
