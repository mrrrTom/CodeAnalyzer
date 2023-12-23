using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
