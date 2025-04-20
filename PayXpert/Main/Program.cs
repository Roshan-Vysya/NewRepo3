using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayXpert.DAO;
using PayXpert.Entities;
using System;
using PayXpert.DAO;
using PayXpert.Entities;

namespace PayXpert
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeService = new EmployeeService();
            var payrollService = new PayrollService();

            while (true)
            {
                Console.WriteLine("\n--- PayXpert Application Menu ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Retrieve Employee");
                Console.WriteLine("3. Generate Payroll");
                Console.WriteLine("4. Remove Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            // Add Employee
                            Console.WriteLine("Enter Employee Details:");

                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Last Name: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Date of Birth (yyyy-MM-dd): ");
                            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                            Console.Write("Gender: ");
                            string gender = Console.ReadLine();

                            Console.Write("Phone Number: ");
                            string phoneNumber = Console.ReadLine();

                            Console.Write("Address: ");
                            string address = Console.ReadLine();

                            Console.Write("Position: ");
                            string position = Console.ReadLine();

                            Console.Write("Joining Date (yyyy-MM-dd): ");
                            DateTime joiningDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Termination Date (yyyy-MM-dd): ");
                            DateTime terminationDate = DateTime.Parse(Console.ReadLine());

                            var newEmployee = new Employee
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                DateOfBirth = dateOfBirth,
                                Gender = gender,
                                PhoneNumber = phoneNumber,
                                Address = address,
                                Position = position,
                                JoiningDate = joiningDate,
                                TerminationDate = terminationDate
                            };

                            int newEmployeeId = employeeService.AddEmployee(newEmployee);
                            Console.WriteLine($"Employee added successfully with ID: {newEmployeeId}");
                            break;


                        case "2":
                            // Retrieve Employee
                            Console.Write("Enter Employee ID to retrieve: ");
                            int employeeId = int.Parse(Console.ReadLine());
                            var retrievedEmployee = employeeService.GetEmployeeById(employeeId);
                            if (retrievedEmployee != null)
                            {
                                Console.WriteLine($"Retrieved Employee: {retrievedEmployee.FirstName} {retrievedEmployee.LastName}, Age: {retrievedEmployee.CalculateAge()}");
                            }
                            else
                            {
                                Console.WriteLine("Employee not found.");
                            }
                            break;

                        case "3":
                            // Generate Payroll
                            Console.Write("Enter Employee ID for payroll: ");
                            int payrollEmployeeId = int.Parse(Console.ReadLine());
                            var payroll = payrollService.GeneratePayroll(payrollEmployeeId, new DateTime(2025, 4, 1), new DateTime(2025, 4, 15));
                            Console.WriteLine($"Generated Payroll: Net Salary = {payroll.NetSalary}");
                            break;

                        case "4":
                            // Remove Employee
                            Console.Write("Enter Employee ID to remove: ");
                            int removeEmployeeId = int.Parse(Console.ReadLine());
                            employeeService.RemoveEmployee(removeEmployeeId);
                            Console.WriteLine("Employee removed successfully.");
                            break;

                        case "5":
                            // Exit
                            Console.WriteLine("Exiting application...");
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                    }
                }
            }
        }
    }
}


    