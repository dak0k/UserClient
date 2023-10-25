using Newtonsoft.Json;
using UserCommon;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в консольный клиент");

        //string result = ApiUtility.GetApiResponseAsync("users").Result;
        string phoneResult = ApiUtility.GetApiResponseAsync("api/phones").Result;
        
        List<Phone> phones = JsonConvert.DeserializeObject<List<Phone>>(phoneResult);

        
        Console.WriteLine("Список телефонов:");

        foreach (var phone in phones)
        {
            Console.WriteLine($"Id: {phone.id}");
            Console.WriteLine($"Brand: {phone.brand}");
            Console.WriteLine($"Model: {phone.model}");
            Console.WriteLine($"Memory: {phone.memory} GB");
            Console.WriteLine($"RAM: {phone.ram} GB");
            Console.WriteLine($"Operating System: {phone.operationSystem}");
            Console.WriteLine($"Processor: {phone.processor}");
            Console.WriteLine($"Price: {phone.price:C}");
            Console.WriteLine($"Amount: {phone.amount}");
            Console.WriteLine();
        }


        //Console.WriteLine(phoneResult);

        Console.ReadKey();
    }


}