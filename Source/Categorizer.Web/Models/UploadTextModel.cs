namespace Categorizer.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class UploadTextModel
    {
        [Display(Name = "FieldText", ResourceType = typeof(LocalizationStrings))]
        public string Text { get; set; }


        [Display(Name = "FieldFileInput1", ResourceType = typeof(LocalizationStrings))]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase FileInput1 { get; set; }

        [Display(Name = "FieldFileInput2", ResourceType = typeof(LocalizationStrings))]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase FileInput2 { get; set; }
    }
}