using Parser;

namespace CodeAnalyzer.Parser
{
    public interface IParser
    {
        /// <summary>
        /// Gets tree from file
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Unified abstract syntax tree</returns>
        public IUASTNode Parse(FileInfo text);
    }
}
