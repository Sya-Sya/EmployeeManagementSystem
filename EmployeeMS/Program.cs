using EmployeeMS;
using EmployeeMS.Interface;
using Serilog;
using static EmployeeMS.Model.EmployeeModel;

namespace EmployeeManagementConsole
{
    class Program
    {
        static void Main(string[] args) //Space Complexity O(1)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            using (var context = new EMSContext())
            {
                while (true)
                {
                    Console.WriteLine("Employee Management System");
                    Console.WriteLine("1. Employee");
                    Console.WriteLine("2. Position");
                    Console.WriteLine("3. Department");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");
                    try
                    {
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                EmployeeOpt(context); //EmployeeOpt => Employee Option
                                break;
                            case 2:
                                PositionOpt(context); //PositionOpt => Position Option
                                break;
                            case 3:
                                DepartmentOpt(context); //DepartmentOpt => Department Option
                                break;
                            case 4:
                                return;
                            default:
                                Console.WriteLine("--------------------------");
                                Console.WriteLine("Please select from above");
                                Console.WriteLine("--------------------------");
                                break;
                        }
                    }
                    catch (Exception exe)
                    {
                        Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Only Numbers are allowed");
                        Console.WriteLine("--------------------------");
                    }
                    finally
                    {
                        Log.CloseAndFlush();
                    }
                }
            }
        }

        #region EMPLOYEE
        static void EmployeeOpt(EMSContext context) //Space and Time Complexity O(1)
        {
            int choice;
            Console.WriteLine("Employee Management");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View Employees");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Exit");
            try
            {
                Console.Write("Enter UserTyp: ");
                string User = Console.ReadLine();

                var employeeRepository = new EmployeeInt(context);
                if (User.ToLower() == "admin")
                {
                    Console.WriteLine("Employee Management");
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. View Employees");
                    Console.WriteLine("3. Update Employee");
                    Console.WriteLine("4. Delete Employee");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddEmployee(employeeRepository);
                            break;
                        case 2:
                            ViewEmployees(employeeRepository);
                            break;
                        case 3:
                            UpdateEmployee(employeeRepository);
                            break;
                        case 4:
                            DeleteEmployee(employeeRepository);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("Please select from above");
                            Console.WriteLine("--------------------------");
                            return;
                    }
                }
                else if (User.ToLower() == "manager")
                {
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. View Employees");
                    Console.WriteLine("3. Update Employee");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice: ");

                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddEmployee(employeeRepository);
                            break;
                        case 2:
                            ViewEmployees(employeeRepository);
                            break;
                        case 3:
                            UpdateEmployee(employeeRepository);
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("Please select from above");
                            Console.WriteLine("--------------------------");
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("1. View Employees");
                    Console.WriteLine("2. Exit");
                    Console.Write("Enter your choice: ");

                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            ViewEmployees(employeeRepository);
                            break;
                        case 2:
                            return;
                        default:
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("Please select from above");
                            Console.WriteLine("--------------------------");
                            return;
                    }
                }
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Only Numbers are allowed");
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        static void AddEmployee(IEmployee context) //Time Complexity O(n) and Space Complexity O(1)
        {
            Console.WriteLine("Enter Employee Details:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Position ID: ");
            int positionId = int.Parse(Console.ReadLine());
            Console.Write("Department ID: ");
            int departmentId = int.Parse(Console.ReadLine());
            Console.Write("Salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            try
            {
                var employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PositionID = positionId,
                    DepartmentID = departmentId,
                    Salary = salary,
                    Email = email,
                    Phone = phone,
                    Address = address
                };
                var employees = context.GetEmployees().ToList();
                context.AddEmployee(employee);
                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Employee added successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static void ViewEmployees(IEmployee context)//Space and Time Complexity O(n), n number of employee retrieved from db
        {
            try
            {
                var employees = context.GetEmployees().ToList();
                if (employees.Count > 0)
                {
                    Console.WriteLine("Employee List:");
                    foreach (var employee in employees)
                    {
                        //Console.WriteLine($"ID: {employee.EmployeeID}, Name: {employee.FirstName} " +
                        //    $"{employee.LastName}, Position ID: {employee.PositionID}, Department ID: {employee.DepartmentID}," +
                        //    $" Salary: {employee.Salary}, Email: {employee.Email}, Phone: {employee.Phone}," +
                        //    $" Address: {employee.Address}");
                        Console.WriteLine("OK");
                    }
                }
                else
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("No employee recored found");
                    Console.WriteLine("--------------------------");
                }
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static void UpdateEmployee(IEmployee context) //Time Complexity O(n) and Space Complexity O(1)
        {
            Console.Write("Enter Employee ID to update: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var employee = context.FindEmployeeById(id);
                if (employee == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                Console.WriteLine("Enter New Employee Details:");
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Position ID: ");
                int positionId = int.Parse(Console.ReadLine());
                Console.Write("Department ID: ");
                int departmentId = int.Parse(Console.ReadLine());
                Console.Write("Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine());
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Phone: ");
                string phone = Console.ReadLine();
                Console.Write("Address: ");
                string address = Console.ReadLine();

                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.PositionID = positionId;
                employee.DepartmentID = departmentId;
                employee.Salary = salary;
                employee.Email = email;
                employee.Phone = phone;
                employee.Address = address;

                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Employee updated successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static void DeleteEmployee(IEmployee context) //Time Complexity O(n) and Space Complexity O(1)
        {
            Console.Write("Enter Employee ID to delete: ");
            try
            {
                int id = int.Parse(Console.ReadLine());

                var employee = context.FindEmployeeById(id);
                if (employee == null)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Employee not found.");
                    Console.WriteLine("--------------------------");
                    return;
                }

                context.RemoveEmployee(employee);
                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Employee deleted successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        #endregion

        #region Position
        static void PositionOpt(EMSContext context) //Space and Time Complexity O(1)
        {
            Console.WriteLine("Employee Management");
            Console.WriteLine("1. Add Position");
            Console.WriteLine("2. View Position");
            Console.WriteLine("3. Update Position");
            Console.WriteLine("4. Delete Position");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                var positionRepository = new PositionInt(context);

                switch (choice)
                {
                    case 1:
                        AddPosition(positionRepository);
                        break;
                    case 2:
                        ViewPositions(positionRepository);
                        break;
                    case 3:
                        UpdatePosition(positionRepository);
                        break;
                    case 4:
                        DeletePosition(positionRepository);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Please select from above");
                        Console.WriteLine("--------------------------");
                        return;
                }
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Only Numbers are allowed");
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static void AddPosition(IPosition context)
        {
            Console.WriteLine("Enter Position Details:");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            try
            {
                var position = new Position
                {
                    Title = title,
                };
                context.AddPosition(position);
                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Position added successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        } //Time Complexity O(n) and Space Complexity O(1)

        static void ViewPositions(IPosition context) //Space and Time Complexity O(n), n number of pos retrieved from db
        {
            try
            {
                var positions = context.GetPositions().ToList();
                if (positions.Count > 0)
                {
                    Console.WriteLine("Employee List:");
                    foreach (var pos in positions)
                    {
                        Console.WriteLine("--------------------------");
                        //Console.WriteLine($"PositionID: {pos.PositionID}, Title: {pos.Title}");
                        Console.WriteLine($"OK");
                        Console.WriteLine("--------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("No employee recored found");
                    Console.WriteLine("--------------------------");
                }
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static void UpdatePosition(IPosition context) //Time Complexity O(n) and Space Complexity O(1)
        {
            Console.Write("Enter Position ID to update: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var position = context.FindPositionById(id);
                if (position == null)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Employee not found.");
                    Console.WriteLine("--------------------------");
                    return;
                }

                Console.WriteLine("Update Position Details:");
                Console.WriteLine("New Title:");
                Console.Write("Title: ");
                string title = Console.ReadLine();
                position.Title = title;
                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Position updated successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static void DeletePosition(IPosition context) //Time Complexity O(n) and Space Complexity O(1)
        {
            Console.Write("Enter Position ID to delete: ");
            try
            {
                int id = int.Parse(Console.ReadLine());

                var position = context.FindPositionById(id);
                if (position == null)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Employee not found.");
                    Console.WriteLine("--------------------------");
                    return;
                }

                context.RemovePosition(position);
                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Position deleted successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        #endregion

        #region Departments
        static void DepartmentOpt(EMSContext context) //Space and Time Complexity O(1)
        {
            Console.WriteLine("Employee Management");
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. View Department");
            Console.WriteLine("3. Update Department");
            Console.WriteLine("4. Delete Department");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            try
            {
                int choice = int.Parse(Console.ReadLine());
                var DepartmentRepository = new DepartmentInt(context);

                switch (choice)
                {
                    case 1:
                        AddDepartment(DepartmentRepository);
                        break;
                    case 2:
                        ViewDepartment(DepartmentRepository);
                        break;
                    case 3:
                        UpdateDepartment(DepartmentRepository);
                        break;
                    case 4:
                        DeleteDepartment(DepartmentRepository);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Please select from above");
                        Console.WriteLine("--------------------------");
                        return;
                }
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Only Numbers are allowed");
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        static void AddDepartment(IDepartment context) //Time Complexity O(n) and Space Complexity O(1)
        {
            Console.WriteLine("Enter Department Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            try
            {
                var dept = new Department
                {
                    Name = name,
                };
                context.AddDepartment(dept);
                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Department added successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        static void ViewDepartment(IDepartment context) //Space and Time Complexity O(n), n number of dep retrieved from db
        {
            try
            {
                var departs = context.GetDepartments().ToList();
                if (departs.Count > 0)
                {
                    Console.WriteLine("Department Lists:");
                    foreach (var dep in departs)
                    {
                        Console.WriteLine("--------------------------");
                        //Console.WriteLine($"DepartmentID: {dep.DepartmentID}, Name: {dep.Name}");
                        Console.WriteLine($"OK");
                        Console.WriteLine("--------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("No Department recored found");
                    Console.WriteLine("--------------------------");
                }
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static void UpdateDepartment(IDepartment context) //Time Complexity O(n) and Space Complexity O(1)
        {
            Console.Write("Enter Department ID to update: ");
            try
            {
                int id = int.Parse(Console.ReadLine());
                var departmentid = context.FindDepartmentById(id);
                if (departmentid == null)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Department not found.");
                    Console.WriteLine("--------------------------");
                    return;
                }

                Console.WriteLine("Update Department Details:");
                Console.WriteLine("New Name:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                departmentid.Name = name;
                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Department updated successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("--------------------------");
                Console.WriteLine("Error occured " + exe);
                Console.WriteLine("--------------------------");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static void DeleteDepartment(IDepartment context) //Time Complexity O(n) and Space Complexity O(1)
        {
            Console.Write("Enter Department ID to delete: ");
            try
            {
                int id = int.Parse(Console.ReadLine());

                var dep = context.FindDepartmentById(id);
                if (dep == null)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Department not found.");
                    Console.WriteLine("--------------------------");
                    return;
                }

                context.RemoveDepartment(dep);
                context.SaveChanges();

                Console.WriteLine("--------------------------");
                Console.WriteLine("Department deleted successfully.");
                Console.WriteLine("--------------------------");
            }
            catch (Exception exe)
            {
                Log.Error(exe, "An error occurred: {ErrorMessage}", exe.Message);
                Console.WriteLine("Error occured " + exe);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        #endregion
    }
}