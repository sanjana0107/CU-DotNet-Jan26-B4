using Microsoft.AspNetCore.Mvc;
using StudentManagementMVC.ViewModel;
using StudentManagementMVC.Models;

namespace StudentManagementMVC.Services
{
    public class StudentHttpService
    {
        private readonly HttpClient _client;

        private readonly string _endpoint = "/api/students";
        public StudentHttpService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> Create(StudentViewModel student)
        {
            var response = await _client.PostAsJsonAsync(_endpoint,student);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAll()
        {
            var response = await _client.GetAsync(_endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetById(int id)
        {
            var response = await _client.GetAsync($"{_endpoint}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(Student student)
        {
            var response = await _client.PutAsJsonAsync(_endpoint, student);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(Student student)
        {
            var response = await _client.DeleteAsync($"{_endpoint}/{student.Id}");
            response.EnsureSuccessStatusCode();
            return "Entry deleted successfully";
        }

    }
}
