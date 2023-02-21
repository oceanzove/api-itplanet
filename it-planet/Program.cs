using System.Net;
using System.Text;
using it_planet.configs;
using it_planet.repository;
using it_planet.repository.postgres;
using Newtonsoft.Json;
using Npgsql;

const string CONFIG_FILE_PATH = "configs/config.json";

// загрузка конфига
var config = new Config();
config.Load(CONFIG_FILE_PATH);

// соединение с базой данных и его проверка
var database = new PostgresDatabase(config);

// создание слоя handler, service, repository
var repository = new Repository(database);

var account = repository.Account.Get("execaus@gmail.com", "1234");
Console.WriteLine(account.Email);

// запустить сервер (слушателя на порт)

// отключение сервера (безопасно самостоятельно разорвать соединение с базой данных)





















var connectionString = "Host=localhost;Username=postgres;Password=1234;Database=2023_it_planeta";
var connection = new NpgsqlConnection(connectionString);
try
{
    connection.Open();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}
Console.WriteLine("Connection to database successful...");

var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8080/");
listener.Start();
Console.WriteLine("Server is listener...");

while (true)
{
    Console.WriteLine("Waiting request...");
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;

    var requestParams = request.QueryString;
    var method = request.HttpMethod;
    var endPoint = request.RawUrl;
    if (endPoint == null)
    {
        throw new Exception("end point is null");
    }

    if (endPoint == "/locations")
    {
        if (method == "POST")
        {
            string body;
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                body = reader.ReadToEnd();
            }
            CreateLocationInput? input = JsonConvert.DeserializeObject<CreateLocationInput>(body);
            if (input == null)
            {
                throw new Exception("error deserialize object");
            }
            
            // Запрос на добавление данных в таблицу
            
            long id = 0;
            // 1. Создать запрос
            var command = new NpgsqlCommand("INSERT INTO \"LocationPoint\" (latitude, longitude) " +
                                                    "VALUES (@latitude, @longitude) RETURNING id", connection);
            
            // 2. В запрос подставить данные, которые мы получили
            command.Parameters.AddWithValue("latitude", input.latitude);
            command.Parameters.AddWithValue("longitude", input.longitude);
            
            // 3. Выполнить запрос
            var queryReader = command.ExecuteReader();
            var isMoveCursorSuccess = queryReader.Read();
            if (isMoveCursorSuccess)
            {
                var idString = queryReader["id"].ToString();
                if (idString == null)
                {
                    throw new Exception("id is null");
                }
                id = long.Parse(idString);
            }

            var output = new CreateLocationOutput();
            output.id = id;
            output.latitude = input.latitude;
            output.longitude = input.longitude;
            
            var outputString = JsonConvert.SerializeObject(output);
            var buffer = Encoding.UTF8.GetBytes(outputString);

            response.StatusCode = (int)HttpStatusCode.Created;
            using (var outputStream = response.OutputStream)
            {
                outputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}

class CreateLocationInput
{
    public double latitude { get; set; }
    public double longitude { get; set; }
}

class CreateLocationOutput
{
    public long id { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
}

 