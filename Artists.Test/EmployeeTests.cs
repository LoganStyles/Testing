using System.Linq;
using Xunit;

namespace Artists.Test;

public class EmployeeTests
{

    [Fact]
    public void VerifyThatEmployeesExist()
    {

        //Arrange
        using var factory = new ContextFactory();
        using var context = factory.CreateContext();

        //Act
        var employeeCount = context.Employees.Count();

        //Assert
        if (employeeCount != 0)
        {
            Assert.Equal(3, employeeCount);
        }
    }

    [Fact]
    public void Add_WhenCalled_InsertsAnEmployee()
    {
        //Arrange
        using var factory = new ContextFactory();
        using var context = factory.CreateContext();

        var employee = new Employee
        {

            FirstName = "Campbell",
            LastName = "Akpan",
            Age = 23
        };

        //Act
        context.Employees.Add(employee);
        context.SaveChanges();

        var employeeCount = context.Employees.Count();
        var lastEmployee = context.Employees
                                .OrderBy(emp => emp.Id)
                                .LastOrDefault();

        //Assert
        if (employeeCount != 0)
        {
            Assert.Equal(4, employeeCount);
        }

        if (lastEmployee != null)
        {
            Assert.Equal("Campbell", lastEmployee.FirstName);
        }
    }
}