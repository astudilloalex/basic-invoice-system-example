namespace InvoiceSystem.DOMAIN.Interfaces.CommonCRUD
{
    public interface IPagingAndSortingRepository<T, ID> : ICrudRepository<T, ID> where T : class
    {
        /// <summary>
        /// Returns a <see cref="IPage{T}"/> of entities meeting the paging restriction provided in the <see cref="IPageable"/> object.
        /// </summary>
        /// <param name="pageable"></param>
        /// <returns>A page with entities.</returns>
        public IPage<T> FindAll(IPageable pageable);

        /// <summary>
        /// Returns async a <see cref="IPage{T}"/> of entities meeting the paging restriction provided in the <see cref="IPageable"/> object.
        /// </summary>
        /// <param name="pageable">The pageable to request a paged result, can be <see cref="IPageable.Unpaged()"/>, must not be <c>null</c>.</param>
        /// <returns>A page with entities.</returns>
        public Task<IPage<T>> FindAllAsync(IPageable pageable);
    }
}
