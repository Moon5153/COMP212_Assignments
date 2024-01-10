using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Program
    {
        public static int index = 0;
        static void Main(string[] args)
        {
            int userInput=0;
            int[] intArray = new int[5];

            //Console Textual Menu
            Console.WriteLine("1. Input values in array of integers");
            Console.WriteLine("2. Input name in array of Student");
            Console.WriteLine("3. Exit the menu");

            Console.WriteLine("\nChoose any one from the Menu: ");
            try
            {
                //Select option from the menu
                userInput = Convert.ToInt32(Console.ReadLine());
                if (userInput == 1)
                {
                    Console.WriteLine("Enter integer values");
                    for (int i = 0; i < intArray.Length; i++)
                    {
                        intArray[i] = Convert.ToInt32(Console.ReadLine());             
                    }

                    Console.WriteLine("Enter the number to be searched: ");
                    int searchElement = Convert.ToInt32(Console.ReadLine());
                    int result = Search(searchElement, intArray);
                    if (result != -1)
                    {
                        Console.WriteLine($"Element found at array index no: {index}");
                    }
                    else
                    {
                        Console.WriteLine("Element not found");
                    }
                }
                else if (userInput == 2)
                {
                    Student[] student = new Student[5];
                    Console.WriteLine("Enter names of the Students");
                    for (int i = 0; i < student.Length; i++)
                    {
                        String str = Console.ReadLine();
                        student[i] = new Student(str);

                    }
                    Console.WriteLine("Enter the name to be searched: ");
                    String names = Console.ReadLine();
                    Student searchName = new Student(names);
                    int result = Search(searchName,student);
                    if (result != -1)
                    {
                        Console.WriteLine($"Element found at array index no: {index}");
                    }
                    else
                    {
                        Console.WriteLine("Element not found");
                    }
                }
                else if (userInput == 3)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid Selection!! Please Select option from the Menu");
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("Invalid Input type!!");
            }
           
    }

        static int Search<T>(T searchKey, T[] inputArray) where T : IComparable
        {
            int n = inputArray.Length;
            for (int i = 0; i < n; i++)
            {
                if (inputArray[i].CompareTo(searchKey) == 0)
                {
                    return i;
                }                 
                index++;
            }
            return -1;

        }
    }

    //Class Student
    class Student : IComparable
    {
        public string name;
        public Student(string str)
        {
            name = str;
        }

        //CompareTo definition for Student Name comparison
        public int CompareTo(object ob)
        {
            if (ob == null)
            {
                return 1;
            }
            Student other = ob as Student;
            if (other != null)
            {
                return this.name.CompareTo(other.name);
            }        
            else
            {
                throw new ArgumentException("Object not equal");
            }
               
        }

    }
}
