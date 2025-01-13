namespace DopLaba1 {
    public class BoxStorage : AbstractStore
    {
        protected List<BoxOfVegetables> listOfBox = new List<BoxOfVegetables>();
        int maxPricewitdth = 0;
        int maxMasswitdth = 0;
        public void SetList(List<BoxOfVegetables> list) 
        {
            listOfBox = list;
        }
        public int[] GetArrayMaxWidthOfData()
        {
            return new int[]{maxMasswitdth,maxPricewitdth};
        }
        public List<BoxOfVegetables> GetList()
        {
            return listOfBox;
        }
        public void UpdateDataWitdth()
        {

            maxPricewitdth = listOfBox.Max(s => s.GetPriceForKg().ToString().Length);
            if (maxPricewitdth < 10)
            {
                maxPricewitdth = 10;
            }

            maxMasswitdth = listOfBox.Max(s => s.GetMass().ToString().Length);
            if (maxMasswitdth < 5)
            {
                maxMasswitdth = 5;
            }

        }
        public BoxOfVegetables GetBox(int i) {
            return listOfBox[i];
        }
        public void AddBox(BoxOfVegetables boxOfVegetables)
        {
            listOfBox.Add(boxOfVegetables);
        }
    }
}