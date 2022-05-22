﻿using _0_Framework.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {


        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();

            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(DefultMessage.DuplicatedMessage);

            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
                slug, command.Keywords, command.MetaDescription
                );
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succedded();
        

        }

        public OperationResult Edit(EditProduct command)
        {
            var operation=new OperationResult();
            var product = _productRepository.Get(command.Id);

            if (product == null)
                return operation.Failed(DefultMessage.NotFoundMessage);

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(DefultMessage.DuplicatedMessage);


            var Slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription,
                command.Description, command.Picture, command.PictureAlt, command.PictureTitle,
                Slug, command.Keywords, command.MetaDescription);

            return operation.Succedded();

        }

        public EditProduct GetDetails(long id)
        {
          return  _productRepository.GetDetails(id);
        }

        public OperationResult InStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return operation.Failed(DefultMessage.NotFoundMessage);

            product.InStock();
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult NotInStock(long id)
        {
             var operation = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return operation.Failed(DefultMessage.NotFoundMessage);

            product.InStock();
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            return _productRepository.Search(command); 

        }
    }
}