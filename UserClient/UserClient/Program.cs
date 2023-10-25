// ������-��������� �����������
// Server - ������/������������ ������
// Console Client - ����������/������������ ������ � Server
// Web Client - 
// WinForm Client - 

using Newtonsoft.Json;
using UserCommon;

internal class Program
{
    private static List<User> _users
    {
        get
        {

            string json = ApiUtility.GetApiResponseAsync("users").Result;

            return JsonConvert.DeserializeObject<List<User>>(json);
        }
    }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");
        app.MapGet("/about", () => "��� ����� ���������� ��� ���!");
        app.MapGet("/users", async (context) =>
        {
            context.Response.ContentType = "text/html; charset=utf-8";

            string htmlResponse =
            $@"���������� ������������� � ����: {_users.Count}";

            foreach (var user in _users)
            {
                htmlResponse += $@"<p>[{user.Id}] {user.Name}</p>";
            }

            context.Response.WriteAsync(htmlResponse);
        });

        app.MapGet("/user/{id}", async (int id, HttpContext context) =>
        {
            context.Response.ContentType = "text/html; charset=utf-8";

            string htmlResponse =
            $@"<h3>{_users[id].Name}</h3>
    <p>��. �����: {_users[id].Email}</p>
    <p>���� ��������: {_users[id].Birthday.ToString()}</p>
    <p>������: {_users[id].Password}</p>
    ";

            context.Response.WriteAsync(htmlResponse);
        });

        app.Run();
    }
}