public class Main {
    public static void method2(boolean...conditions)
    {
        int x;
        x = 8;
        if (conditions[0])
        {
            x = 11;
            if (conditions[1])
            {
                x = 12;
            }
            x = 14;
            if (conditions[2])
            {
                x = 15;
            }
        }
        if (conditions[3])
        {
            if (conditions[5])
            {
                x = 0;
            }
            x = 6;
        }
        if (conditions[4])
        {
            x = 9;
        }
        System.out.println(x);
    }
}