using SaveTestCasesFromRallyToJson.CommonMethods;
using System;

namespace SaveTestCasesFromRallyToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonMethodsClass commonMethods = new CommonMethodsClass();
            commonMethods.SetupApi("your_login", "your_password", "your_url_of_rally");

            Console.WriteLine("Enter parent ID of your test cases: ");
            string id = Console.ReadLine();

            commonMethods.GetAllTestCasesFromFolder(id);
            commonMethods.SaveTestCasesIntoJson();
        }
    }
}