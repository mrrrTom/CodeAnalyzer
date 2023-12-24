using Parser;

namespace Tests
{
    internal class TestsHelper
    {
        internal static int[] GetValues(string input)
        {
            return input.Split(new char[] { '[', ',', ']' }).Where(x => int.TryParse(x, out int _)).Select(s => int.Parse(s.Trim())).Order().ToArray();
        }

        internal static void CheckSame(int[] left, int[] right)
        {
            Assert.AreEqual(left.Length, right.Length);
            for (int i = 0; i < right.Length; i++)
            {
                Assert.AreEqual(left[i], right[i]);
            }
        }

        internal static IUASTNode GetEmptyTree()
        {
            var classDec = new ClassDeclaration();
            var method = new MethodDeclaration(classDec);
            classDec.AddChild(method);
            return classDec;
        }

        //public static void method2(boolean...conditions)
        //{
        //    int x;
        //    x = 8;
        //    if (conditions[0])
        //    {
        //        x = 11;
        //        if (conditions[1])
        //        {
        //            x = 12;
        //        }
        //        x = 14;
        //        if (conditions[2])
        //        {
        //            x = 15;
        //        }
        //    }
        //    if (conditions[3])
        //    {
        //        if (conditions[5])
        //        {
        //            x = 0;
        //        }
        //        x = 6;
        //    }
        //    if (conditions[4])
        //    {
        //        x = 9;
        //    }
        //    System.out.println(x);
        //}
        internal static IUASTNode GetNormalTree()
        {
            var classDec = new ClassDeclaration();
            var method = new MethodDeclaration(classDec);
            var assign8 = new VarIntAssignment(method, "x", "8");

            var if0 = new IFStatement(method);
            var assign11 = new VarIntAssignment(if0, "x", "11");
            var if1 = new IFStatement(if0);
            var assign12 = new VarIntAssignment(if1, "x", "12");
            var assign14 = new VarIntAssignment(if0, "x", "14");
            var if2 = new IFStatement(if0);
            var assign15 = new VarIntAssignment(if2, "x", "15");

            var if3 = new IFStatement(method);
            var if5 = new IFStatement(if3);
            var assign0 = new VarIntAssignment(if5, "x", "0");
            var assign6 = new VarIntAssignment(if3, "x", "6");

            var if4 = new IFStatement(method);
            var assign9 = new VarIntAssignment(if4, "x", "9");

            return classDec;
        }

        internal static IUASTNode GetTreeWithoutAssignments() 
        {
            var classDec = new ClassDeclaration();
            var method = new MethodDeclaration(classDec);
            var if0 = new IFStatement(method);
            var if1 = new IFStatement(if0);
            var if2 = new IFStatement(if0);
            var if3 = new IFStatement(method);
            var if5 = new IFStatement(if3);
            var if4 = new IFStatement(method);

            return classDec;
        }
    }
}
