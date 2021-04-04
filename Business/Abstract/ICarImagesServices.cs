using Core.Utilities;
using Entity.ConCreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface ICarImagesServices
    {
        IDataResult<List<CarImages>> GetCarImages(int carId);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> Get(int imageId);
        IResult Add(IFormFile file, CarImages image);
        IResult Update(IFormFile file, CarImages image);
        IResult Delete(CarImages image);
    }
}
