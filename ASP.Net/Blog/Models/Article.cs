using System;
using System.Collections.Generic;

namespace Blog.Models;

public partial class Article
{
    public long Id { get; set; }

    public string Account { get; set; } = null!;

    public string Content { get; set; } = null!;

    public long Ctime { get; set; }
}
