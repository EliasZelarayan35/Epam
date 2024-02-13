using System;
using System.Collections.Generic;

namespace TestApp
{
    [TestFixture]
    public class StudyGroupTests
    {
        [Test]
        public void AddUser_UserAdded_UserInList()
        {
            // Arrange
            var studyGroup = new StudyGroup(1, "StudyGroup1", Subject.Chemistry, DateTime.Now, new List<User>());
            var user = new User(1, "John");

            // Act
            studyGroup.AddUser(user);

            // Assert
            Assert.Contains(user, studyGroup.Users);
        }

        [Test]
        public void RemoveUser_UserRemoved_UserNotInList()
        {
            // Arrange
            var user = new User(1, "John");
            var studyGroup = new StudyGroup(1, "StudyGroup1", Subject.Chemistry, DateTime.Now, new List<User> { user });

            // Act
            studyGroup.RemoveUser(user);

            // Assert
            Assert.IsFalse(studyGroup.Users.Contains(user));
        }
    }
}