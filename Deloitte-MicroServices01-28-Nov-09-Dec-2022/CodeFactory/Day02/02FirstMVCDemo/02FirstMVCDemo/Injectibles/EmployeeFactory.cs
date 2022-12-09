namespace _02FirstMVCDemo.Injectibles
{
    public interface IEmployeeFactory
    {
        List<Employee> Employees { get; set; }

        Employee Create(Employee employee); 
    }

    public class EmployeeFactory : IEmployeeFactory
    {
        public List<Employee> Employees { get; set; }
        public EmployeeFactory() {
            this.Employees = SimulateEmployeeData();

        }

        public static List<Employee>  SimulateEmployeeData()
        {
            List<Employee> list = new List<Employee>();
            for(int i=1; i <20; i++)
            {
                list.Add(new Employee
                {
                    Id= i,Name="Emp " + i.ToString(),DateOfJoin=DateTime.Now.AddMonths(-30+i),Salary=5.32d+(9d*i)
                });
            }
            return list;

        }

        public Employee Create(Employee employee)
        {
            this.Employees.Add(employee);
            return employee;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoin { get; set; }

        public double Salary { get; set; }
    }
}
