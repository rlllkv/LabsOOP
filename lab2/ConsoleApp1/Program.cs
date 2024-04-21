using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
class Program
{
    
    static async Task Main()
    {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        var client = new HttpClient(); 
        client.DefaultRequestHeaders.Add("User-Agent", "MyApp");
        // Запрос вакансий по ключевому слову "developer"
        HttpResponseMessage response1 = await client.GetAsync("https://api.hh.ru/vacancies?text=developer"); 
        string json1 = await response1.Content.ReadAsStringAsync();
        File.WriteAllText("vacancies_developer.json", json1); // Сохраняем ответ в файл
                                                              // Console.WriteLine("Ответ от API hh.ru по запросу 'developer' сохранен в файл vacancies_developer.json");
        // Запрос вакансий по ключевому слову "designer"
        HttpResponseMessage response2 = await client.GetAsync("https://api.hh.ru/vacancies?text=designer"); 
        string json2 = await response2.Content.ReadAsStringAsync();
        File.WriteAllText("vacancies_designer.json", json2); // Сохраняем ответ в файл        Console.WriteLine("Ответ от API hh.ru по запросу 'designer' сохранен в файл vacancies_designer.json");
                                                             // Запрос вакансий по компании "МГТУ СТАНКИН"
        HttpResponseMessage response = await client.GetAsync("https://api.hh.ru/vacancies?employer_id=3094855"); string json = await response.Content.ReadAsStringAsync();
        File.WriteAllText("vacancies_mgtu_stankin.json", json); // Сохраняем ответ в файл        Console.WriteLine("Ответ от API hh.ru по запросу 'МГТУ СТАНКИН' сохранен в файл vacancies_mgtu_stankin.json");
        
        timer.Stop();
        Console.WriteLine("Время работы " + timer.ElapsedMilliseconds + "ms");
    }
}