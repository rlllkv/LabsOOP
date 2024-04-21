using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
class Program1
{
    static void Main()
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        var client = new HttpClient(); 
        client.DefaultRequestHeaders.Add("User-Agent", "MyApp");
        // Запрос вакансий по компании "МГТУ СТАНКИН"
        HttpResponseMessage response = client.GetAsync("https://api.hh.ru/vacancies?employer_id=3094855").Result; 
        string json = response.Content.ReadAsStringAsync().Result;
        File.WriteAllText("vacancies_mgtu_stankin_sync.json", json); // Сохраняем ответ в файл Console.WriteLine("Ответ от API hh.ru по запросу 'МГТУ СТАНКИН' сохранен в файл vacancies_mgtu_stankin_sync.json");
        timer.Stop();
        Console.WriteLine("Время работы " + timer.ElapsedMilliseconds + "ms");
    }
}