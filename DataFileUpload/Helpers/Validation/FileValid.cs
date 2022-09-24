using DataFileUpload.Helper.Validation;
using System.ComponentModel.DataAnnotations;

namespace DataFileUpload.Helper.Validation
{
    public class FileValid : ValidationAttribute
    {
        private readonly string[] tiposValidos;

        public FileValid(string[] tiposValidos)
        {
            this.tiposValidos = tiposValidos;
        }

        public FileValid(fileTypeGroup grupoTipoArchivo)
        {
            if (grupoTipoArchivo == fileTypeGroup.txt)
            {
                tiposValidos = new string[] { "text/plain" };
            }
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

            if (!tiposValidos.Contains(formFile.ContentType))
            {
                return new ValidationResult($"El tipo de archivo debe ser uno de los siguientes: {string.Join(", ", tiposValidos) }mb");
            }
            return ValidationResult.Success;
        }
    }
}
