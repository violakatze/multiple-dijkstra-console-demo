namespace multiple_dijkstra_console_demo;

/// <summary>
/// Nodeテスト
/// </summary>
public class NodeTest
{
    [Fact]
    public void 通常1()
    {
        var nodeA = new Node("a");

        Assert.Equal("a", nodeA.Name);
        Assert.Equal(int.MaxValue, nodeA.TotalCost);
        Assert.Null(nodeA.Previous);
        Assert.False(nodeA.Fixed);
    }

    [Fact]
    public void 通常2()
    {
        var nodeA = new Node("");

        Assert.Empty(nodeA.Name);
        Assert.Equal(int.MaxValue, nodeA.TotalCost);
        Assert.Null(nodeA.Previous);
        Assert.False(nodeA.Fixed);
    }

    [Fact]
    public void 仮想ノード()
    {
        var nodeStart = new VirtualNode();

        Assert.Equal("virtual", nodeStart.Name);
        Assert.Equal(0, nodeStart.TotalCost);
        Assert.False(nodeStart.Fixed);
    }

    [Fact]
    public void 確定1()
    {
        var nodeA = new Node("a");
        nodeA.Fix();

        Assert.True(nodeA.Fixed);
    }

    [Fact]
    public void 確定2()
    {
        var nodeStart = new VirtualNode();
        nodeStart.Fix();

        Assert.True(nodeStart.Fixed);
    }

    [Fact]
    public void 更新1_通常()
    {
        var nodeStart = new VirtualNode();
        var nodeA = new Node("a");

        nodeStart.Fix();
        nodeA.Update(nodeStart, 0);

        Assert.Equal("a", nodeA.Name);
        Assert.Equal(0, nodeA.TotalCost);
        Assert.Null(nodeA.Previous);
        Assert.False(nodeA.Fixed);
    }

    [Fact]
    public void 更新2_通常()
    {
        var nodeStart = new VirtualNode();
        var nodeA = new Node("a");
        var nodeB = new Node("b");

        nodeStart.Fix();
        nodeA.Update(nodeStart, 0);
        nodeA.Fix();
        nodeB.Update(nodeA, 1);

        Assert.Equal("b", nodeB.Name);
        Assert.Equal(1, nodeB.TotalCost);
        Assert.Equal(nodeA, nodeB.Previous);
        Assert.False(nodeB.Fixed);
    }
}
