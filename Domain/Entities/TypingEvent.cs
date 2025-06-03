using System;
using System.Collections.Generic;

namespace moco_backend.Domain.Entities;

public partial class TypingEvent
{
    public Guid ChatId { get; set; }

    public Guid UserId { get; set; }

    public bool? Typing { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
