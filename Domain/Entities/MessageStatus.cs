using System;
using System.Collections.Generic;

namespace moco_backend.Domain.Entities;

public partial class MessageStatus
{
    public Guid MessageId { get; set; }

    public Guid UserId { get; set; }

    public string? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Message Message { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
