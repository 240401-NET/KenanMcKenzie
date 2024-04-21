namespace server.Tests;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using server.Controller;
using server.Interface;
using server.Model;
using server.Service;
using server.Data;
using server.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

public class QuizRepositoryTests
{
  private Mock<DbSet<Quiz>> _mockSet;
  private Mock<FreeDbContext> _mockContext;
  private QuizRepository _repo;


  [Theory]
  [InlineData("tag1")]
  [InlineData("TAG1")]
  [InlineData("Tag1")]
  public async Task GetQuizByTagReturnsQuizzesWithMatchingTag(string tagName)
  {
    // 
    var data = new List<Quiz>
        {
            new Quiz { QuizId = 1, Title = "Quiz1", Tags = new List<Tag> { new Tag { TagName = "tag1" } } },
            new Quiz { QuizId = 2, Title = "Quiz2", Tags = new List<Tag> { new Tag { TagName = "tag2" } } }
        };
    Mock<IQuizRepository> repoMock = new Mock<IQuizRepository>();
    //
    repoMock.Setup(repo => repo.GetQuizByTag(tagName))
    .Returns(Task.FromResult(data.Where(q => q.Tags.Any(t =>
    //
    t.TagName.Equals(tagName, StringComparison.OrdinalIgnoreCase))).ToList()));
  }

  [Theory]
  [InlineData(1, true)]
  [InlineData(2, false)]
  public async Task GetQuizGetsQuizById(int quizId, bool shouldExist)
  {
    //
    var quizzes = new List<Quiz>
        {
            new Quiz { QuizId = 1, Title = "Quiz1" }
        };

    Mock<IQuizRepository> repoMock = new Mock<IQuizRepository>();
    //
    repoMock.Setup(repo => repo.GetQuiz(quizId)).ReturnsAsync(quizzes.FirstOrDefault(q => q.QuizId == quizId));
    //
    if (shouldExist)
    {
      Assert.NotNull(await repoMock.Object.GetQuiz(quizId));
    }
    else
    {
      Assert.Null(await repoMock.Object.GetQuiz(quizId));
    }
  }

  [Fact]
  public async Task DeleteQuizWithExistingId()
  {
    Mock<IQuizRepository> repoMock = new Mock<IQuizRepository>();
    var quiz = new Quiz { QuizId = 1, Title = "Quiz1" };
    repoMock.Setup(repo => repo.DeleteQuiz(quiz.QuizId)).ReturnsAsync(quiz);

    var result = await repoMock.Object.DeleteQuiz(quiz.QuizId);

    Assert.Equal(quiz, result);
  }
}