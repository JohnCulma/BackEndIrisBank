
using DataFileUpload.Helper.Validation;

namespace DataFileUpload.DTOs
{
    public class Files
    {
        [FileSizeValidation(PesoMaximoImgMegabytes: 100)]
        [FileValid(grupoTipoArchivo: fileTypeGroup.txt)]
        public List<IFormFile>? data { get; set; }
    }
}
