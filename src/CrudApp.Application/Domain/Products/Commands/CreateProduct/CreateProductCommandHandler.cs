using CrudApp.Core.Common;
using CrudApp.Core.Domain.Products.Common;
using CrudApp.Core.Domain.Products.Models;
using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product= await Product.CreateAsync(request.Name, request.Price, request.Quantity);
        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}