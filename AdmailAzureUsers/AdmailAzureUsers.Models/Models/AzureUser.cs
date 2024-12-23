using System;
using System.Collections.Generic;

namespace AdmailAzureUsers.Models.Models;

public partial class AzureUser
{
    public int Id { get; set; }

    public string TenantId { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public string ClientSecret { get; set; } = null!;
}
