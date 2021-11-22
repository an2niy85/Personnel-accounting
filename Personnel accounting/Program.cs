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
            string fullName;
            string position;
            string lastName;
            int deleteNumber;
            string[] fullNameArray = new string[0];
            string[] positionArray = new string[0];

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
                        fullName = Console.ReadLine();
                        fullNameArray = AddArray(fullName, fullNameArray);
                        Console.WriteLine("Введите должность:");
                        position= Console.ReadLine();
                        positionArray = AddArray(position, positionArray);
                        break;
                    case 2:
                        Console.WriteLine("Список досье:");
                        OutputArrays(fullNameArray, positionArray);
                        break;
                    case 3:
                        Console.WriteLine("Введите номер удаляемого досье:");
                        deleteNumber = Convert.ToInt32(Console.ReadLine());
                        fullNameArray = DeleteArray(deleteNumber, fullNameArray);
                        positionArray = DeleteArray(deleteNumber, positionArray);
                        break;
                    case 4:
                        Console.WriteLine("Введите фамилию для поиска:");
                        lastName = Console.ReadLine();
                        FindArray(lastName, fullNameArray, positionArray);
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

        static string[] AddArray(string thing, string[] bag)
        {
            string[] tempBag = new string[bag.Length + 1];
            for (int i = 0; i < bag.Length; i++)
            {
                tempBag[i] = bag[i];
            }
            tempBag[tempBag.Length - 1] = thing;
            bag = tempBag;
            return bag;
        }

        static void OutputArrays(string [] arrays, string [] arrays2)
        {
            for (int i = 0; i < arrays.Length; i++)
            {
                Console.WriteLine((i+1) + " "+ arrays[i] + " - " + arrays2[i] + " ");
            }
        }

        static void FindArray(string lastName, string[] fullName, string [] position)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                string[] names = fullName[i].Split(' ');
                string ln = names[names.Length - 1];
                if (ln == lastName)
                {
                    Console.WriteLine("Искомый сотрудник найден");
                    Console.WriteLine((i + 1) + " " + fullName[i] + " - " + position[i]);
                }
            }
        }

        static string[] DeleteArray(int deleteNumber, string[]bag)
        {
            int j = 0;
            string[] tempBag = new string[bag.Length - 1];
            for (int i = 0; i < bag.Length; i++)
            {
                if (i != deleteNumber)
                {
                    tempBag[j++] = bag[i];
                }
            }
            bag = tempBag;
            return bag;
        }
    }
}
