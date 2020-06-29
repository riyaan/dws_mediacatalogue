using System;

namespace MediaCatalogue_API.Factory
{
    public class Factory<TEntity> : IFactory<TEntity> where TEntity : class
    {

        public TEntity Create(params object[] args)
        {
            return (TEntity)Activator.CreateInstance(typeof(TEntity), args);
        }
    }
}