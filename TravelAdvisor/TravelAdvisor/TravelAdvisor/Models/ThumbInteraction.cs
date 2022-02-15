using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAdvisor.Models
{
    public abstract class ThumbInteractionBase
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ReviewId { get; set; }

        public bool HasLiked { get; set; }
    }

    public class ThumbInteractionDto : ThumbInteractionBase
    {

    }

    public class ThumbInteractionUpdateDto : ThumbInteractionBase
    {

    }

    public class ThumbInteractionDeleteDto
    {
        public Guid Id { get; set; }
    }

    public class ThumbInteractionCreateDto
    {
        public Guid UserId { get; set; }

        public Guid ReviewId { get; set; }

        public bool HasLiked { get; set; }

    }
}
