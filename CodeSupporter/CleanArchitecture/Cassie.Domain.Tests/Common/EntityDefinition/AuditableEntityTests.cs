using Cassie.Domain.Common.EntityDefinition;
using System;
using Xunit;

namespace Cassie.Domain.Tests.Common.EntityDefinition
{
    public class MockTestAuditableEntity : AuditableEntity<Guid> { }

    public class AuditableEntityTests
    {
        [Fact]
        public void Should_Set_Created_And_CreatedBy_Correctly()
        {
            //Arrange
            var entity = new MockTestAuditableEntity();
            var createdBy = Guid.NewGuid();
            var created = DateTimeOffset.UtcNow;

            //Act
            entity.CreatedBy = createdBy;
            entity.Created = created;

            //Assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(created, entity.Created);
        }

        [Fact]
        public void Should_Set_LastModified_And_LastModifiedBy_Correctly()
        {
            // Arrange
            var entity = new MockTestAuditableEntity();

            var lastModifiedBy = Guid.NewGuid();
            var lastModified = DateTimeOffset.UtcNow;

            // Act
            entity.LastModifiedBy = lastModifiedBy;
            entity.LastModified = lastModified;

            // Assert
            Assert.Equal(lastModifiedBy, entity.LastModifiedBy);
            Assert.Equal(lastModified, entity.LastModified);
        }
    }
}
