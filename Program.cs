// See https://aka.ms/new-console-template for more information
using ConsoleAWSSecrets.Helpers;
using ConsoleAWSSecrets.Models;
using Newtonsoft.Json;

Console.WriteLine("Ejemplo secrets manager");
string miSecreto = await HelperSecretManager.GetSecretAsync();
Console.WriteLine(miSecreto);

KeysModel model = JsonConvert.DeserializeObject<KeysModel>(miSecreto);
Console.WriteLine("MySQL: " + model.Mysql);
Console.WriteLine("MySQL: " + model.Mysql);
Console.WriteLine("MySQL: " + model.Mysql);
