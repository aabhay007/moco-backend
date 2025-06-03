using System;
using System.Collections.Generic;

namespace moco_backend.Domain.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string? DisplayName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ChatMember> ChatMembers { get; set; } = new List<ChatMember>();

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual ICollection<MessageStatus> MessageStatuses { get; set; } = new List<MessageStatus>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<TypingEvent> TypingEvents { get; set; } = new List<TypingEvent>();
}
