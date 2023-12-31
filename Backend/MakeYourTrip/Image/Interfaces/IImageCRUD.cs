﻿namespace Image.Interfaces
{
    public interface IImageCRUD <K, T>
    {
        public Task<T?> Add(T item);

        public Task<T?> Delete(K key);

        public Task<T?> Get(K key);

        public Task<ICollection<T>?> GetAll();

    }
}
