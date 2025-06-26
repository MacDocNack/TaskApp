using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task = TaskApp.Models.Task;

namespace TaskApp
{
    public class ConnectToWeb
    {
        private static ConnectToWeb _service {  get; set; }
        public static ConnectToWeb Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new ConnectToWeb(); 
                    _client ??= new HttpClient();
                    _baseUrl ??= "http://192.168.0.106:5163";
                }
                return _service;
            }
        }

        private static HttpClient _client;
        private static string _baseUrl;

        public async Task<IReadOnlyCollection<Task>> GetTasksAsync()
        {
            var res = await _client.GetAsync($"{_baseUrl}/api/Task");

            string json = await res.Content.ReadAsStringAsync();
            var task = JsonSerializer.Deserialize<List<Task>>(json);

            return task;
        }
        public async Task<Task> GetTaskById(int id)
        {
            var res = await _client.GetAsync($"{_baseUrl}/api/Task/{id}");

            string json = await res.Content.ReadAsStringAsync();
            var task = JsonSerializer.Deserialize<Task>(json);

            return task;
        }
        public async void TaskPost(Task task)
        {
            await _client.PostAsJsonAsync($"{_baseUrl}/api/Task", task);
        }
        public async void TaskPut(Task task)
        {
            await _client.PutAsJsonAsync($"{_baseUrl}/api/Task/{task.Id}", task);
        }
        public async void TaskDelete(Task task)
        {
            await _client.DeleteAsync($"{_baseUrl}/api/Task/{task.Id}");
        }
    }
}
