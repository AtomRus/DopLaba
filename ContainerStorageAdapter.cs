using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace DopLaba1 
{
    public class ContainerStorageAdapter : Adapter
    {
        private ContainerStorage containerStorage;
        public void UpdateMaxWidth()
        {
            containerStorage.UpdateDataWitdth();
        }
        public int[] GetArrayMaxWidthOfData()
        {
            return containerStorage.GetDataWidth();
        }
        public string[] GetArrayHeaders()
        {
            return new string[]{"Имя","Максимальное кол-во ящиков", "Приоритет", "Масса контейнера"};
        }
        public int GetCountElement()
        {
            return containerStorage.GetList().Count;
        }
        public List<ArrayList> GetListOfArrayData()
        {
            ArrayList listOfNames = new ArrayList(containerStorage.GetList().Count);
            ArrayList listOfCountBoxs = new ArrayList(containerStorage.GetList().Count);
            ArrayList listOfPriority = new ArrayList(containerStorage.GetList().Count);
            ArrayList listOfMassBoxs = new ArrayList(containerStorage.GetList().Count);
            foreach (MyContainer myContainer in containerStorage.GetList())
            {
                listOfNames.Add(myContainer.GetName());
                listOfCountBoxs.Add(myContainer.GetCountBoxs());
                listOfPriority.Add(myContainer.GetPriority());
                listOfMassBoxs.Add(myContainer.GetSumMassOfBox());
            }
            return new List<ArrayList>{listOfNames,listOfCountBoxs,listOfPriority,listOfMassBoxs};
        }
        public ContainerStorageAdapter(ContainerStorage containerStorage)
        {
            this.containerStorage = containerStorage;
        }
    }
}