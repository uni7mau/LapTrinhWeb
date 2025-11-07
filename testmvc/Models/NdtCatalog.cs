using System;
using System.Collections.Generic;

namespace testmvc.Models;

public partial class NdtCatalog
{
    public int NdtId { get; set; }

    public string? NdtCateName { get; set; }

    public int? NdtCatePrice { get; set; }

    public int? NdtCateQty { get; set; }

    public string? NdtPicture { get; set; }

    public bool? NdtCateActive { get; set; }
}
