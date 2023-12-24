namespace Parser
{
    public class MethodDeclaration : IUASTNode
    {
        private List<IUASTNode> _children;
        private IUASTNode _parent;

        public MethodDeclaration(IUASTNode parent)
        {
            _parent = parent;
            _parent.AddChild(this);
        }

        public NodeType GetNodeType()
        {
            return NodeType.MethodDeclaration;
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

        public int GetChildCount()
        {
            if (_children == null || _children.Count == 0) return 0;
            return _children.Count;
        }
    }
}
