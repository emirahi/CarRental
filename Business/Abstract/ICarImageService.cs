using Core.Utilities;
using Entity.ConCreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage car);
        IResult update(IFormFile file, CarImage car);
        IResult Delete(CarImage car);
        IDataResult<CarImage> Get(int imageId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetCarImageById(int Id);
    }
}
