namespace Parser
{
    public class IFStatement : IUASTNode
    {
        private IUASTNode _parent;
        private List<IUASTNode> _children;

        public IFStatement(IUASTNode parent)
        {
            _parent = parent;
            _parent.AddChild(this);
        }

        public void AddChild(IUASTNode child)
        {
            if (_children == null)
            {
                _children = new List<IUASTNode>();
            }

            _children.Add(child);
        }

        public List<IUASTNode> GetChildren()
        {
            return _children ?? new List<IUASTNode>();
        }

        public IUASTNode GetParent()
        {
            return _parent;
        }

        public NodeType GetNodeType()
        {
            return NodeType.IFStatement;
        }

        public int GetChildCount()
        {
            if (_children == null ||  _children.Count == 0) return 0;
            return _children.Count;
        }
    }
}
