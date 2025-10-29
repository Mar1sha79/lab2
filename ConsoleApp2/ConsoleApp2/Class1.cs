

namespace LaboratoryWork
{
    public class Gun
    {
        private int bullets;

        public int Bullets
        {
            get { return bullets; }
        }

        public Gun()
        {
            bullets = 5;
        }

        public Gun(int initialBullets)
        {
            if (initialBullets >= 0)
            {
                bullets = initialBullets;
            }
            else
            {
                bullets = 0;
            }
        }

        public void Shoot()
        {
            if (bullets > 0)
            {
                Console.WriteLine("Бах!");
                bullets--;
            }
            else
            {
                Console.WriteLine("Клац!");
            }
        }

        public override string ToString()
        {
            return $"Пистолет (патронов: {bullets})";
        }
    }

    public class Person
    {
        private string name;
        private int height;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    name = "Неизвестно";
                }
                else
                {
                    name = value.Trim();
                }
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (value >= 0)
                {
                    height = value;
                }
                else
                {
                    height = 0;
                }
            }
        }

        public Person()
        {
            name = "Неизвестно";
            height = 0;
        }

        public Person(string name, int height)
        {
            Name = name;
            Height = height;
        }

        public override string ToString()
        {
            return $"{name}, рост: {height}";
        }
    }

    public class NameV1
    {
        private string lastName;
        private string firstName;
        private string middleName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null)
                {
                    lastName = "";
                }
                else
                {
                    lastName = value;
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null)
                {
                    firstName = "";
                }
                else
                {
                    firstName = value;
                }
            }
        }

        public string MiddleName
        {
            get { return middleName; }
            set
            {
                if (value == null)
                {
                    middleName = "";
                }
                else
                {
                    middleName = value;
                }
                }
            }

        public NameV1()
        {
            lastName = "";
            firstName = "";
            middleName = "";
        }

        public NameV1(string lastName, string firstName, string middleName)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }

        public override string ToString()
        {
            string result = "";

            if (!string.IsNullOrWhiteSpace(lastName))
                result += lastName;

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                if (result != "")
                    result += " ";
                result += firstName;
            }

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                if (result != "")
                    result += " ";
                result += middleName;
            }

            if (result != "")
                return result;
            else
                return "Имя не указано";
        }
    }

    public class Department
    {
        private string name;
        private Employee manager;
        private Employee[] employees;
        private int employeeCount;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    name = "Без названия";
                }
                else
                {
                    name = value.Trim();
                }
            }
        }

        public Employee Manager
        {
            get { return manager; }
        }

        public int EmployeeCount
        {
            get { return employeeCount; }
        }

        public Department()
        {
            name = "Без названия";
            employees = new Employee[10];
            employeeCount = 0;
        }

        public Department(string name)
        {
            Name = name;
            employees = new Employee[10];
            employeeCount = 0;
        }

        public void SetManager(Employee manager)
        {
            if (manager == null)
            {
                Console.WriteLine("Ошибка: сотрудник не может быть null");
                return;
            }

            this.manager = manager;

            if (FindEmployeeIndex(manager) == -1)
            {
                AddEmployee(manager);
            }
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("Ошибка: сотрудник не может быть null");
                return;
            }

            if (FindEmployeeIndex(employee) == -1)
            {
                if (employeeCount >= employees.Length)
                {
                    Employee[] newArray = new Employee[employees.Length * 2];
                    Array.Copy(employees, newArray, employees.Length);
                    employees = newArray;
                }

                employees[employeeCount] = employee;
                employeeCount++;
                employee.SetDepartment(this);

                Console.WriteLine($"Добавлен сотрудник: {employee.Name}");
                PrintAllEmployees();
            }
            else
            {
                Console.WriteLine($"Сотрудник {employee.Name} уже есть в отделе");
            }
        }

        private int FindEmployeeIndex(Employee employee)
        {
            for (int i = 0; i < employeeCount; i++)
            {
                if (employees[i] == employee)
                {
                    return i;
                }
            }
            return -1;
        }

        public Employee[] GetEmployees()
        {
            Employee[] result = new Employee[employeeCount];
            Array.Copy(employees, result, employeeCount);
            return result;
        }

        public void PrintAllEmployees()
        {
            Console.WriteLine($"--- Все сотрудники отдела '{name}' ---");
            if (employeeCount == 0)
            {
                Console.WriteLine("Сотрудников нет");
            }
            else
            {
                for (int i = 0; i < employeeCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {employees[i]}");
                }
            }
            Console.WriteLine("----------------------------------------");
        }

        public override string ToString()
        {
            return "Отдел '" + name + "' (сотрудников: " + employeeCount + ")";
        }
    }

    public class Employee
    {
        private string name;
        private Department department;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    name = "Неизвестный сотрудник";
                }
                else
                {
                    name = value.Trim();
                }
            }
        }

        public Department Department
        {
            get { return department; }
        }

        public Employee()
        {
            name = "Неизвестный сотрудник";
        }

        public Employee(string name)
        {
            Name = name;
        }

        public void SetDepartment(Department department)
        {
            this.department = department;
        }

        public override string ToString()
        {
            if (department == null)
            {
                return name + " (отдел не назначен)";
            }

            if (department.Manager == this)
            {
                return name + " - начальник отдела '" + department.Name + "'";
            }
            else
            {
                string managerName;
                if (department.Manager == null)
                {
                    managerName = "не назначен";
                }
                else
                {
                    managerName = department.Manager.Name;
                }

                return name + " работает в отделе '" + department.Name + "', начальник которого " + managerName;
            }
        }
    }

    public class NameV2
    {
        private string firstName;
        private string lastName;
        private string middleName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == null)
                {
                    firstName = "";
                }
                else
                {
                    firstName = value;
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == null)
                {
                    lastName = "";
                }
                else
                {
                    lastName = value;
                }
            }
        }

        public string MiddleName
        {
            get { return middleName; }
            set
            {
                if (value == null)
                {
                    middleName = "";
                }
                else
                {
                    middleName = value;
                }
            }
        }

        public NameV2()
        {
            firstName = "";
            lastName = "";
            middleName = "";
        }

        public NameV2(string firstName)
        {
            FirstName = firstName;
            lastName = "";
            middleName = "";
        }

        public NameV2(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            middleName = "";
        }

        public NameV2(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public override string ToString()
        {
            string result = "";

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                result += firstName;
            }

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                if (result != "")
                {
                    result += " ";
                }
                result += middleName;
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                if (result != "")
                {
                    result += " ";
                }
                result += lastName;
            }

            if (result != "")
            {
                return result;
            }
            else
            {
                return "Имя не указано";
            }
        }
    }
}