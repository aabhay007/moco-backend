using System;
using System.Collections.Generic;

namespace moco_backend.Domain.Entities;

public partial class Message
{
    public Guid Id { get; set; }

    public Guid ChatId { get; set; }

    public Guid SenderId { get; set; }

    public string? Content { get; set; }

    public string? AttachmentUrl { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? EditedAt { get; set; }

    public bool? Deleted { get; set; }

    public virtual Chat Chat { get; set; } = null!;

    public virtual ICollection<MessageStatus> MessageStatuses { get; set; } = new List<MessageStatus>();

    public virtual User Sender { get; set; } = null!;
}
