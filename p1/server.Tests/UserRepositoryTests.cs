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

public class UserRepositoryTests
{
  private Mock<DbSet<User>> _mockSet;
  private Mock<FreeDbContext> _mockContext;
  private UserRepository _repo;

  [Fact]
  public async Task GetUserByNameReturnsTrue()
  {
    Mock<IUserRepository> repoMock = new Mock<IUserRepository>();
    var names = new List<User>
    {
        new User { Name = "User1" },
        new User { Name = "User2" }
    };

    repoMock.Setup(repo => repo.GetUserByName("User1")).Returns(Task.FromResult(names.First(u => u.Name == "User1")));
    var result = await repoMock.Object.GetUserByName("User1");
    Assert.Equal("User1", result.Name);
  }
}