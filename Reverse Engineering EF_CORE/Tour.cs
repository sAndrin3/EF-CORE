using System;
using System.Collections.Generic;

namespace Reverse_Engineering_EF_CORE;

public partial class Tour
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Duration { get; set; }

    public int Price { get; set; }
}
