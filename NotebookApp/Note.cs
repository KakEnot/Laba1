using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Note
    {
        public static int NoteCount { get; set; } = 0;
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }//необзательное
        public int Phone { get; set; }//только цифры
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }//Date of Birth, необзательное
        public string Organization { get; set; }//необзательное
        public string Post { get; set; } //Должность,необзательное
        public string Notice { get; set; } //заметка

        public override string ToString()
        {
            return $"id: {Id} Фамлия: {Surname} Имя: {Name} Номер телефона: {Phone}";
        }

        public static void CreateNewNote()//Создание новой записи
        {
            Console.Write("Фамилия:");
            string surname = EnterSurname(Console.ReadLine());
            Console.Write("Имя:");
            string name = EnterName(Console.ReadLine());
            Console.Write("Отчество:");
            string middleName = Console.ReadLine();
            Console.Write("Телефон:");
            int phone = EnterPhone(Console.ReadLine());
            Console.Write("Страна:");
            string country = EnterCountry(Console.ReadLine());
            Console.Write("Дата рождения [дд.ММ.гггг]:");
            DateTime dob = EnterDate(Console.ReadLine());
            Console.Write("Организация:");
            string organization = Console.ReadLine();
            Console.Write("Должность:");
            string post = Console.ReadLine();
            Console.Write("Заметки:");
            string notice = Console.ReadLine();

            Note note = new Note(surname, name, middleName, phone, country, dob, organization, post, notice);
            Notebook.allNotes.Add(note);
         

        }

        public Note(string surname, string name, string middlename, int phone, string country, DateTime birhdate, string organization, string post, string notice)
        {
            Id = NoteCount;
            NoteCount++;
            Surname = surname;
            Name = name;
            MiddleName = middlename;
            Phone = phone;
            Country = country;
            Birthdate = birhdate;
            Organization = organization;
            Post = post;
            Notice = notice;
        }
        public static void EditNote()//Редактирование ранее созданной записи
        {
            Console.Write("Введите id записи, которую надо отредактировать:");
            string s = Console.ReadLine();
            int Num;
            bool isNum = int.TryParse(s, out Num);
            while (!isNum)
            {
                Console.Write("id - число, введите еще раз:");
                s = Console.ReadLine();
                isNum = int.TryParse(s, out Num);
            }

            if (!Notebook.allNotes.Exists(x => x.Id == Num))
            {
                Console.WriteLine("Записи с таким id нет!");
            }
            else
            {
                bool n = true;
                while (n)
                {
                    Console.WriteLine($"1-Фамилия: {Notebook.allNotes[Num].Surname} \n2-Имя:{Notebook.allNotes[Num].Name} \n3-Отчество: {Notebook.allNotes[Num].MiddleName}");
                    Console.WriteLine($"4-Телефон {Notebook.allNotes[Num].Phone} \n5-Страна: {Notebook.allNotes[Num].Country} \n6-Дата рождения: {Notebook.allNotes[Num].Birthdate} ");
                    Console.WriteLine($"7-Организация: {Notebook.allNotes[Num].Organization} \n8-Должность: {Notebook.allNotes[Num].Post} \n9-Заметки: {Notebook.allNotes[Num].Notice}");
                    Console.WriteLine("Для выхода нажмите Enter.");
                    Console.Write("Введите номер поля, которое хотите отредактировать:");
                    string s1 = Console.ReadLine();
                    string[] allFields = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "" };
                    while (!allFields.Contains(s1))
                    {
                        Console.Write("Некорректный номер поля, введите еще раз:");
                        s1 = Console.ReadLine();
                    }
                    switch (s1)
                    {
                        case "1":
                            Console.Write("Введите новую Фамилию:");
                            string surname = Console.ReadLine();
                            if (surname.Length != 0)
                            {
                                Notebook.allNotes[Num].Surname = Note.EnterSurname(surname);
                                Console.WriteLine("Поле изменено!");
                            }
                            break;
                        case "2":
                            Console.Write("Введите новое Имя:");
                            string name = Console.ReadLine();
                            if (name.Length != 0)
                            {
                                Notebook.allNotes[Num].Name = Note.EnterName(name);
                                Console.WriteLine("Поле изменено!");
                            }
                            break;
                        case "3":
                            Console.Write("Введите новое Отчество:");
                            string middlename = Console.ReadLine();
                            if (middlename.Length != 0)
                            {
                                Notebook.allNotes[Num].MiddleName = middlename;
                                Console.WriteLine("Поле изменено!");
                            }
                            break;
                        case "4":
                            Console.Write("Введите новый номер телефона:");
                            string phone = Console.ReadLine();
                            if (phone.Length != 0)
                            {
                                Notebook.allNotes[Num].Phone = Note.EnterPhone(phone);
                                Console.WriteLine("Поле изменено!");
                            }
                            break;
                        case "5":
                            Console.Write("Введите новую Страну:");
                            string country = Console.ReadLine();
                            if (country.Length != 0)
                            {
                                Notebook.allNotes[Num].Country = Note.EnterCountry(country);
                                Console.WriteLine("Поле изменено!");
                            }
                            break;
                        case "6":
                            Console.Write("Введите новую Дату рождения:");
                            string dobr = Console.ReadLine();
                            if (dobr.Length != 0)
                            {
                                Notebook.allNotes[Num].Birthdate = EnterDate(dobr);
                            }
                            break;
                        case "7":
                            Console.Write("Введите новую Организацию:");
                            string organization = Console.ReadLine();
                            if (organization.Length != 0)
                            {
                                Notebook.allNotes[Num].Organization = organization;
                                Console.WriteLine("Поле изменено!");
                            }
                            break;
                        case "8":
                            Console.Write("Введите новую Должность:");
                            string post = Console.ReadLine();
                            if (post.Length != 0)
                            {
                                Notebook.allNotes[Num].Post = post;
                                Console.WriteLine("Поле изменено!");
                            }
                            break;
                        case "9":
                            Console.Write("Введите Заметку:");
                            string notice = Console.ReadLine();
                            if (notice.Length != 0)
                            {
                                Notebook.allNotes[Num].Notice = notice;
                                Console.WriteLine("Поле изменено!");
                            }
                            break;
                        case "":
                            n = false; 
                            break;
                    }
                }
                          
            }
            Console.ReadKey();
        }
        public static void DeleteNote()//Удаление ранее созданной записи
        {
            Console.Write("Введите id записи, которую надо удалить:");
            string s = Console.ReadLine();
            int Num;
            bool isNum = int.TryParse(s, out Num);
            while (!isNum)
            {
                Console.Write("id - число, введите еще раз:");
                s = Console.ReadLine();
                isNum = int.TryParse(s, out Num);
            }

            int a = Notebook.allNotes.Count;
            for (int i = 0; i < Notebook.allNotes.Count; i++)
            {
                if (Notebook.allNotes[i].Id == Num)
                {
                    Notebook.allNotes.Remove(Notebook.allNotes[i]);
                    Console.WriteLine($"Запись c id {Num} удалена!");
                }
            }
            if (a == Notebook.allNotes.Count)
            {
                Console.WriteLine($"Записи с id {Num} нет.Удалять нечего!");
            }
            Console.ReadKey();
        }
        public static void ReadNote()//Просмотр созданной записи
        {
            Console.Write("Введите id записи, которую хотите посмотреть:");
            string s = Console.ReadLine();
            if (s!="")
            {
                int Num;
                bool isNum = int.TryParse(s, out Num);
                while (!isNum)
                {
                    Console.Write("id - число, введите еще раз:");
                    s = Console.ReadLine();
                    isNum = int.TryParse(s, out Num);
                }


                if (!Notebook.allNotes.Exists(x => x.Id == Num))
                {
                    Console.WriteLine("Записи с таким id нет!");
                }
                else
                {
                    Console.WriteLine($"Фамилия: {Notebook.allNotes[Num].Surname} \nИмя:{Notebook.allNotes[Num].Name} \nОтчество: {Notebook.allNotes[Num].MiddleName}");
                    Console.WriteLine($"Телефон {Notebook.allNotes[Num].Phone} \nСтрана: {Notebook.allNotes[Num].Country} \nДата рождения: {Notebook.allNotes[Num].Birthdate} ");
                    Console.WriteLine($"Организация: {Notebook.allNotes[Num].Organization} \nДолжность: {Notebook.allNotes[Num].Post} \nЗаметки: {Notebook.allNotes[Num].Notice}");
                }
                Console.ReadKey();
            }            
            
        }
        public static void ShowAllNotes()//Просмотр всех созданных записей в общем списке 
        {
            foreach (var item in Notebook.allNotes)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static string EnterSurname(string surname)
        {
                while (surname.Length == 0 || surname.Trim().Length == 0)
                {
                    Console.Write("Фамилия - обязательное поле. Введите еще раз:");
                    surname = Console.ReadLine();
                }

            
            surname = (char.ToUpper(surname[0]) + surname.Substring(1)).Trim();

            return surname;
        }

        private static string EnterName(string name)
        {

            while (name.Length == 0 || name.Trim().Length == 0)
            {
                Console.Write("Имя - обязательное поле. Введите еще раз:");
                name = Console.ReadLine();
            }

            name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }

        private static int EnterPhone(string phone)
        {
            if (phone.Length == 0)
            {
                while (phone.Length == 0)
                {
                    Console.Write("Телефон-обязательное поле. Только цифры. Введи еще раз:");
                    phone = Console.ReadLine();
                }
            }

            int Num;
            bool isNum = int.TryParse(phone, out Num);
            if (!isNum)
            {
                while (!isNum)
                {
                    Console.Write("Телефон-обязательное поле. Только цифры. Введи еще раз:");
                    phone = Console.ReadLine();
                    isNum = int.TryParse(phone, out Num);
                }
            }
            return Num;
        }

        private static string EnterCountry(string country)
        {

                while (country.Length == 0 || country.Trim().Length == 0)
                {
                    Console.Write("Страна - обязательное поле. Введите еще раз:");
                   country = Console.ReadLine();
                }
           
            
            country = char.ToUpper(country[0]) + country.Substring(1);

            return country;
        }

        private static DateTime EnterDate(string s)
        {
            DateTime dob;
            if (DateTime.TryParse(s, out dob))
            {
                return dob;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
    }
}
