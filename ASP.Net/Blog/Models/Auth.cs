using System;
using System.Collections.Generic;

namespace Blog.Models;

public partial class Auth
{
    public string Account { get; set; } = null!;

    public string Pwd { get; set; } = null!;
}
