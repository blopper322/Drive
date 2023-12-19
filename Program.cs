using System;

class Car
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Number { get; private set; }
    public string Color { get; private set; }
    private bool isEngineOn = false;
    private int speed = 0;
    private int gear = 0;

    public Car(string brand, string model, string number, string color)
    {
        Brand = brand;
        Model = model;
        Number = number;
        Color = color;
    }

    public void StartEngine()
    {
        if (gear == 0 || gear == 1)
        {
            isEngineOn = true;
            Console.WriteLine("Двигатель заведен.");
        }
        else
        {
            isEngineOn = false;
            Console.WriteLine("Машина заглохла. Необходима нейтральная или первая передача для запуска.");
        }
    }

    public void StopEngine()
    {
        isEngineOn = false;
        Console.WriteLine("Двигатель заглушен.");
    }

    public void Accelerate()
    {
        if (isEngineOn && gear != 0)
        {
            speed += 10;
            Console.WriteLine($"Скорость увеличена до {speed} км/ч.");
        }
        else
        {
            Console.WriteLine("Невозможно ускориться: машина не заведена или на нейтральной передаче.");
        }
    }

    public void Brake()
    {
        if (speed > 0)
        {
            speed -= 10;
            Console.WriteLine($"Скорость уменьшена до {speed} км/ч.");
        }
        else
        {
            Console.WriteLine("Машина уже стоит на месте.");
        }
    }

    public void ChangeGear(int newGear)
    {
        if ((newGear >= -1 && newGear <= 5) && IsSpeedSuitableForGear(newGear))
        {
            gear = newGear;
            Console.WriteLine($"Передача изменена на {newGear}.");
        }
        else
        {
            isEngineOn = false;
            Console.WriteLine("Машина заглохла из-за неправильной скорости для этой передачи.");
        }
    }

    private bool IsSpeedSuitableForGear(int newGear)
    {
        switch (newGear)
        {
            case -1: return speed == 0;
            case 0: return true;
            case 1: return speed <= 30;
            case 2: return speed >= 20 && speed <= 50;
            case 3: return speed >= 40 && speed <= 70;
            case 4: return speed >= 60 && speed <= 90;
            case 5: return speed >= 80;
            default: return false;
        }
    }
}

class Game
{
    private Car car;

    public Game()
    {
        car = new Car("Toyota", "Corolla", "ABC123", "Red");
    }

    public void Run()
    {
        Console.WriteLine("Добро пожаловать в симулятор машины!");
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nВыберите действие: \n1. Завести машину \n2. Заглушить машину \n3. Нажать на газ \n4. Нажать на тормоз \n5. Поменять передачу \n6. Выход");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    car.StartEngine();
                    break;
                case "2":
                    car.StopEngine();
                    break;
                case "3":
                    car.Accelerate();
                    break;
                case "4":
                    car.Brake();
                    break;
                case "5":
                    Console.WriteLine("Введите желаемую передачу (-1 для заднего хода, 0 для нейтральной, 1-5 для передних передач):");
                    int gear = int.Parse(Console.ReadLine());
                    car.ChangeGear(gear);
                    break;
                case "6":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, выберите число от 1 до 6.");
                    break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Run();
    }
}