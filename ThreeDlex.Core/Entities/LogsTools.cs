using ThreeDlex.Core.Interfaces;
using System;

namespace ThreeDlex.Core.Entities
{
    public class LogsTools : IEntity
    {
        public int Id { get; set; }
        public int IdTool { get; set; }
        public int IdAdminister { get; set; }
        public DateTime StartUse { get; set; }
        public DateTime EndUse { get; set; }

        public virtual User IdAdministerNavigation { get; set; }
        public virtual Tool IdToolNavigation { get; set; }
    }
}
