using InvoiceSystem.DOMAIN.Utilities.CommonCRUD;

namespace InvoiceSystem.DOMAIN.Interfaces.CommonCRUD
{
    public interface IPage<T> : ISlice<T> where T : class
    {
        /// <summary>
        /// Creates a new empty <see cref="IPage{T}"/>.
        /// </summary>
        /// <returns>A new <see cref="IPage{T}"/></returns>
        public static IPage<T> Empty()
        {
            return Empty(IPageable.Unpaged());
        }

        /// <summary>
        /// Creates a new empty <see cref="IPage{T}"/> for the given <see cref="IPageable"/>.
        /// </summary>
        /// <param name="pageable">Must not be <c>null</c>.</param>
        /// <returns>A new <see cref="IPage{T}"/></returns>
        public static IPage<T> Empty(IPageable pageable)
        {
            return new Page<T>(new List<T>(), pageable, 0);
        }

        /// <summary>
        /// Returns the total amount of elements.
        /// </summary>
        /// <returns>Amount of elements.</returns>
        public long GetTotalElements();

        /// <summary>
        /// Returns the number of total pages.
        /// </summary>
        /// <returns>Number of total pages.</returns>
        public int GetTotalPages();
    }
}
