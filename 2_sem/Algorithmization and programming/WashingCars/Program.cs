class Program
{
    static List<Car> cars = new List<Car>();
    delegate void WashCars(Garage garage);
    delegate void WashOne(Garage garage, Car car);
    static void Main(string[] args)
    {
        cars.Add(new Car("Car 1"));
        cars.Add(new Car("Car 2"));
        Garage garage = new Garage("Garage", cars);

        Console.WriteLine("Мойка всех машин по гаражу");
        Console.WriteLine();
        WashCars washAllCars = new CarWash().WashByGarage;
        Console.WriteLine();
        washAllCars(garage);
        Console.WriteLine();

        Console.WriteLine("Мойка одной машины");
        WashOne washone = new CarWash().WashByCar;
        washone(garage, cars[1]);
        Console.WriteLine();
    }
}

class Car
{
    private String Name { get; set; }

    public Car(String name)
        Name = name;

    public String getName()
        return Name;

}

class Garage
{
    private String Name { get; set; }
    private List<Car> Cars = new List<Car>();

    public Garage(String name, List<Car> cars)
    {
        Name = name;
        Cars = cars;
    }

    public void WashAllCars()
    {
        for (int i = 0; i < Cars.Count; i++)
        {
            Console.WriteLine("Машина под номером " + Cars[i].getName() + " помыта");
        }
    }
    public void WashSingleCar(Car car)
    {
        Console.WriteLine("Машина под номером " + car.getName() + " помыта");
    }

    public String getName()
        return Name;
}

class CarWash
{
    public void WashByGarage(Garage garage)
    {
        Console.WriteLine("Все машины из гаража, называемого <<" + garage.getName() + ">> на мойке");
        garage.WashAllCars();
    }

    public void WashByCar(Garage garage, Car car)
    {
        Console.WriteLine("Машина под номером " + car.getName() + " из гаража, называемого <<" + garage.getName() + ">> на мойке");
        garage.WashSingleCar(car);
    }
}
