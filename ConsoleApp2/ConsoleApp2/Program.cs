using System;

namespace LaboratoryWork
{
    class Program
    {
        static int ReadInt(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result >= minValue && result <= maxValue)
                    {
                        return result;
                    }

                    else
                    {
                        Console.WriteLine($"Ошибка: введите число от {minValue} до {maxValue}");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: введите целое число");
                }
            }
        }

        static string ReadString(string prompt, bool allowEmpty = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim();

                if (!allowEmpty && string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ошибка: это поле не может быть пустым");
                }

                else
                {
                    return input;
                }
            }
        }

        static void Task1_Gun()
        {
            Console.WriteLine("\n ЗАДАЧА 5.1: ПИСТОЛЕТ ");

            int choice = ReadInt("Выберите тип пистолета (1 - по умолчанию, 2 - с указанием патронов): ", 1, 2);

            Gun gun = choice == 1 ? new Gun() : new Gun(ReadInt("Введите количество патронов: ", 0, 40));
            Console.WriteLine($"Создан: {gun}");

            int shootCount = ReadInt("Сколько раз выстрелить? ", 0, 40);
            for (int i = 1; i <= shootCount; i++)
            {
                Console.Write($"Выстрел {i}: ");
                gun.Shoot();
            }

            Console.WriteLine($"После стрельбы: {gun}");
        }

        static void Task2_Person()
        {
            Console.WriteLine("\n ЗАДАЧА 1.2: ЧЕЛОВЕК ");

            do
            {
                Person person = new Person(ReadString("Введите имя: "),ReadInt("Введите рост (см): ", 20, 250));
                Console.WriteLine($"Создан: {person}");
            }
            while (ReadString("Создать еще одного человека? (да/нет): ").ToLower() == "да");
        }

        static void Task3_NamesV1()
        {
            Console.WriteLine("\n ЗАДАЧА 1.3: ИМЕНА ");

            do
            {
                NameV1 name = new NameV1(
                    ReadString("Введите фамилию (можно пропустить): ", true),
                    ReadString("Введите имя: "),
                    ReadString("Введите отчество (можно пропустить): ", true)
                );
                Console.WriteLine($"Создано имя: {name}");
            }
            while (ReadString("Создать еще одно имя? (да/нет): ").ToLower() == "да");
        }

        static void Task4_Department()
        {
            Console.WriteLine("\n ЗАДАЧА 2.4: СОТРУДНИКИ И ОТДЕЛЫ ");

            do
            {
                Department dept = new Department(ReadString("Введите название отдела: "));

                int employeeCount = ReadInt("Сколько сотрудников добавить в отдел? ", 1, 10);
                for (int i = 0; i < employeeCount; i++)
                {
                    dept.AddEmployee(new Employee(ReadString($"Введите имя сотрудника {i + 1}: ")));
                }

                if (dept.EmployeeCount > 0)
                {
                    Employee[] employees = dept.GetEmployees();
                    for (int i = 0; i < employees.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {employees[i].Name}");
                    }

                    dept.SetManager(employees[ReadInt("Выберите номер начальника отдела: ", 1, employees.Length) - 1]);
                }

                Console.WriteLine(dept);
            }
            while (ReadString("Создать еще один отдел? (да/нет): ").ToLower() == "да");
        }

        static void Task5_NamesV2()
        {
            Console.WriteLine("\n ЗАДАЧА 4.5: ИМЕНА2 ");

            NameV2[] names = new NameV2[10];
            int nameCount = 0;

            do
            {
                int choice = ReadInt("Выберите тип имени (1 - только имя, 2 - имя+фамилия, 3 - полное): ", 1, 3);

                NameV2 newName = choice switch
                {
                    1 => new NameV2(ReadString("Введите имя: ")),
                    2 => new NameV2(ReadString("Введите имя: "), ReadString("Введите фамилию: ")),
                    3 => new NameV2(ReadString("Введите имя: "), ReadString("Введите фамилию: "),ReadString("Введите отчество: "))
                };

                names[nameCount++] = newName;
                Console.WriteLine($"Создано имя: {newName}");
            }
            while (nameCount < 10 && ReadString("Создать еще одно имя? (да/нет): ").ToLower() == "да");

            Console.WriteLine("\nВсе созданные имена:");
            for (int i = 0; i < nameCount; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
            }
        }

        static void Main()
        {
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА 2");

            while (true)
            {
                Console.WriteLine("\nВыберите задачу:");
                Console.WriteLine("1 - Пистолет");
                Console.WriteLine("2 - Человек");
                Console.WriteLine("3 - Имена");
                Console.WriteLine("4 - Сотрудники и отделы");
                Console.WriteLine("5 - Имена2");
                Console.WriteLine("0 - Выход");

                switch (ReadInt("Ваш выбор: ", 0, 5))
                {
                    case 1: Task1_Gun(); break;
                    case 2: Task2_Person(); break;
                    case 3: Task3_NamesV1(); break;
                    case 4: Task4_Department(); break;
                    case 5: Task5_NamesV2(); break;
                    case 0: Console.WriteLine("Выход из программы..."); return;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}