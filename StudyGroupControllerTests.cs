
namespace TestAppAPI
{
    [TestFixture]
    public class StudyGroupControllerTests
    {
        private Mock<IStudyGroupRepository> _studyGroupRepositoryMock;
        private StudyGroupController _studyGroupController;

        [SetUp]
        public void Setup()
        {
            _studyGroupRepositoryMock = new Mock<IStudyGroupRepository>();
            _studyGroupController = new StudyGroupController(_studyGroupRepositoryMock.Object);
        }

        [Test]
        public async Task CreateStudyGroup_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var studyGroup = new StudyGroup(1, "StudyGroup1", Subject.Chemistry, DateTime.Now, new List<User>());

            // Act
            var result = await _studyGroupController.CreateStudyGroup(studyGroup);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task GetStudyGroups_ReturnsOkObjectResult()
        {
            // Arrange
            var expectedStudyGroups = new List<StudyGroup>();

            _studyGroupRepositoryMock.Setup(repo => repo.GetStudyGroups())
                .ReturnsAsync(expectedStudyGroups);

            // Act
            var result = await _studyGroupController.GetStudyGroups() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(expectedStudyGroups, result.Value);
        }

        [Test]
        public async Task SearchStudyGroups_ValidSubject_ReturnsOkObjectResult()
        {
            // Arrange
            var expectedStudyGroups = new List<StudyGroup>();
            var subject = "Physics";

            _studyGroupRepositoryMock.Setup(repo => repo.SearchStudyGroups(subject))
                .ReturnsAsync(expectedStudyGroups);

            // Act
            var result = await _studyGroupController.SearchStudyGroups(subject) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(expectedStudyGroups, result.Value);
        }

        [Test]
        public async Task JoinStudyGroup_ValidIds_ReturnsOkResult()
        {
            // Arrange
            var studyGroupId = 1;
            var userId = 10;

            // Act
            var result = await _studyGroupController.JoinStudyGroup(studyGroupId, userId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task LeaveStudyGroup_ValidIds_ReturnsOkResult()
        {
            // Arrange
            var studyGroupId = 1;
            var userId = 10;

            // Act
            var result = await _studyGroupController.LeaveStudyGroup(studyGroupId, userId);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}