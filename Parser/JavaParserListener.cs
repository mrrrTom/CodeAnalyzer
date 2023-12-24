using Antlr4.Runtime.Misc;

using static Java8Parser;

namespace Parser
{
    internal class JavaParserListener : Java8ParserBaseListener
    {
        private ClassDeclaration _root;
        private IUASTNode _curParent;

        internal IUASTNode GetRoot() { return _root; }

        public override void EnterClassDeclaration(ClassDeclarationContext context)
        {
            _root = new ClassDeclaration();
        }

        public override void EnterMethodBody([NotNull] MethodBodyContext context)
        {
            if (_root == null) return;
            if (_root.GetNodeType() != NodeType.ClassDeclaration) return;

            var method = new MethodDeclaration(_root);
            _curParent = method;
        }

        public override void ExitMethodBody([NotNull] MethodBodyContext context)
        {
            if (_root == null || _curParent == null) return;
            _curParent = _curParent.GetParent();
        }

        public override void ExitAssignment([NotNull] AssignmentContext context)
        {
            if (_curParent == null) return;
            var varName = context.Start.Text;
            var varValue = context.Stop.Text;
            _ = new VarIntAssignment(_curParent, varName, varValue);
        }

        public override void EnterIfThenStatement([NotNull] IfThenStatementContext context)
        {
            if (_curParent == null) return;
            var ifStatement = new IFStatement(_curParent);
            _curParent = ifStatement;
        }

        public override void ExitIfThenStatement([NotNull] IfThenStatementContext context)
        {
            if (_curParent == null) return;
            _curParent = _curParent.GetParent();
        }
    }
}
