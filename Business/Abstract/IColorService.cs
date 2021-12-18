using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<List<Color>> GetColorById(int colorId);
        IResult AddColor(Color color);
        IResult UpDateColor(Color color);
        IResult DeleteColor(Color color);

    }
}
