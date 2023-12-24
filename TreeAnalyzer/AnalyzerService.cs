using CodeAnalyzer.Analyzer;
using CodeAnalyzer.Parser;

namespace CodeAnalyzer
{
    internal class AnalyzerService
    {
        private readonly AbstractASTAnalyzer _analyzer;
        private readonly IParser _parser;

        public AnalyzerService(AbstractASTAnalyzer analyzer, IParser parser)
        {
            _analyzer = analyzer;
            _parser = parser;
        }

        /// <summary>
        /// Parses code with input parser and prints out summary from input analyzer.
        /// </summary>
        /// <param name="filePath">Path to the code file to parse</param>
        internal void PrintCodeAnalysis(string filePath)
        {
            var fi = new FileInfo(filePath);
            var ats = _parser.Parse(fi);
            var output = _analyzer.GetSummury(ats);
            Console.WriteLine(output);
        }
    }
}
