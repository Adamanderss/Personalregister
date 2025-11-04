namespace Personalregister
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var personalRegister = new PersonalRegister();
			var isRunning = true;

			Console.WriteLine("Välkommen till Personalregistret");

			while (isRunning)
			{
				Console.WriteLine("1: Lägg till ny anställd");
				Console.WriteLine("2: Skriv ut alla anställda");
				Console.WriteLine("3: Avsluta");
				Helper.EmptyRow();

				var input = Console.ReadLine();

				switch (input)
				{
					case "1":
						personalRegister.AddEmployee();
						break;
					case "2":
						personalRegister.ListEmployees();
						break;
					case "3":
						Environment.Exit(0);
						break;
					default:
						Helper.EmptyRow();
						Console.WriteLine("Gör ett menyval:");
						break;
				}
			}
		}
	}

	public class PersonalRegister
	{
		private static List<Employee> Employees { get; set; } = new List<Employee>();

		public void AddEmployee()
		{
			Console.Write("Namn: ");
			var inputName = Console.ReadLine();

			while (string.IsNullOrWhiteSpace(inputName))
			{
				Console.WriteLine("Namnet får inte vara tomt. Försök igen.");
				Helper.EmptyRow();
				Console.Write("Namn: ");
				inputName = Console.ReadLine();
			}

			var isRunning = true;

			while (isRunning)
			{
				Console.Write("Lön: ");
				var inputSalaryIsNumber = int.TryParse(Console.ReadLine(), out int inputSalary);

				if (inputSalaryIsNumber)
				{
					Employees.Add(new Employee { FullName = inputName, Salary = inputSalary });

					Console.WriteLine("Anställd tillagd!");
					Helper.EmptyRow();
					isRunning = false;
				}
				else
				{
					Console.WriteLine("Lönen måste bestå av siffror. Försök igen.");
					Helper.EmptyRow();
					continue;
				}
			}
		}

		public void ListEmployees()
		{
			if (Employees != null && Employees.Any())
			{
				Console.WriteLine("Lista på anställda: ");
				Helper.EmptyRow();

				foreach (var employee in Employees)
				{
					Console.WriteLine($"Namn: {employee.FullName}");
					Console.WriteLine($"Lön: {employee.Salary} kr");
					Helper.EmptyRow();
				}
			}
			else
			{
				Console.WriteLine("Det finns inga anställda tillagda än.");
				Helper.EmptyRow();
			}
		}
	}

	public class Employee
	{
		public string FullName { get; set; }
		public int Salary { get; set; }
	}

	public static class Helper
	{
		public static void EmptyRow()
		{
			Console.WriteLine("");
		}
	}
}