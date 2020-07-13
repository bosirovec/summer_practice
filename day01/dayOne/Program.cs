using System;

using System;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

public class Vehicle
{
    public static string garage = "Borna's home garage";
    public string make;
    public string model;
    public int year;
    public float kilometers;
    public virtual void Start()
    {
        Console.WriteLine("*imitaiting the sound of a VEHICLE starting");
    }
    public void GetGarage()
    {
        Console.WriteLine("Name of the garage is '{0}'", garage);
    }
}

public class Car : Vehicle
{
    public int doors;
    public void Drive(int driveKms)
    {
        Console.WriteLine("Driving for {0} kilometers", driveKms);
        this.kilometers += driveKms;
    }
    public override void Start()
    {
        Console.WriteLine("*imitaiting the sound of a CAR starting");
    }
    public Car(string inputMake, string inputModel, int inputYear, float inputKilometers, int inputDoors)
    {
        make = inputMake;
        model = inputModel;
        year = inputYear;
        kilometers = inputKilometers;
        doors = inputDoors;
    }
}

interface IExample
{
    void ExamplePrint();
}
interface IExampleTwo
{
    void ExamplePrintTwo();
}
public class Example : IExample, IExampleTwo
{
    public void ExamplePrint()
    { Console.WriteLine("ExamplePrint"); }
    public void ExamplePrintTwo()
    { Console.WriteLine("ExamplePrintTwo"); }
}


class Program
{
    public static bool EqualTest<T>(T a, T b)
    {
        return a.Equals(b);
    }

    static void Main()
    {
        Car carOne = new Car("Audi", "A3", 2019, 2420.4F, 3);
        carOne.Start();
        carOne.Drive(200);
        Console.WriteLine(carOne.kilometers);
        carOne.GetGarage();

        Example ex = new Example();
        ex.ExamplePrintTwo();

        Console.WriteLine(EqualTest('a', 'b'));


    }
};
