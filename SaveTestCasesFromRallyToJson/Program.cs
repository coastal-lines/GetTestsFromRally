using SaveTestCasesFromRallyToJson.CommonMethods;
using System;

namespace SaveTestCasesFromRallyToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonMethodsClass commonMethods = new CommonMethodsClass(login, password, rallyServer);
            commonMethods.SetupApi();

            Console.WriteLine("Enter parent ID of your test cases: ");
            //string id = Console.ReadLine();

            commonMethods.GetAllTestCasesFromFolder("");
            //commonMethods.SaveTestCasesIntoJson();
            commonMethods.SaveTestCasesIntoExcelFile();
        }
    }
}