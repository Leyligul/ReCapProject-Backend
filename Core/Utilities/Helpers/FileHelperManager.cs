using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager : IFileHelperService
    {
        public IResult Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Update(IFormFile formFile, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return Upload(formFile, root);
            }
            return new ErrorResult();
        }

        public IDataResult<string> Upload(IFormFile formFile, string root)
        {
            if (formFile.Length == 0)
            {
                return new ErrorDataResult<string>();
            }
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string fileName = Guid.NewGuid().ToString();

            string fileExtension = Path.GetExtension(formFile.FileName);

            string filePath = Path.Combine(root, fileName + fileExtension);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            return new SuccessDataResult<string>(filePath, "Dosya oluşturuldu.");
        }
    }
}
