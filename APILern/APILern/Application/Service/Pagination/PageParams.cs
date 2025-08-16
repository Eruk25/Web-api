using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILern.Application.Service.Pagination
{
    public class PageParams
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}