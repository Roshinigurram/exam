using System;

namespace entityframeworkForAssesmemt
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();

            var data=class1.GetEmployees();
            foreach (var item in data)
            {
                Console.WriteLine(item.EmpId + "|" +item.EmpName);

            }
        }
    }
}
