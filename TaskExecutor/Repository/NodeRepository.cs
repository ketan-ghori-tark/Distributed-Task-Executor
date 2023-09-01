using TaskExecutor.Models;

namespace TaskExecutor.NewFolder
{
    public class NodeRepository
    {
        private static readonly List<Node> _nodes = new List<Node>();

        public void AddNode(Node node)
        {
            _nodes.Add(node);
        }

        public Node RemoveNode(string name)
        {
            Node nodeToRemove = _nodes.FirstOrDefault(_ => _.Name.Equals(name));
            if (nodeToRemove != null)
            {
                _nodes.Remove(nodeToRemove);
                return nodeToRemove;
            }

            throw new Exception("Worker with the Name: " + name + " not found");
        }

        public List<Node> GetAllNodes()
        {
            return _nodes;
        }

        public List<Node> GetAllActiveNodes()
        {
            return _nodes.Where(_ => _.Status == NodeStatus.Available || _.Status == NodeStatus.Busy).ToList();
        }

        public Node GetAvailableNode()
        {
            return _nodes.FirstOrDefault(_ => _.Status == NodeStatus.Available);
        }
    }
}
