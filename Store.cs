

using System.Data;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Security.Principal;

namespace DopLaba1
{
    public class Store : ContainerStorage
    {
        /*Логика хранения состоит в том, что у класска Store есть коллекция List<Container>,
        а уже внутри класса Container есть своя коллекция List<BoxOfVegetables>
        */
        private int MAX_NUMBER_OF_CONTAINERS;
        private double RENTAL_PRICE;
        private double STORE_MAXIMUM_WEIGHT;
        private double TOTAL_MASS_CONTAINERS = 0;
    
        //Сетеры, гетеры
        
        public void SetMaxStoreMass(double maxStoreMass) 
        {
            STORE_MAXIMUM_WEIGHT = maxStoreMass;

        }
        public double GetMaxStoreMass() 
        {
            return STORE_MAXIMUM_WEIGHT;
        }
        public void SetMaxNumOfContainer(int maxNumOfContainer) 
        {
            this.MAX_NUMBER_OF_CONTAINERS = maxNumOfContainer;
            LIST_OF_CONTAINERS = new List<MyContainer>(MAX_NUMBER_OF_CONTAINERS);
        }
        public void SetRentalPrice(double rentalPrice) 
        {
            RENTAL_PRICE = rentalPrice;
        }
        public int GetMaxNumberOfContainers()
        {
            return MAX_NUMBER_OF_CONTAINERS;
        }
        public double GetRentalPrice()
        {
            return RENTAL_PRICE;
        }
        public double GetTotalMassContainers()
        {
            return TOTAL_MASS_CONTAINERS;
        }
        public void AddContainer(MyContainer myContainer)
        {
            LIST_OF_CONTAINERS.Add(myContainer);
        }
        public void RemoveContainer(int idContainer)
        {
            LIST_OF_CONTAINERS.Remove(LIST_OF_CONTAINERS[idContainer]);
        }
    }

}