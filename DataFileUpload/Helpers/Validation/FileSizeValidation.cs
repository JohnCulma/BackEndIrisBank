using System.ComponentModel.DataAnnotations;

namespace DataFileUpload .Helper.Validation
{
    public class FileSizeValidation : ValidationAttribute
    {
        private readonly int pesoMaximoImgMegabytes;

        public FileSizeValidation(int PesoMaximoImgMegabytes)
        {
            pesoMaximoImgMegabytes = PesoMaximoImgMegabytes;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > pesoMaximoImgMegabytes * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe ser mayor a{pesoMaximoImgMegabytes}mb");
            }
            return ValidationResult.Success;
        }

    }
}
