using System.Data.Entity;

namespace TestNinja.Mocking
{
	public class EmployeeController
	{
		private IEmployeeStorage _empStorage;

		public EmployeeController(IEmployeeStorage empStorage)
		{
			_empStorage = empStorage ?? new EmployeeStorage();
		}

		public ActionResult DeleteEmployee(int id)
		{
			_empStorage.DeleteEmployee(id);
			return RedirectToAction("Employees");
		}

		private ActionResult RedirectToAction(string employees)
		{
			return new RedirectResult();
		}
	}

	public class ActionResult { }

	public class RedirectResult : ActionResult { }

	public class EmployeeContext
	{
		public DbSet<Employee> Employees { get; set; }

		public void SaveChanges()
		{
		}
	}

	public class Employee
	{
	}
}