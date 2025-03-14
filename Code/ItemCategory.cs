namespace WebAPI_295.Models
{
    public class ItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual List<Item> Products { get; set; }
    }
}
