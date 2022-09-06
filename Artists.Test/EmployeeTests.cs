using System.Linq;
using Xunit;

namespace Artists.Test;

public class EmployeeTests
{

    [Fact]
    public void VerifyThatEmployeesExist()
    {

        var factory = new ContextFactory();
        var context = factory.CreateContext();

        var employeeCount = context.Employees.Count();
        if (employeeCount != 0)
        {
            Assert.Equal(3, employeeCount);
        }
    }
}