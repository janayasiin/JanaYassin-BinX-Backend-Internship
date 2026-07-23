namespace lab04
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = 1 , Name ="Jana" , Grade =93 , IsActive=true},
                new Student { Id = 2 , Name ="Noor" , Grade =95 , IsActive=false},
                new Student { Id = 3 , Name ="Shahd" , Grade =92 , IsActive=true},
                new Student { Id = 4 , Name ="Bisan" , Grade =87 , IsActive=true},
                new Student { Id = 5 , Name ="Leen" , Grade =75 , IsActive=true},
                new Student { Id = 6 , Name ="Waad" , Grade =65 , IsActive=false},
                new Student { Id = 7 , Name ="lama" , Grade =80 , IsActive=false},
                new Student { Id = 8 , Name ="tuqa" , Grade =100 , IsActive=true},

            };


            List<string> topStudents = await GetTopStudentsAsync(students, 3);

            Console.WriteLine("\nTop Students in the System:");
            foreach (var name in topStudents)
            {
                Console.WriteLine($"- {name}");
            }

            var activeStudentsCount = students.Where(s => s.IsActive).Count();
            double averageGrade = students.Average(s => s.Grade);

            Console.WriteLine($"\nActive Students Count: {activeStudentsCount}");
            Console.WriteLine($"Overall Average Grade: {averageGrade:F2}");

            Console.WriteLine("\n----------------------------------");
            try
            {
                Console.Write("Enter Student ID to search: ");
                string input = Console.ReadLine();

                int searchId = int.Parse(input);

                var foundStudent = students.First(s => s.Id == searchId);
                Console.WriteLine($"Student Found: {foundStudent.Name} (Grade: {foundStudent.Grade})");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number, not text!");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Error: No student found with this ID.");
            }
            finally
            {
                Console.WriteLine("Search operation completed.");
            }
        }



        public static async Task<List<string>> GetTopStudentsAsync(List<Student> allStudents, int count)
        {
            await Task.Delay(3000);

            var topNames = allStudents
                .OrderByDescending(s => s.Grade)
                .Take(count)
                .Select(s => s.Name)
                .ToList();

            return topNames;
        }
    } }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
        public bool IsActive { get; set; }
    }

