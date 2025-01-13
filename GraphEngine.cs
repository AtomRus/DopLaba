namespace DopLaba1
{
    public class GraphEngine
    {
        ArtistArgorithm artistArgorithm = new ArtistArgorithm();
        public int ShowMenuAndSelectItem(List<String> headers_list, int index_cursor)
        {
            return artistArgorithm.MenuRendering(headers_list, index_cursor);
        }
        public int SelectElementFromTheStore(AbstractStore abstractStore)
        {
            artistArgorithm.SetDataFromAdapter(FabricAdapter.CreateAdapter(abstractStore));
            return artistArgorithm.SelectElementFromTheStore();
        }
    }
}