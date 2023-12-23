namespace Parser
{
    public class ClassDeclaration : IUASTNode
    {
        private MethodDeclaration _method;

        public NodeType GetNodeType()
        {
            return NodeType.ClassDeclaration;
        }

        public void AddChild(IUASTNode child)
        {
            if (child is MethodDeclaration method) _method = method;
        }

        public List<IUASTNode> GetChildren()
        {
            return new List<IUASTNode> { _method };
        }

        public IUASTNode GetParent()
        {
            // This element can only be the root at current implementation
            return null;
        }

        public int GetChildCount()
        {
            if (_method == null) return 0;
            return 1;
        }
    }
}
