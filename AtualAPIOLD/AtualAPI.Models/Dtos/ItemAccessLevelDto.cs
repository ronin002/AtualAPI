using AtualAPI.Models;
using System.Globalization;

namespace AtualAPI.Dtos
{
    public class ItemAccessLevelDto
    {
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public ELevelAccess LevelAccess { get; set; }

    }

}
