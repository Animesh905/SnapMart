using Moq;
using SnapMart.Application.Members.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapMart.XUnitTest.Members.Commands
{
    private readonly Mock<>
    public class CreateMemberCommandHandlerTests
    {
        public CreateMemberCommandHandlerTests()
        {
                
        }
        [Fact]
        public void Handle_Should_ReturnFailureResult_WhenEmailIsNotUnique()
        {
            //Arrange
            var command = new CreateMemberCommand("Animesh", "Maity", "9920745669", "animeshmaity905@gmail.com", "@1Arabinda");

            var handler = new CreateMemberCommandHandler();
        }
    }
}
