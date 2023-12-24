using Parser;

namespace CodeAnalyzer.Analyzer
{
    public class PossibleOutputFinder : AbstractASTAnalyzer
    {
        public override string GetAnalyzationResult(IUASTNode tree)
        {
            var res = new List<int>();
            CollectAssignments(tree, res);
            var outputResult = "[";
            for (int i = 0; i < res.Count; i++)
            {
                outputResult += res[i];
                if (i < res.Count - 1) outputResult += ", ";
            }

            outputResult += "]";
            return outputResult;
        }

        private void CollectAssignments(IUASTNode tree, List<int> result) 
        {
            var curResult = new List<int>();
            foreach(var child in tree.GetChildren())
            {
                if (child.GetNodeType() == NodeType.VarAssignment)
                {
                    curResult = new List<int>();
                    curResult.Add(((VarIntAssignment)child).GetValue());
                }
                else
                {
                    CollectAssignments(child, curResult);
                }
            }

            result.AddRange(curResult);
        }
    }
}
