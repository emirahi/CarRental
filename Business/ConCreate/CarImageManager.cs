using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entity.ConCreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.ConCreate
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetCarImageById(int carId)
        {
            IResult result = BusinessRules.Run(NullCarImage(carId));
            if (result != null)
            {
                List<CarImage> data = new List<CarImage>();
                return new ErrorDataResult<List<CarImage>>(result.Message, data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetALL(i => i.CarId == carId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetALL());
        }

        public IDataResult<CarImage> Get(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId));
        }
       
        
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage image)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(image.CarId));
            if (result != null)
            {
                return result;
            }
            image.ImagePath = FileHelper.Add(file);
            image.ImageDate = System.DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult();
        }

        public IResult update(IFormFile file, CarImage car)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(car.CarId));
            if (result != null)
            {
                return result;
            }
            var formerPath = _carImageDal.Get(carImage => carImage.Id == car.Id).ImagePath;
            car.ImagePath = FileHelper.Update(formerPath, file);
            car.ImageDate = System.DateTime.Now;
            _carImageDal.Update(car);
            return new SuccessResult();
        }

        public IResult Delete(CarImage image)
        {
            File.Delete(image.ImagePath);
            _carImageDal.Delete(image);
            return new SuccessResult();
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var selectedCarImages = _carImageDal.GetALL(c => c.CarId == carId);
            if (selectedCarImages.Count >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> NullCarImage(int id)
        {
            try
            {
                string path = @"\wwwroot\images\default.jpg";
                var result = _carImageDal.GetALL(i => i.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> images = new List<CarImage>();
                    images.Add(new CarImage() { CarId = id, ImageDate = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<CarImage>>(images);
                }

            }
            catch (Exception e)
            {
                List<CarImage> data = new List<CarImage>();
                return new ErrorDataResult<List<CarImage>>(e.Message, data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetALL(i => i.CarId == id));
        }

    }
}
