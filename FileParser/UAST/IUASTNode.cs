namespace Parser
{
    public interface IUASTNode
    {
        /// <summary>
        /// Get node type depending on node class
        /// </summary>
        /// <returns></returns>
        public NodeType GetNodeType();

        /// <summary>
        /// Saves child in the specific order
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(IUASTNode child);

        /// <summary>
        /// Returns all node`s children
        /// </summary>
        /// <returns></returns>
        public List<IUASTNode> GetChildren();

        /// <summary>
        /// Returns the only one parent of the node or null
        /// </summary>
        /// <returns></returns>
        public IUASTNode GetParent();

        /// <summary>
        /// Returns children count and 0 if none
        /// </summary>
        /// <returns></returns>
        public int GetChildCount();
    }
}
