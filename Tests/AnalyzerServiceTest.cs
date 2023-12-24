using CodeAnalyzer;

namespace Tests
{
    [TestClass]
    public class AnalyzerServiceTest
    {
        [TestMethod]
        public void GetJavaSummary()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            string currentDir = System.IO.Directory.GetCurrentDirectory();
            var filePath = Path.Combine(currentDir, "TestFiles", "test.java");
            var parameters = new string[] { filePath };
            Program.Main(parameters);
            var output = writer.GetStringBuilder().ToString();
            var values = TestsHelper.GetValues(output);
            var valuesToCompare = new int[] { 1, 4, 5, 6 };
            TestsHelper.CheckSame(values, valuesToCompare);
        }
    }
}
