using System;
using System.Collections.Generic;
using ShaumStore.Domain.Entities;

namespace ShaumStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
