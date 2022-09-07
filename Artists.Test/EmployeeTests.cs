using System.Linq;
using Xunit;

namespace Artists.Test;

public class EmployeeTests
{

    [Fact]
    public void VerifyThatEmployeesExist()
    {

        using var factory = new ContextFactory();
        using var context = factory.CreateContext();

        var employeeCount = context.Employees.Count();
        if (employeeCount != 0)
        {
            Assert.Equal(3, employeeCount);
        }
    }

    [Fact]
    public void Add_WhenCalled_InsertsAnEmployee()
    {

        using var factory = new ContextFactory();
        using var context = factory.CreateContext();

        var employee = new Employee
        {

            FirstName = "Campbell",
            LastName = "Akpan",
            Age = 23
        };

        context.Employees.Add(employee);
        context.SaveChanges();

        var employeeCount = context.Employees.Count();
        if (employeeCount != 0)
        {
            Assert.Equal(4, employeeCount);
        }

        var lastEmployee = context.Employees
                                .OrderBy(emp => emp.Id)
                                .LastOrDefault();
        if (lastEmployee != null)
        {
            Assert.Equal("Campbell", lastEmployee.FirstName);
        }
    }
}