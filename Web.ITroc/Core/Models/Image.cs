namespace Web.ITroc.Core.Models
{
    public class Image
    {
        public int Id { get; set; }

        public int AdId { get; set; }

        public string FileBase64 { get; set; }

        public bool Poubelle { get; set; }

        public Ads Ads { get; set; }
    }
}