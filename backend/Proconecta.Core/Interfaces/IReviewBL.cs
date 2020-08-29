namespace Proconecta.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Proconecta.Data.Models;

    public interface IReviewBL
    {
        Task<IList<Review>> Get();
        Task<Review> GetById(string id);
        Task<Review> Insert(Review toInsert);
        Task<Review> Update(string id, object toUpdate);
        Task<bool> Delete(string id);
    }
}
