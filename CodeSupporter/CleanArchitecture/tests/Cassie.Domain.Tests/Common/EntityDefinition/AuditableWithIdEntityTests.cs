using Cassie.Domain.Common.EntityDefinition;
using System;
using Xunit;

namespace Cassie.Domain.Tests.Common.EntityDefinition
{
    public class MockTestAuditableWithIdEntity : AuditableWithIdEntity<Guid, Guid> { }

    public class AuditableWithIdEntityTests
    {
        [Fact]
        public void Should_Set_Id_Correctly()
        {
            //Arrange
            var entity = new MockTestAuditableWithIdEntity();
            var createdBy = Guid.NewGuid();
            var created = DateTimeOffset.UtcNow;
            var id = Guid.NewGuid();

            //Act
            entity.CreatedBy = createdBy;
            entity.Created = created;
            entity.Id = id;

            //Assert
            Assert.Equal(entity.Id, id);
        }
    }
}
