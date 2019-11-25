using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using System.Threading.Tasks;

namespace NotebookApp
{
    class Notebook
    {
        public static List<Note> allNotes = new List<Note>(); // все записи

        static void Main(string[] args)
        {
            bool n = true;
            while (n)
            {             
                StartMenu(out string s);
                 
                switch (s)
                {
                    case "1":
                        Console.Clear();
                        Note.CreateNewNote();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Note.EditNote();
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        Note.DeleteNote();
                        Console.Clear();
                        break;
                    case "4":
                        Console.Clear();
                        Note.ReadNote();
                        Console.Clear();
                        break;
                    case "5":
                        Console.Clear();
                        Note.ShowAllNotes();
                        Console.Clear();
                        break;
                    case "6":
                        n = false;
                        break;
                }
                Console.Clear();
            }        

        }

        public static void StartMenu(out string s)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1-создать");
            Console.WriteLine("2-редактировать");
            Console.WriteLine("3-удалить");
            Console.WriteLine("4-посмотреть что-то одно");
            Console.WriteLine("5-посмотреть всё");
            Console.WriteLine("6-выйти");
            Console.Write("Введи нужный пункт:");
            s = Console.ReadLine();
        }
       
    
    }
    
}
