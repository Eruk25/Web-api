using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILern.Application.Service.Sort
{
    public class ProductSortCriteria
    {
        public string? OrderBy { get; set; }
        public SortDirectionEnum? SortDirection { get; set; }
    }
}