namespace multiple_dijkstra_console_demo;

/// <summary>
/// Dijkstraテスト
/// </summary>
public class DijkstraTest
{
    [Fact]
    public void 通常1_始点1終点1()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, };
        var starts = new[] { nodeA };
        var ends = new[] { nodeE };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 7),
            new Edge(nodeA, nodeC, 4),
            new Edge(nodeA, nodeD, 3),
            new Edge(nodeB, nodeC, 1),
            new Edge(nodeB, nodeE, 2),
            new Edge(nodeC, nodeE, 6),
            new Edge(nodeD, nodeE, 5),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(7, result.TotalCost);
        Assert.Equal("a-c-b-e", result.Route);
    }

    [Fact]
    public void 通常2_始点1終点1()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, };
        var starts = new[] { nodeA };
        var ends = new[] { nodeG };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 10),
            new Edge(nodeA, nodeC, 16),
            new Edge(nodeA, nodeD, 12),
            new Edge(nodeB, nodeC, 18),
            new Edge(nodeC, nodeD, 3),
            new Edge(nodeB, nodeE, 10),
            new Edge(nodeC, nodeF, 1),
            new Edge(nodeD, nodeF, 5),
            new Edge(nodeE, nodeG, 6),
            new Edge(nodeF, nodeG, 9),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(25, result.TotalCost);
        Assert.Equal("a-d-c-f-g", result.Route);
    }

    [Fact]
    public void 通常3_始点1終点1()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodeH = new Node("h");
        var nodeI = new Node("i");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI, };
        var starts = new[] { nodeA };
        var ends = new[] { nodeI };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 10),
            new Edge(nodeA, nodeC, 5),
            new Edge(nodeA, nodeD, 2),
            new Edge(nodeB, nodeC, 4),
            new Edge(nodeB, nodeE, 10),
            new Edge(nodeB, nodeG, 3),
            new Edge(nodeC, nodeD, 5),
            new Edge(nodeC, nodeE, 10),
            new Edge(nodeC, nodeF, 17),
            new Edge(nodeD, nodeF, 16),
            new Edge(nodeD, nodeH, 20),
            new Edge(nodeE, nodeF, 2),
            new Edge(nodeE, nodeG, 2),
            new Edge(nodeE, nodeI, 18),
            new Edge(nodeF, nodeH, 6),
            new Edge(nodeF, nodeI, 15),
            new Edge(nodeG, nodeI, 20),
            new Edge(nodeH, nodeI, 10),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(31, result.TotalCost);
        Assert.Equal("a-c-b-g-e-f-i", result.Route);
    }

    [Fact]
    public void 通常4_始点1終点1()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodeH = new Node("h");
        var nodeI = new Node("i");
        var nodeJ = new Node("j");
        var nodeK = new Node("k");
        var nodeL = new Node("l");
        var nodeM = new Node("m");
        var nodeN = new Node("n");
        var nodeO = new Node("o");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI, nodeJ, nodeK, nodeL, nodeM, nodeN, nodeO };
        var starts = new[] { nodeA, };
        var ends = new[] { nodeO, };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 6),
            new Edge(nodeA, nodeC, 10),
            new Edge(nodeA, nodeD, 2),
            new Edge(nodeB, nodeC, 6),
            new Edge(nodeB, nodeE, 16),
            new Edge(nodeB, nodeF, 13),
            new Edge(nodeC, nodeF, 10),
            new Edge(nodeC, nodeG, 16),
            new Edge(nodeC, nodeI, 20),
            new Edge(nodeD, nodeG, 19),
            new Edge(nodeD, nodeJ, 35),
            new Edge(nodeE, nodeF, 5),
            new Edge(nodeE, nodeH, 15),
            new Edge(nodeE, nodeK, 20),
            new Edge(nodeF, nodeH, 20),
            new Edge(nodeF, nodeI, 15),
            new Edge(nodeG, nodeJ, 10),
            new Edge(nodeH, nodeL, 13),
            new Edge(nodeI, nodeL, 15),
            new Edge(nodeI, nodeM, 15),
            new Edge(nodeJ, nodeM, 15),
            new Edge(nodeJ, nodeN, 5),
            new Edge(nodeK, nodeO, 15),
            new Edge(nodeL, nodeO, 5),
            new Edge(nodeM, nodeN, 10),
            new Edge(nodeM, nodeO, 10),
            new Edge(nodeN, nodeO, 15),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(50, result.TotalCost);
        Assert.Equal("a-c-i-l-o", result.Route);
    }

    [Fact]
    public void 通常5_始点2終点1()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, };
        var starts = new[] { nodeA, nodeG };
        var ends = new[] { nodeC };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 10),
            new Edge(nodeA, nodeC, 16),
            new Edge(nodeA, nodeD, 12),
            new Edge(nodeB, nodeC, 18),
            new Edge(nodeC, nodeD, 3),
            new Edge(nodeB, nodeE, 10),
            new Edge(nodeC, nodeF, 1),
            new Edge(nodeD, nodeF, 5),
            new Edge(nodeE, nodeG, 6),
            new Edge(nodeF, nodeG, 9),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(10, result.TotalCost);
        Assert.Equal("g-f-c", result.Route);
    }

    [Fact]
    public void 通常6_始点1終点2()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, };
        var starts = new[] { nodeD };
        var ends = new[] { nodeB, nodeE };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 10),
            new Edge(nodeA, nodeC, 16),
            new Edge(nodeA, nodeD, 12),
            new Edge(nodeB, nodeC, 18),
            new Edge(nodeC, nodeD, 3),
            new Edge(nodeB, nodeE, 10),
            new Edge(nodeC, nodeF, 1),
            new Edge(nodeD, nodeF, 5),
            new Edge(nodeE, nodeG, 6),
            new Edge(nodeF, nodeG, 9),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(19, result.TotalCost);
        Assert.Equal("d-c-f-g-e", result.Route);
    }

    [Fact]
    public void 通常7_始点2終点2()
    {
        var nodeA = new Node("a");
        var nodeB = new Node("b");
        var nodeC = new Node("c");
        var nodeD = new Node("d");
        var nodeE = new Node("e");
        var nodeF = new Node("f");
        var nodeG = new Node("g");
        var nodes = new[] { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, };
        var starts = new[] { nodeA, nodeG };
        var ends = new[] { nodeC, nodeD };
        var edges = new[]
        {
            new Edge(nodeA, nodeB, 10),
            new Edge(nodeA, nodeC, 16),
            new Edge(nodeA, nodeD, 12),
            new Edge(nodeB, nodeC, 18),
            new Edge(nodeC, nodeD, 3),
            new Edge(nodeB, nodeE, 10),
            new Edge(nodeC, nodeF, 1),
            new Edge(nodeD, nodeF, 5),
            new Edge(nodeE, nodeG, 6),
            new Edge(nodeF, nodeG, 9),
        };

        var dijkstra = new Dijkstra(nodes, starts, ends, edges);
        var result = dijkstra.Solve();

        Assert.Equal(10, result.TotalCost);
        Assert.Equal("g-f-c", result.Route);
    }
}
