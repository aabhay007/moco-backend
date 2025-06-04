using System;
using System.Collections.Generic;

namespace moco_backend.Domain.Entities;

public partial class ImageLibrary
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string ImageLink { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
