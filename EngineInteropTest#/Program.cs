using System.Runtime.InteropServices;

public class Program
{
    [DllImport(@"TestInterop.dll"),]
    public static extern void ExterFuncs(int hash, IntPtr[] Import, IntPtr[] Export);

    delegate void FunctionPrintText(string a);

    delegate void FunctionTest(int a);



    public delegate void PrintToConsoleCDelegate(string a);

    public static void PrintToConsoleC(string a)
    {
        Console.WriteLine(a);
    }







    static void Main()
    {

        IntPtr[] array1 = new IntPtr[2];
        IntPtr[] array2 = new IntPtr[2];
        PrintToConsoleCDelegate del = PrintToConsoleC;
        array2[0] = Marshal.GetFunctionPointerForDelegate(del);
        ExterFuncs(40000, array1, array2);

        FunctionTest PrintNum = (FunctionTest)Marshal.GetDelegateForFunctionPointer(array1[1], typeof(FunctionTest));
        FunctionPrintText PrintText = (FunctionPrintText)Marshal.GetDelegateForFunctionPointer(array1[0], typeof(FunctionPrintText));

        PrintNum(5);
        PrintText("Hello");
    }
}
