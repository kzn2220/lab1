using System.Text.RegularExpressions;
using пр1;

namespace пр1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();

            do
            {
                if (patients.Count == 0 || AskYesNo("Ввести ещё одного пациента? (y/n): "))
                {
                    Patient patient = InputPatient();
                    patients.Add(patient);
                    PrintPatients(patients);
                }
                else
                {
                    break;
                }
            }
            while (true);

            Console.ReadKey();
        }

        static Patient InputPatient()
        {
            Console.WriteLine("\nВвод данных пациента");

            Patient patient = new Patient();
            patient.Passport = InputPassport();
            patient.Name = InputName();
            patient.BirthDate = InputBirthDate();
            patient.Phone = InputPhone();
            patient.Temperature = InputTemperature();

            return patient;
        }

        static string InputPassport()
        {
            while (true)
            {
                Console.Write("Паспорт: ");
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, @"^\d{2}\s\d{2}-\d{6}$"))
                    return input;
                Console.WriteLine("Ошибка. Введите данные в формате: ss ss-nnnnnn");
            }
        }

        static string InputName()
        {
            while (true)
            {
                Console.Write("Имя: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                Console.WriteLine("Ошибка. Имя не может быть пустым");
            }
        }

        static DateTime InputBirthDate()
        {
            while (true)
            {
                Console.Write("Дата рождения: ");
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out DateTime date))
                    return date;
                Console.WriteLine("Ошибка. Введите данные в формате: yyyy-mm-dd");
            }
        }

        static string InputPhone()
        {
            while (true)
            {
                Console.Write("Телефон: ");
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, @"^\+?\d\(\d{3}\)\s\d{3}-\d{2}-\d{2}$") ||
                    Regex.IsMatch(input, @"^\d\(\d{3}\)\s\d{3}-\d{4}$"))
                    return input;
                Console.WriteLine("Ошибка. Введите данные в формате: +X(XXX) XXX-XX-XX или X(XXX) XXX-XXXX");
            }
        }

        static double InputTemperature()
        {
            while (true)
            {
                Console.Write("Температура: ");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double temp) && temp >= 34 && temp <= 43)
                    return temp;
                Console.WriteLine("Ошибка. Введите данные в формате: XX.XX");
            }
        }

        static void PrintPatients(List<Patient> patients)
        {
            Console.WriteLine("\n=== Список пациентов ===");
            for (int i = 0; i < patients.Count; i++)
            {
                Console.WriteLine($"\nПациент #{i + 1}");
                PrintPatient(patients[i]);
            }
        }

        static void PrintPatient(Patient p)
        {
            Console.WriteLine($"Паспорт:       {p.Passport}");
            Console.WriteLine($"Имя:           {p.Name}");
            Console.WriteLine($"Дата рождения: {p.BirthDate:yyyy-MM-dd}");
            Console.WriteLine($"Телефон:       {p.Phone}");
            Console.WriteLine($"Температура:   {p.Temperature:F2}");
        }

        static bool AskYesNo(string question)
        {
            while (true)
            {
                Console.Write(question);
                string answer = Console.ReadLine()?.Trim().ToLower();
                if (answer == "y") return true;
                if (answer == "n") return false;
                Console.WriteLine("Ошибка. Введите 'y' или 'n'.");
            }
        }
    }
}