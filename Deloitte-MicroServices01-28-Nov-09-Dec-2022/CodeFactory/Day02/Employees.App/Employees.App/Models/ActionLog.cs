using System;
using System.Collections.Generic;

namespace Employees.App.Models;

public partial class ActionLog
{
    public int Id { get; set; }

    public DateTime TimeStamp { get; set; }

    public string Controller { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string SourceIp { get; set; } = null!;
}
