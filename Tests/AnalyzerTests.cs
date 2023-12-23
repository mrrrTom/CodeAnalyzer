using CodeAnalyzer.Analyzer;

namespace Tests
{
    [TestClass]
    public class AnalyzerTests
    {
        [TestMethod]
        public void CheckSummaryForEmptyTree()
        {
            var analyzer = new PossibleOutputFinder();
            var tree = TestsHelper.GetEmptyTree();
            var summary = analyzer.GetSummury(tree);
            Assert.AreEqual(summary, "[]");
        }

        [TestMethod]
        public void CheckSummaryForTree()
        {
            var analyzer = new PossibleOutputFinder();
            var tree = TestsHelper.GetNormalTree();
            var summary = analyzer.GetSummury(tree);
            var values = TestsHelper.GetValues(summary);
            TestsHelper.CheckSame(values, new int[] { 6, 8, 9, 14, 15 } );
        }

        [TestMethod]
        public void CheckSummaryForTreeWithoutAssignments()
        {
            var analyzer = new PossibleOutputFinder();
            var tree = TestsHelper.GetTreeWithoutAssignments();
            var summary = analyzer.GetSummury(tree);
            Assert.AreEqual(summary, "[]");
        }
    }
}