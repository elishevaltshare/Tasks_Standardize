using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BasicApi.Tests;

public class ProgramTests
{
    [Fact]
    public void SayHello_DBConnectionMissing()
    {
        var result = Program.SayHello();
    }
}