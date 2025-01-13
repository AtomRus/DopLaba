namespace DopLaba1 
{
    public class BoxOfVegetables 
    {
        private double mass;
        private double priceForKg;
        //гетеры сетеры с проверкой данных
        public double GetMass() 
        {
            return mass;
        }
        public void SetMass(double mass) 
        {
            
            this.mass = mass;
        }
        public void ChangeMass(double mass, MyContainer myContainer) 
        {
            if (Store.TOTAL_MASS_CONTAINERS - this.mass + mass > Store.STORE_MAXIMUM_WEIGHT) 
            {
                Console.WriteLine("Отказано в замене! Склад не может выдержать такой ящик!");
            }
            else if (Store.RENTAL_PRICE > Store.CalcMoney(myContainer) - mass * priceForKg + mass * priceForKg)
            {
                throw new Exception("Невозможно изменить цену! Нерентабельное хранение");
            }
            else
            {
                this.mass = mass;
            }
        }
        public void ChangePrice(double price, MyContainer myContainer)
        {
            if (Store.RENTAL_PRICE > Store.CalcMoney(myContainer) - mass * priceForKg + mass * price)
            {
                throw new Exception("Невозможно изменить цену! Нерентабельное хранение");
            }
            else 
            {
                priceForKg = price;
            }
        }
        public void SetPrice(double priceForKg) 
        {
            this.priceForKg = priceForKg;
        }
        public double GetPriceForKg() 
        {
            return priceForKg;
        }
        public BoxOfVegetables(double mass, double priceForKg) 
        {
            this.mass = mass;
            this.priceForKg = priceForKg;

        }
        public BoxOfVegetables() 
        {
            mass = 0;
            priceForKg = 0;
        }
        
    }
}