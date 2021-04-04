using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
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
    public class CarImagesManager : ICarImagesServices
    {
        private ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImageDal)
        {
            _carImagesDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IDataResult<List<CarImages>> GetCarImages(int carId)
        {
            IResult result = BusinessRules.Run(NullCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(false, result.Message);
            }
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetALL(i => i.CarId == carId));
        }

        public IDataResult<List<CarImages>> GetALL()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetALL());
        }

        public IDataResult<CarImages> Get(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(i => i.Id == imageId));
        }


        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetALL());
        }


        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Add(IFormFile file, CarImages image)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(image.CarId));
            if (result != null)
            {
                return result;
            }
            image.ImagePath = FileHelper.Add(file);
            image.Datee = System.DateTime.Now;
            _carImagesDal.Add(image);
            return new SuccessResult();
        }


        public IResult Update(IFormFile file, CarImages image)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(image.CarId));
            if (result != null)
            {
                return result;
            }
            var formerPath = _carImagesDal.Get(carImage => carImage.Id == image.Id).ImagePath;
            image.ImagePath = FileHelper.Update(formerPath, file);
            image.Datee = System.DateTime.Now;
            _carImagesDal.Update(image);
            return new SuccessResult();
        }


        public IResult Delete(CarImages image)
        {
            File.Delete(image.ImagePath);
            _carImagesDal.Delete(image);
            return new SuccessResult();
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var selectedCarImages = _carImagesDal.GetALL(c => c.CarId == carId);
            if (selectedCarImages.Count >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImages>> NullCarImage(int id)
        {
            try
            {
                string path = @"\wwwroot\images\default.jpg";
                var result = _carImagesDal.GetALL(i => i.CarId == id).Any();
                if (!result)
                {
                    List<CarImages> images = new List<CarImages>();
                    images.Add(new CarImages() { CarId = id, Datee = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<CarImages>>(images);
                }

            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CarImages>>(false, e.Message);
            }

            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetALL(i => i.CarId == id));
        }


    }
}
