using MediaCatalogue_API.Models;
using System.Collections.Generic;

namespace MediaCatalogue_API.Factory
{
    public interface IFactory<TEntity> where TEntity: class
    {
        TEntity Create(params object[] args);
    }
}