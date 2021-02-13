using ThreeDlex.Core.Interfaces;

namespace ThreeDlex.Core.Entities
{
    public class Catalog : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
