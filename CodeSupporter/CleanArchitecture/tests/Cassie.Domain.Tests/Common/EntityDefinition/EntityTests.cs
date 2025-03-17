using Cassie.Domain.Common.EntityDefinition;
using System;
using Xunit;

namespace Cassie.Domain.Tests.Common.EntityDefinition
{
    public class MockTestEntity : Entity<Guid> { }

    public class EntityTests
    {
        [Fact]
        public void Should_Set_Id_Correctly()
        {
            //Arrange
            var entity = new MockTestEntity();
            var id = Guid.NewGuid();

            //Act
            entity.Id = id;

            //Assert
            Assert.Equal(entity.Id, id);
        }
    }
}
