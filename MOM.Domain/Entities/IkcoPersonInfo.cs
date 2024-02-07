using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MOM.Domain.Entities;

[Keyless]
[Table("IKCOPERSON_INFO", Schema = "HS_USER")]
public partial class IkcopersonInfo
{
    [Column("LASTNAME")]
    [StringLength(500)]
    public string? Lastname { get; set; }

    [Column("JOBPOSITION")]
    [StringLength(500)]
    public string? Jobposition { get; set; }

    [Column("PERSONALCODE")]
    [StringLength(500)]
    public string? Personalcode { get; set; }

    [Column("COMPANYNAME")]
    [StringLength(500)]
    public string? Companyname { get; set; }

    [Column("EMAIL")]
    [StringLength(500)]
    public string? Email { get; set; }

    [Column("FIRSTNAME")]
    [StringLength(500)]
    public string? Firstname { get; set; }
}
