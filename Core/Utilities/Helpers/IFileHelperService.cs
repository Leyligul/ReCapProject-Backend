using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public interface IFileHelperService
    {
        IResult Delete(string filePath);
        IResult Update(IFormFile formFile,string filePath, string root);
        IDataResult<string> Upload(IFormFile formFile, string root);
    }
}
