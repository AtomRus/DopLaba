using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace DopLaba1 
{
    
    public class BoxStorageAdapter : Adapter
    {

        private BoxStorage boxStorage;
        public void SetStorage(BoxStorage boxStorage)
        {
            this.boxStorage = boxStorage;
        }
        public int[] GetArrayMaxWidthOfData()
        {
            return boxStorage.GetArrayMaxWidthOfData();
        }
        public ArrayList GetArrayListOfArrayListData()
        {
            ArrayList exportArrayList = new ArrayList();
            List<BoxOfVegetables> listOfBox = boxStorage.GetList();
            ArrayList arrayListOfMass = new ArrayList(listOfBox.Count);
            ArrayList arrayListOfPriceForKg = new ArrayList(listOfBox.Count);
            foreach (BoxOfVegetables boxOfVegetables in listOfBox)
            {
                arrayListOfMass.Add(boxOfVegetables.GetMass());
                arrayListOfPriceForKg.Add(boxOfVegetables.GetPriceForKg());
            }
            exportArrayList.Add(arrayListOfPriceForKg);
            exportArrayList.Add(arrayListOfMass);
            return exportArrayList;
        }
        public int GetCountElement()
        {
            return boxStorage.GetList().Count;
        }

        public string[] GetArrayHeaders()
        {
            return new string[2]{"Масса", "Цена за кг"};
        }

        public List<ArrayList> GetListOfArrayData()
        {
            ArrayList listOfMass = new ArrayList(boxStorage.GetList().Count);
            ArrayList listOfPriceForKg = new ArrayList(boxStorage.GetList().Count);
            foreach (BoxOfVegetables boxOfVegetables in boxStorage.GetList())
            {
                listOfMass.Add(boxOfVegetables.GetMass());
                listOfPriceForKg.Add(boxOfVegetables.GetPriceForKg());
            }
            return new List<ArrayList>{listOfMass, listOfPriceForKg};
        }


        public void UpdateMaxWidth()
        {
            boxStorage.UpdateDataWitdth();
        }
        public BoxStorageAdapter(BoxStorage boxStorage)
        {
            this.boxStorage = boxStorage;
        }
    }
}