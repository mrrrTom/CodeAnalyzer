using Parser;

namespace CodeAnalyzer.Analyzer
{
    public abstract class AbstractASTAnalyzer
    {
        /// <summary>
        /// Returns summary after analyzing tree
        /// </summary>
        /// <param name="tree">Tree to analyze</param>
        /// <returns>Summary</returns>
        public string GetSummury(IUASTNode tree)
        {
            return GetAnalyzationResult(tree);
        }

        /// <summary>
        /// Algorithm to get summary from tree
        /// </summary>
        /// <param name="tree">Tree to analyze</param>
        /// <returns>Summary</returns>
        public abstract string GetAnalyzationResult(IUASTNode tree); 
    }
}
