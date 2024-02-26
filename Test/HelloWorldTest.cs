using Bunit;
using Xunit;

namespace ConfigurationTool.Test;

public class HelloWorldTest
{
    [Fact]
    public void diff()
    {
        Assert.True(true);
    }
    
    [Fact]
    public void ThisIsATest()
    {
        using var ctx = new TestContext();
        var cut = ctx.RenderComponent<HelloWorld>();
        
        cut.MarkupMatches("@<h1>Hello world from Blazor</h1>");
        Assert.True(true);
    }
}