using System.Collections;

namespace DopLaba1
{
    public interface Adapter 
    {
        public string[] GetArrayHeaders();
        public int[] GetArrayMaxWidthOfData();
        public List<ArrayList> GetListOfArrayData();
        public int GetCountElement();
        public void UpdateMaxWidth();
    }
}