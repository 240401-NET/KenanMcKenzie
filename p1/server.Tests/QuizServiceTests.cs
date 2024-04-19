namespace server.Tests;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using server.Controller;
using server.Interface;
using server.Model;
using server.Service;
using System.Linq;
public class QuizServiceTests
{
    private Mock<IQuizRepository> _mockQuizRepo;
    private Mock<IUserRepository> _mockUserRepo;
    private QuizService _service;

    public QuizServiceTests()
    {
        _mockQuizRepo = new Mock<IQuizRepository>();
        _mockUserRepo = new Mock<IUserRepository>();
        _service = new QuizService(_mockQuizRepo.Object, _mockUserRepo.Object);
    }

    [Fact]
    public async Task GetQuiz_ValidId_ReturnsQuiz()
    {
        // Arrange
        int quizId = 1;
        var expectedQuiz = new Quiz { QuizId = quizId };
        var mockQuizRepo = new Mock<IQuizRepository>();
        mockQuizRepo.Setup(repo => repo.GetQuiz(quizId)).ReturnsAsync(expectedQuiz);

        var service = new QuizService(mockQuizRepo.Object, null);

        // Act
        var result = await service.GetQuiz(quizId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(quizId, result.QuizId);
    }

    [Fact]
    public async Task GetQuiz_InvalidId_ThrowsException()
    {
        // Arrange
        int invalidId = 0;
        var mockQuizRepo = new Mock<IQuizRepository>();
        var service = new QuizService(mockQuizRepo.Object, null);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => service.GetQuiz(invalidId));
    }

}