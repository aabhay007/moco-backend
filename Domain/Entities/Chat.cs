using System;
using System.Collections.Generic;

namespace moco_backend.Domain.Entities;

public partial class Chat
{
    public Guid Id { get; set; }

    public bool? IsGroup { get; set; }

    public string? Title { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<TypingEvent> TypingEvents { get; set; } = new List<TypingEvent>();
}
