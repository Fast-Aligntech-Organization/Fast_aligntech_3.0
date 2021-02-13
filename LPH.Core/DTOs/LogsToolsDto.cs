using LPH.Core.Interfaces;
using System;
namespace LPH.Core.DTOs
{
    public class LogsToolsDto : IEntity
    {
        public int Id { get; set; }
        public int IdTool { get; set; }
        public int IdAdminister { get; set; }
        public DateTime StartUse { get; set; }
        public DateTime EndUse { get; set; }


    }
}
