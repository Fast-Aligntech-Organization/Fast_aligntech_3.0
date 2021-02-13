using ThreeDlex.Core.Interfaces;

namespace ThreeDlex.Core.Entities
{
    public partial class CatalogsProducts : IEntity
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdCatalog { get; set; }

        public virtual Catalog IdCatalogNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
