
using it_planet.configs;
using it_planet.handler;
using it_planet.repository;
using it_planet.repository.postgres;
using it_planet.server;
using it_planet.service;


const string CONFIG_FILE_PATH = "configs/config.json";

// загрузка конфига
var config = new Config();
config.Load(CONFIG_FILE_PATH);

// соединение с базой данных и его проверка
var database = new PostgresDatabase(config);

// создание слоя handler, service, repository
var repository = new Repository(database);
var service = new Service(repository);
var handler = new Handler(service);

var router = handler.GetRouter();
var server = new Server(config, router);

server.Run();

