using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {

        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Creat(CreateProductPicture command)
        {
            var Operation = new OperationResult();

            if (_productPictureRepository.Exists(x => x.ProductId == command.ProductId))
                return Operation.Failed(DefultMessage.DuplicatedMessage);

            var productPicture = new ProductPicture(command.ProductId, command.Picture, command.PictureAlt,
                command.PictureTitle);

            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();

            return Operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var OperationResult = new OperationResult();

            var productPicture = _productPictureRepository.Get(command.Id);

            if(productPicture == null)
                return OperationResult.Failed(DefultMessage.NotFoundMessage);

            if (_productPictureRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return OperationResult.Failed(DefultMessage.DuplicatedMessage);

            productPicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);

            _productPictureRepository.SaveChanges();
            return OperationResult.Succedded();


        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var OperationResult = new OperationResult();
             
            var productPicture= _productPictureRepository.Get(id);

            if(productPicture==null)
                return OperationResult.Failed(DefultMessage.NotFoundMessage);

            productPicture.Remove();
            _productPictureRepository.SaveChanges();
            return OperationResult.Succedded();

        }

        public OperationResult Restore(long id)
        {
            var OperationResult = new OperationResult();

            var productPicture = _productPictureRepository.Get(id);

            if (productPicture == null)
                return OperationResult.Failed(DefultMessage.NotFoundMessage);

            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return OperationResult.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
