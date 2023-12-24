using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using CodeAnalyzer.Parser;

namespace Parser
{
    //change to internal
    public class JavaParser : IParser
    {
        public IUASTNode Parse(FileInfo file)
        {
            if (!File.Exists(file?.FullName)) return null;

            var lexer = new Java8Lexer(CharStreams.fromPath(file.FullName));
            var tokens = new CommonTokenStream(lexer);
            var parser = new Java8Parser(tokens);
            var context = parser.compilationUnit();
            if (parser.NumberOfSyntaxErrors > 0) return null;
            var walker = new ParseTreeWalker();
            var listener = new JavaParserListener();
            walker.Walk(listener, context);
            return listener.GetRoot();
        }
    }
}
