namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car _car;

        string make = "Opel";
        string model = "Meriva";
        double fuelConsumption = 5.0d;
        double fuelCapacity = 50.0d;

        [Test]
        public void Test_Car_Constructor()
        {
            // Act
            this._car = new Car(make, model, fuelConsumption, fuelCapacity);

            // Assert
            Assert.That(this._car.Make, Is.EqualTo("Opel"));
            Assert.That(this._car.Model, Is.EqualTo("Meriva"));
            Assert.That(this._car.FuelConsumption, Is.EqualTo(5.0d));
            Assert.That(this._car.FuelCapacity, Is.EqualTo(50.0d));
            Assert.That(this._car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void Test_Car_Constructor_EmptyMakeProp_Return_ArgumentException()
        {
            // Arrange
            string make = string.Empty;

            // Act && Assert
            void GetArgumentException()
            {
                this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            }

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Test_Car_Constructor_NullMakeProp_Return_ArgumentException()
        {
            // Arrange
            string make = null;

            // Act && Assert
            void GetArgumentException()
            {
                this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            }

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void Test_Car_Constructor_EmptyModelProp_Return_ArgumentException()
        {
            // Arrange
            string model = string.Empty;

            // Act && Assert
            void GetArgumentException()
            {
                this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            }

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void Test_Car_Constructor_NullModelProp_Return_ArgumentException()
        {
            // Arrange
            string model = null;

            // Act && Assert
            void GetArgumentException()
            {
                this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            }

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void Test_Car_Constructor_ZeroFuelConsumption_Return_ArgumentException()
        {
            // Arrange
            double fuelConsumption = 0;

            // Act && Assert
            void GetArgumentException()
            {
                this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            }

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void Test_Car_Constructor_NegativeFuelConsumption_Return_ArgumentException()
        {
            // Arrange
            double fuelConsumption = -1;

            // Act && Assert
            void GetArgumentException()
            {
                this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            }

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        public void Test_Car_Constructor_NegativeFuelCapacity_Return_ArgumentException()
        {
            // Arrange
            double fuelCapacity = -1;

            // Act && Assert
            void GetArgumentException()
            {
                this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            }

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Test_Car_Constructor_ZeroFuelCapacity_Return_ArgumentException()
        {
            // Arrange
            double fuelCapacity = 0;

            // Act && Assert
            void GetArgumentException()
            {
                this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            }

            Assert.That(() => GetArgumentException(), Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Test_Car_Refuel_Method()
        {
            // Arrange
            this._car = new Car(make, model, fuelConsumption, fuelCapacity);

            double fuelToRefuel = 20.0d;

            // Act
            this._car.Refuel(fuelToRefuel);

            // Assert
            Assert.That(this._car.FuelAmount, Is.EqualTo(20.0d));
        }

        [Test]
        public void Test_Car_Refuel_Method_Fuel_Bigger_Then_Capacity_Return_FuelAmount_EqualtTo_FuelCapacity()
        {
            // Arrange
            this._car = new Car(make, model, fuelConsumption, fuelCapacity);

            double fuelToRefuel = 100.0d;

            // Act
            this._car.Refuel(fuelToRefuel);

            // Assert
            Assert.That(this._car.FuelAmount, Is.EqualTo(50.0d));
        }

        [Test]
        public void Test_Refuel_Method_ZeroFuelToRefuel_Return_ArgumentException()
        {
            // Arrange
            this._car = new Car(make, model, fuelConsumption, fuelCapacity);

            double fuelToRefuel = 0;

            // Act && Assert
            Assert.That(() => this._car.Refuel(fuelToRefuel), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void Test_Refuel_Method_NegativeFuelToRefuel_Return_ArgumentException()
        {
            // Arrange
            this._car = new Car(make, model, fuelConsumption, fuelCapacity);

            double fuelToRefuel = -1;

            // Act && Assert
            Assert.That(() => this._car.Refuel(fuelToRefuel), Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void Test_Car_Drive_Method()
        {
            // Arrange
            this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            this._car.Refuel(50);

            double distance = 100;

            // Act
            this._car.Drive(distance);

            // Assert
            Assert.That(this._car.FuelAmount, Is.EqualTo(45.0d));
        }

        [Test]
        public void Test_Car_Drive_Method_FuelNeeded_Bigger_Than_FuelAmount_Return_InvalidOperationException()
        {
            // Arrange
            this._car = new Car(make, model, fuelConsumption, fuelCapacity);
            this._car.Refuel(10);

            double distance = 1000;

            // Act && Assert
            Assert.That(() => this._car.Drive(distance), Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
            
        }
    }
} 