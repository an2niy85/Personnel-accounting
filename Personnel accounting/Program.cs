using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel_accounting
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            int inputUser;
            string[] fullNames = { "Иванов Иван Иванович", "Петров Петр Петрович", "Сидоров Сидр Сидорович" };
            //string[] fullNames = new string[0];
            string[] positions = { "Шеф", "Администратор", "Программист" };
            //string[] positions = new string[0];
            while (isOpen)
            {
                Console.WriteLine("Отдел кадров.");
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1 - Добавить досье\n2 - Вывести все досье\n3 - Удалить досье\n4 - Поиск по фамилии\n5 - Выход");
                inputUser = Convert.ToInt32(Console.ReadLine());
                switch (inputUser)
                {
                    case 1:
                        Console.WriteLine("Введите ФИО:");
                        string fullName = Console.ReadLine();
                        Console.WriteLine("Введите должность:");
                        string position= Console.ReadLine();
                        AddDossier(fullName, ref fullNames, position, ref positions);
                        break;
                    case 2:
                        Console.WriteLine("Список досье:");
                        OutputDossier(fullNames, positions);
                        break;
                    case 3:
                        if (NotEmptyDossier(fullNames))
                        {
                            Console.WriteLine("Введите номер удаляемого досье:");
                            int deleteNumber = Convert.ToInt32(Console.ReadLine());
                            DeleteDossier(deleteNumber, ref fullNames, ref positions);
                        }                        
                        break;
                    case 4:
                        if (NotEmptyDossier(fullNames))
                        {
                            Console.WriteLine("Введите фамилию для поиска:");
                            string lastName = Console.ReadLine();
                            FindDossier(lastName, fullNames, positions);
                        }
                            break;
                    case 5:
                        isOpen = false;
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void AddDossier(string fullName, ref string[] fullNames, string position, ref string[]positions)
        {
            string[] tempFullNames = new string[fullNames.Length + 1];
            string[] tempPositions = new string[positions.Length + 1];

            for (int i = 0; i < fullNames.Length; i++)
            {
                tempFullNames[i] = fullNames[i];
                tempPositions[i] = positions[i];
            }
            tempFullNames[tempFullNames.Length - 1] = fullName;
            fullNames = tempFullNames;

            tempPositions[tempPositions.Length - 1] = position;
            positions = tempPositions;
        }

        static void OutputDossier(string [] fullNames, string [] positions)
        {
            if (NotEmptyDossier(fullNames))
            {
                for (int i = 0; i < fullNames.Length; i++)
                {
                    Console.WriteLine((i + 1) + " " + fullNames[i] + " - " + positions[i] + " ");
                }
            }
        }

        static void FindDossier(string lastName, string[] fullNames, string [] positions)
        {
            if (NotEmptyDossier(fullNames))
            {
                string[] partNames;
                for (int i = 0; i < fullNames.Length; i++)
                {
                    partNames = fullNames[i].Split(' ');
                    for (int j = 0; j < partNames.Length; j++)
                    {
                        if (partNames[j] == lastName)
                        {
                            Console.WriteLine("Искомый сотрудник найден");
                            Console.WriteLine((i + 1) + " " + fullNames[i] + " - " + positions[i]);
                        }
                    }                   
                }
            }
        }

        static void DeleteDossier(int deleteNumber, ref string[]fullNames, ref string[]positions)
        {
            if (NotEmptyDossier(fullNames))
            {
                int j = 0;
                string[] tempFullNames = new string[fullNames.Length - 1];
                string[] tempPositions = new string[positions.Length - 1];

                for (int i = 0; i < fullNames.Length; i++)
                {
                    if (i != (deleteNumber - 1))
                    {
                        tempFullNames[j] = fullNames[i];
                        tempPositions[j] = positions[i];
                        j++;
                    }
                }
                fullNames = tempFullNames;
                positions = tempPositions;
            }
        }

        static bool NotEmptyDossier(string[]fullNames)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine("Список досье пуст");
                return false;
            }
            else return true;
        }
    }
}
