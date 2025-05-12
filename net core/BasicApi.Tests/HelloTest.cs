using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using Xunit;

namespace BasicApi.Tests;

public class HelloTests : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public void GetMessage_WithValidConnectionString_ReturnsMessageWithConnection()
    {   
        string dbConnection = "Server=myServer;Database=myDb;";
        // Act
        var result = Logic.GetHelloMessage(dbConnection);
        // Assert
        Assert.Equal("hello word - Server=myServer;Database=myDb;", result);
    }
    [Fact]
    public void GetMessage_WithNullConnectionString_ReturnsMessageWithNull()
    {   
        string? dbConnection = null;
        // Act
        var result = Logic.GetHelloMessage(dbConnection);
        // Assert
        Assert.Equal($"almost there, secret: DB_CONNECTION is not set", result);
    }
    [Fact]
    public void GetMessage_WithEmptyConnectionString_ReturnsMessageWithEmpty()
    {
        string dbConnection = "";
        // Act
        var result = Logic.GetHelloMessage(dbConnection);
        // Assert
        Assert.Equal($"almost there, secret: DB_CONNECTION is not set", result);
    }
}