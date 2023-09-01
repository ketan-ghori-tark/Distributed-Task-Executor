namespace TaskExecutor.Models
{
public class Node
{
    public string Name { get; set; }
    public string Address { get; set; }
    public NodeStatus Status { get; set; }

    public Node(String name, String address) : this(name, address, NodeStatus.Available){}

    public Node(String name, String address, NodeStatus nodeStatus) {
        this.Name = name;
        this.Address = address;
        this.Status = nodeStatus;
    }

    public void ChangeStatusTo(NodeStatus nodeStatus)
    {
        Status = nodeStatus;
    }

}

}
