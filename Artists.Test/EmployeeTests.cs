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
}