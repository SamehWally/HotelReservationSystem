namespace Presentation.ViewModels.Room
{
    namespace Presentation.ViewModels.Room
    {
        public class EditRoomViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int Type { get; set; }
            public decimal PricePerNight { get; set; }
            public string? Description { get; set; }
            public List<int> FacilityIds { get; set; } = new();
            public List<IFormFile> PictureUrls { get; set; } = new();

            //public int Id { get; set; }
            //public string Name { get; set; } = string.Empty;
            //public int Type { get; set; }
            //public decimal PricePerNight { get; set; }
            //public string Description { get; set; } = string.Empty;

            //public List<int> FacilityIds { get; set; } = new();

            //// ✅ صور جديدة يرفعها اليوزر (File Upload)
            //public List<IFormFile>? NewPictures { get; set; }

            //// ✅ صور قديمة اليوزر يختار يحتفظ بيها
            //public List<string>? ExistingPictureUrlsToKeep { get; set; }
        }
    }
    }

