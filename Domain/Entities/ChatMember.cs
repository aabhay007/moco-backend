using System;
using System.Collections.Generic;

namespace moco_backend.Domain.Entities;

public partial class ChatMember
{
    public Guid ChatId { get; set; }

    public Guid UserId { get; set; }

    public DateTime? JoinedAt { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
