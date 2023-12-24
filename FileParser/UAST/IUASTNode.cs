namespace Parser
{
    public interface IUASTNode
    {
        public NodeType GetNodeType();
        public void AddChild(IUASTNode child);
        public List<IUASTNode> GetChildren();
        public IUASTNode GetParent();
        public int GetChildCount();
    }
}
