namespace multiple_dijkstra_console_demo;

/// <summary>
/// ダイクストラ(始点複数, 終点複数)
/// </summary>
public class Dijkstra
{
    /// <summary>
    /// 全ノード
    /// </summary>
    public IEnumerable<Node> Nodes { get; }

    /// <summary>
    /// 始点ノード群
    /// </summary>
    public IEnumerable<Node> StartNodes { get; }

    /// <summary>
    /// 終点ノード群
    /// </summary>
    public IEnumerable<Node> EndNodes { get; }

    /// <summary>
    /// 全エッジ
    /// </summary>
    public IEnumerable<Edge> Edges { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nodes"></param>
    /// <param name="startNodes"></param>
    /// <param name="endNodes"></param>
    /// <param name="edges"></param>
    public Dijkstra(IEnumerable<Node> nodes, IEnumerable<Node> startNodes, IEnumerable<Node> endNodes, IEnumerable<Edge> edges)
    {
        if (!nodes.Any())
        {
            throw new ArgumentException("ノードがありません");
        }

        // 始点有無チェック
        if (!startNodes.Any())
        {
            throw new ArgumentException("始点ノードがありません");
        }

        // 終点有無チェック
        if (!endNodes.Any())
        {
            throw new ArgumentException("終点ノードがありません");
        }

        // TODO: 始点と終点が同じチェック

        // TODO: 全ノード中に始点ノードがあることチェック

        // TODO: 全ノード中に終点ノードがあることチェック

        // TODO: 循環チェック

        Nodes = nodes;
        StartNodes = startNodes;
        EndNodes = endNodes;
        Edges = edges;
    }

    /// <summary>
    /// 計算実行
    /// </summary>
    public DijkstraResult Solve()
    {
        var startNode = new VirtualNode();
        var nodes = new List<INode> { startNode };
        nodes.AddRange(Nodes);

        // 仮想ノードから開始ノードまでのエッジを作り、通常エッジと合わせる
        var edges = StartNodes.Select(n => new Edge(startNode, n, 0)).ToList();
        edges.AddRange(Edges);

        while (true)
        {
            // 終点ノードのいずれかが確定していたら終了
            if (EndNodes.FirstOrDefault(n => n.Fixed) is { } goal)
            {
                return new DijkstraResult(goal);
            }

            // 未確定が無ければエラー(異常系)
            var notFixeds = nodes.Where(n => !n.Fixed).ToArray();
            if (notFixeds.Length == 0)
            {
                throw new Exception("未確定ノードがありません");
            }

            // 合計コスト最小のノードを確定する
            var current = notFixeds.First(n => n.TotalCost == notFixeds.Select(n2 => n2.TotalCost).Min());
            current.Fix();

            // 確定ノードに隣接する未確定ノードを更新
            foreach (var edge in edges)
            {
                if (edge.Nodes.FirstOrDefault(n => n.Fixed) is { } previous && edge.Nodes.FirstOrDefault(n => !n.Fixed) is Node next)
                {
                    // 確定と未確定があったら未確定側を更新
                    next.Update(previous, edge.Cost);
                }
            }
        }
    }
}

/// <summary>
/// ダイクストラ計算結果
/// </summary>
/// <param name="goal">終点ノード</param>
public class DijkstraResult(Node goal)
{
    /// <summary>
    /// 合計コスト
    /// </summary>
    public int TotalCost => goal.TotalCost;

    /// <summary>
    /// 最短経路
    /// </summary>
    public string Route => RecursiveGenerateRoute(goal);

    /// <summary>
    /// 最短経路文字列作成
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    private static string RecursiveGenerateRoute(Node node)
    {
        if (node.Previous == default)
        {
            return node.Name;
        }
        else
        {
            return $"{RecursiveGenerateRoute(node.Previous)}-{node.Name}";
        }
    }
}
