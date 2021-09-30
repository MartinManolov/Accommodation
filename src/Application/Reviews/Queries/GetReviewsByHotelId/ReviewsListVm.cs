using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accommodation.Application.Reviews.Queries.GetReviewsByHotelId
{
    public class ReviewsListVm
    {
        public IList<ReviewDto> Reviews { get; set; }
    }
}
