using Fast.Core.Interfaces;
namespace Fast.Core.DTOs
{
    public class CatalogDto : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
