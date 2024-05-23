// See https://aka.ms/new-console-template for more information
using ConsoleAWSSecrets;
using ConsoleAWSSecrets.Helpers;
using ConsoleAWSSecrets.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

Console.WriteLine("Ejemplo secrets manager");
string miSecreto = await HelperSecretManager.GetSecretAsync();
Console.WriteLine(miSecreto);

KeysModel model = JsonConvert.DeserializeObject<KeysModel>(miSecreto);
Console.WriteLine("MySQL: " + model.Mysql);

//Almacenamiento del objeto KeysModel dentro de DY
var provider =
    new ServiceCollection()
    .AddTransient<ClaseTest>()
    .AddSingleton<KeysModel>(x => model)
    .BuildServiceProvider();

//En cualquier clase podemos recuperar las keys,
//En el propio program si necesitamos connectionstring o en 
//cualquier otra clase de inyeccion

var service = provider.GetService<KeysModel>();
string connectionString = service.Mysql;
Console.WriteLine(connectionString);


var test = provider.GetService<ClaseTest>();
Console.WriteLine("Api: " + test.GetValue());