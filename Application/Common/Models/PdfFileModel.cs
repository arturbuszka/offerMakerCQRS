using System.IO;


namespace OfferMakerForCggCQRS.Application.Common.Models
{
    public class PdfFileModel
    {
        public MemoryStream Content { get; set; }
        public string ContentType { get; set; }
        public string FilePath { get; set; }

        public PdfFileModel(MemoryStream content, string contentType, string filePath)
        {
            Content = content;
            ContentType = contentType;
            FilePath = filePath;
        }
    }
}
