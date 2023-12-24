using Parser;

namespace Tests
{
    [TestClass]
    public class JavaParserTests
    {
        [TestMethod]
        public void ParseEmptyFile()
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, "TestFiles", "empty.java");
            var parser = new JavaParser();
            var tree = parser.Parse(new FileInfo(filePath));
            Assert.IsNotNull(tree);
            Assert.AreEqual(tree.GetNodeType(), NodeType.ClassDeclaration);
            Assert.AreEqual(tree.GetChildCount(), 1);
            var method = tree.GetChildren()[0];
            Assert.IsNotNull(method);
            Assert.AreEqual(method.GetNodeType(), NodeType.MethodDeclaration);
            Assert.AreEqual(method.GetChildCount(), 0);
        }

        [TestMethod]
        public void ParseMultipleAssignmentsFile() 
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, "TestFiles", "multipleAssignments.java");
            var parser = new JavaParser();
            var tree = parser.Parse(new FileInfo(filePath));
            Assert.IsNotNull(tree);
            Assert.AreEqual(tree.GetNodeType(), NodeType.ClassDeclaration);
            Assert.AreEqual(tree.GetChildCount(), 1);
            var method = tree.GetChildren()[0];
            Assert.IsNotNull(method);
            Assert.AreEqual(method.GetNodeType(), NodeType.MethodDeclaration);
            Assert.AreEqual(method.GetChildCount(), 6);
            var lastChild = method.GetChildren()[5];
            Assert.AreEqual(lastChild.GetNodeType(), NodeType.VarAssignment);
        }

        [TestMethod]
        public void ParseNotJavaFile()
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, "TestFiles", "test.cpp");
            var parser = new JavaParser();
            var tree = parser.Parse(new FileInfo(filePath));
            Assert.IsNull(tree);
        }

        [TestMethod]
        public void ParseJavaFile()
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, "TestFiles", "norma.java");
            var parser = new JavaParser();
            var tree = parser.Parse(new FileInfo(filePath));
            Assert.AreEqual(tree.GetNodeType() , NodeType.ClassDeclaration);
            Assert.AreEqual(tree.GetChildCount() , 1);
            var method = tree.GetChildren()[0];
            Assert.AreEqual(4,method.GetChildCount());
            var children = method.GetChildren();
            Assert.AreEqual(NodeType.VarAssignment, children[0].GetNodeType());
            Assert.AreEqual(NodeType.IFStatement, children[1].GetNodeType());
            Assert.AreEqual(NodeType.IFStatement, children[2].GetNodeType());
            Assert.AreEqual(NodeType.IFStatement, children[3].GetNodeType());
            Assert.AreEqual(4, children[1].GetChildCount());
        }

        [TestMethod]
        public void ChecErroredCode()
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, "TestFiles", "compilationErrors.java");
            var parser = new JavaParser();
            var tree = parser.Parse(new FileInfo(filePath));
            Assert.IsNull(tree);
        }

        [TestMethod]
        public void CheckNoFile()
        {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, "TestFiles", "imagine.java");
            var parser = new JavaParser();
            var tree = parser.Parse(new FileInfo(filePath));
            Assert.IsNull(tree);
        }
    }
}