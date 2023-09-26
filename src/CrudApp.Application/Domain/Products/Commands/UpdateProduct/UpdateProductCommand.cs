﻿using MediatR;

namespace CrudApp.Application.Domain.Products.Commands.UpdateProduct;

public record UpdateProductCommand(long Id, string Name, decimal Price, int Quantity) : IRequest<Unit>;