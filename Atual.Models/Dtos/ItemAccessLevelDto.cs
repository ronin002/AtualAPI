using AtualAPI.Models;
using System.Globalization;
using Atual.Models.Enum;

namespace AtualAPI.Dtos
{
    public class ItemAccessLevelDto
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public ELevelAccess LevelAccess { get; set; }

    }

}
