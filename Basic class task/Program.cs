using BaseClassTask;
using System;
using System.Xml;

namespace BaseClassTask
{
    abstract class Worker
    {
        public string Position;
        public string Name;
        public string WorkDay = "";

         
        
        public Worker(string Name)
        {
            this.Name = Name;
        }
        // Call() Method 
        public string Call()
        {
            WorkDay = "Calling";
            return WorkDay;
        }
        
        // WriteCode() Method 
        public string WriteCode()
        {
            WorkDay = "Writing a code";
            return WorkDay;
        }

        // Relax() Method 
        public string Relax()
        {
            WorkDay = "Relaxing";
            return WorkDay;
        }

        // FillWorkDay() Method
        public abstract void FillWorkDay();
            
    }
    class Developer: Worker
    {
        public Developer(string Name): base(Name)
        {
            Position = "Developer";
        }

        public override void FillWorkDay() // overrided method FillWorkDay()
        {
            WorkDay += WriteCode(); // Filling WorkDay with coding 
            WorkDay += " ";
            WorkDay += Call(); // Filling WorkDay with calling 
            WorkDay += " ";
            WorkDay += Relax(); // Filling WorkDay with relaxing 
            WorkDay += " ";
            WorkDay += WriteCode(); // Filling WorkDay with coding 
        }
    }

    class Manager: Worker
    {
        private Random r; // private variable of time Random 
        
        // Public Constructor of class Manager
        public Manager(string Name): base(Name)
        {
            r = new Random(); // creates random number 
            Position = "Manager"; // position of manager is manager 
        }

        // Overrided method FillWorkDay()
        public override void FillWorkDay()
        {
            int rand_number = r.Next(1,11); // random appearing from 1 to 10 
            for(int ind = 0; ind < rand_number; ind++)
            {
                WorkDay += Call(); // Calling Call() method random number of times 
                WorkDay += " ";
                
            } 
            WorkDay += Relax(); // filling WorkDay variable with the Relax() method 
            WorkDay += " ";
            rand_number = r.Next(1,6);

            for(int ind = 0; ind < rand_number; ind++) // rand_number will be some value in the interval for 1 to 5 and we will call this method that number of times which would be generated randomly 
            {
                WorkDay += Call(); // Calling Call() method random number of times 
                WorkDay += " ";
            }
        }
    }

    class Team // Declaration of object Team 
    {
        private string Name_of_Team; // private variable name of the team 
        private int i; // private variable index of our list of employees 
        private Worker[] dict; // private list of empoyee staff 

        // Public Constuctor 
        public Team(string Name_of_Team) 
        {
            this.Name_of_Team = Name_of_Team; // assign to the private variable Name_of_Team value of public variable so it is not null 
            dict = new Worker[20]; // Create list of 20 employee staff 
            i = 0; // index which shows how is our list filled(empty | not) 
        }
        public void AddNewWorker(Worker w) // Method of adding new employee into the team  
        {
            dict[i++] = w; // increase our index inside the dict list and assing the value of object Worker 
        }
        public void PrintInformationAboutTeam()
        {
            Console.WriteLine($"Name of the team: {Name_of_Team}\n");
            for(int ind = 0; ind < i; ind++)
            {
                Console.WriteLine(dict[ind].Name);
            }
            Console.WriteLine();
        }
        public void PrintExtraInformation()
        {
            Console.Write($"Team name: {Name_of_Team}\n");
            
            for(int ind = 0; ind < i; ind++)
            {
                Console.WriteLine($"{dict[ind].Name} - {dict[ind].Position} : {dict[ind].WorkDay}\n");
            }
            Console.Write("\n");
    }
        class DriverProgram
        {
            public static void Main(string[] args)
            {
                Developer d1 = new Developer("Sofia Durdko");
                Developer d2 = new Developer("Michael Lapshyn");
                Developer d3 = new Developer("Mark Fioler");
                Developer d4 = new Developer("Bohdan Oklern");

                Manager m1 = new Manager("Anastasia Geotyr");
                Manager m2 = new Manager("Gleb Sytnyk");
                Manager m3 = new Manager("Kate Megany");
                Manager m4 = new Manager("George Malkwart");

                Team t = new Team("GlobalLogic");

                d1.FillWorkDay();
                d2.FillWorkDay();
                d3.FillWorkDay();
                d4.FillWorkDay();

                m1.FillWorkDay();
                m2.FillWorkDay();
                m3.FillWorkDay();
                m4.FillWorkDay();

                t.AddNewWorker(d1);
                t.AddNewWorker(d4);

                t.AddNewWorker(m1);
                
                t.AddNewWorker(m4);

                t.PrintInformationAboutTeam();
                t.PrintExtraInformation();

                t.AddNewWorker(d2);
                t.AddNewWorker(d3);

                t.PrintInformationAboutTeam();
                t.PrintExtraInformation();

                t.AddNewWorker(m2);
                t.AddNewWorker(m4);

                t.PrintInformationAboutTeam();
                t.PrintExtraInformation();

                Console.ReadKey(true);

            }
        }

    }
    }

    


