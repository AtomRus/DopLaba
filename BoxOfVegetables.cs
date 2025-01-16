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