namespace multiple_dijkstra_console_demo;

public class Edge
{
    /// <summary>
    /// 両端のノード(順不同)
    /// </summary>
    public IEnumerable<INode> Nodes { get; }

    /// <summary>
    /// このエッジのコスト
    /// </summary>
    public int Cost { get; }

    /// <summary>
    /// エッジ(線)
    /// </summary>
    /// <param name="node1">ノード(両端のうちの一つ)</param>
    /// <param name="node2">ノード(両端のうちの一つ)</param>
    /// <param name="cost">エッジのコスト</param>
    public Edge(INode node1, INode node2, int cost)
    {
        if (node1 == node2)
        {
            throw new ArgumentException("同じノードが引数になっています");
        }

        if (cost < 0)
        {
            throw new ArgumentException($"コストがマイナスになっています:{cost}");
        }

        Nodes = [node1, node2];
        Cost = cost;
    }

    /// <summary>
    /// ToString
    /// </summary>
    public override string ToString()
    {
        var from = Nodes.ElementAt(0).Name;
        var to = Nodes.ElementAt(1).Name;
        return $"{from}---({Cost})---{to}";
    }
}
