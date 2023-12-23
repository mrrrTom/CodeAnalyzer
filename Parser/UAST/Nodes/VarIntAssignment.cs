namespace Parser
{
    public class VarIntAssignment : IUASTNode
    {
        private string _varName;
        private int _value;
        private IUASTNode _parent;

        public VarIntAssignment(IUASTNode parent, string name, string value)
        {
            _parent = parent;
            _parent.AddChild(this);
            _varName = name;
            _value = int.Parse(value);
        }

        public void AddChild(IUASTNode child)
        {
        }

        public List<IUASTNode> GetChildren()
        {
            return new List<IUASTNode>();
        }

        public NodeType GetNodeType()
        {
            return NodeType.VarAssignment;
        }

        public IUASTNode GetParent()
        {
            return _parent;
        }

        public int GetChildCount()
        {
            return 0;
        }

        public int GetValue()
        {
            return _value;
        }
    }
}
