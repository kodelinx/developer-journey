using System.Collections.Generic;

List<Asset> assets = new List<Asset>();
int totalAsset;
int counter = 1;
int totalLenovoCount = 0;


Console.WriteLine("\nMULTIPLE ASSET TRACKER\n");

Console.Write("How many Assets you would like to add? ");
totalAsset = Convert.ToInt32(Console.ReadLine());

if (totalAsset > 0)
{
    while (counter <= totalAsset)
    {
        Console.Write("Please input device name: ");
        string deviceName = Console.ReadLine();
        Console.Write("Please input device brand: ");
        string brand = Console.ReadLine();
        Console.Write("Please input device age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Asset asset = new Asset(deviceName, brand, age);

        assets.Add(asset);

        counter++;
    }
}
else
{
    Console.WriteLine("No total assets has been indicated");
}

Console.WriteLine("\n----Asset List----\n");

foreach(Asset asset in assets)
{
    Console.WriteLine($"Device Name: {asset.DeviceName}");
    Console.WriteLine($"Brand: {asset.Brand}");
    Console.WriteLine($"Age: {asset.Age}");

    if(asset.Brand.ToLower() == "lenovo")
    {
        totalLenovoCount++;
    }
}
Console.WriteLine($"\nThere are a total of {totalLenovoCount} Lenovo devices.\n");


class Asset
{
    public string DeviceName { get; set; }
    public string Brand { get; set; }
    public int Age { get; set; }

    public Asset (string deviceName, string brand, int age)
    {
        DeviceName = deviceName;
        Brand = brand;
        Age = age;
    }
}