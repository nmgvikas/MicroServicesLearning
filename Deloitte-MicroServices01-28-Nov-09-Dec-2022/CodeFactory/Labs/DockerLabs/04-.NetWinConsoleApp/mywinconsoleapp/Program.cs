// See https://aka.ms/new-console-template for more information
Console.WriteLine("A .NET Dockerized App on Windows");

for(int i =1 ; i <=180; i++){

    Thread.Sleep(1000);
    Console.WriteLine($"Counter \t {i.ToString()}");
}
