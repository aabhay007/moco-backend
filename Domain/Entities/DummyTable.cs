using System;
using System.Collections.Generic;

namespace moco_backend.Domain.Entities;

public partial class DummyTable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Data { get; set; }
}
