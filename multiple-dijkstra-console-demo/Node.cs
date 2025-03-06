namespace multiple_dijkstra_console_demo;

/// <summary>
/// ノードinterface
/// </summary>
public interface INode
{
    /// <summary>
    /// ノード名
    /// </summary>
    string Name { get; }

    /// <summary>
    /// このノードまでの合計コスト
    /// </summary>
    int TotalCost { get; }

    /// <summary>
    /// 確定フラグ
    /// </summary>
    bool Fixed { get; }

    /// <summary>
    /// このノードを確定ノードにする
    /// </summary>
    void Fix();
}

/// <summary>
/// ノード
/// </summary>
/// <param name="name">ノード名</param>
public class Node(string name) : INode
{
    /// <summary>
    /// ノード名
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    /// 直前のノード
    /// </summary>
    public Node? Previous { get; private set; } = default;

    /// <summary>
    /// このノードまでの合計コスト
    /// </summary>
    public int TotalCost { get; private set; } = int.MaxValue;

    /// <summary>
    /// 確定フラグ
    /// </summary>
    public bool Fixed { get; private set; } = false;

    /// <summary>
    /// このノードを確定ノードにする
    /// </summary>
    public void Fix() => Fixed = true;

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="previous">直前のノード</param>
    /// <param name="edgeCost">通ったエッジのコスト</param>
    public void Update(INode previous, int edgeCost)
    {
        var newTotalCost = edgeCost + previous.TotalCost;

        if (newTotalCost < TotalCost)
        {
            // コスト更新
            TotalCost = newTotalCost;

            // 直前のノード更新(仮想ノードは弾く)
            Previous = (Node?)(previous is Node ? previous : default);
        }
    }
}

/// <summary>
/// 仮想ノード
/// </summary>
/// <remarks>
/// 開始ノード群に対する仮想の開始ノードとして使う。
/// 最終的な経路には含めないものとする。
/// </remarks>
public class VirtualNode : INode
{
    /// <summary>
    /// ノード名
    /// </summary>
    public string Name => "virtual";

    /// <summary>
    /// このノードまでの合計コスト
    /// </summary>
    public int TotalCost => 0;

    /// <summary>
    /// 確定フラグ
    /// </summary>
    public bool Fixed { get; private set; } = false;

    /// <summary>
    /// このノードを確定ノードにする
    /// </summary>
    public void Fix() => Fixed = true;
}
