using System.ComponentModel.DataAnnotations;

namespace KursProj.Dtos
{
    public class ShowCourceDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string ImageUrl { get; set; }
    }
}
