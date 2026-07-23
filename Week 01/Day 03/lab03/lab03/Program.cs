namespace lab03
{
    public record TaskItem(int Id, string Title);

    public interface IReportable
    {
        void PrintReport();
    }

    public class Employee : IReportable
    {
        private string _name;

        public Employee(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public void PrintReport()
        {
            Console.WriteLine("Employee: " + _name);
        }
    }

    public class Department : IReportable
    {
        private string _deptName;

        public Department(string deptName)
        {
            _deptName = deptName;
        }

        public void PrintReport()
        {
            Console.WriteLine("Department: " + _deptName);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TaskItem myTask = new TaskItem(1, "Lab Task");
            Console.WriteLine(myTask.Title);

            IReportable emp = new Employee("Jana");
            emp.PrintReport();

            IReportable dept = new Department("IT");
            dept.PrintReport();
        }
    }
}
