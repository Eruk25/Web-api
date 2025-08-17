using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq.Expressions;
using APILern.Application.Service.Filters;
using APILern.Application.Service.Pagination;
using APILern.Application.Service.Sort;
using APILern.Domain.Entities;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APILern.Infrastructure
{
    public static class ProductExtensions
    {
        public static IQueryable<Product> Filter(this IQueryable<Product> query, ProductSearchCriteria productSearchCriteria)
        {
            var predicate = BuildFilter(productSearchCriteria);
            return query.Where(predicate);
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> query, ProductSortCriteria sortParams)
        {
            if (sortParams.SortDirection == SortDirectionEnum.Descending)
                return query.OrderByDescending(GetKeySelector(sortParams.OrderBy));

            return query.OrderBy(GetKeySelector(sortParams.OrderBy));
        }

        public static async Task<PagedResult<Product>?> ToPagedAsync(this IQueryable<Product> query, PageParams pageParams)
        {
            var totalCount = await query.CountAsync();
            if (totalCount == 0)
                return new PagedResult<Product>(new List<Product>(), 0); ;
            var page = pageParams.Page ?? 1;
            var pageSize = pageParams.PageSize ?? 10;

            var skip = (page - 1) * pageSize;
            var items = await query.Skip(skip).Take(pageSize).ToListAsync();

            return new PagedResult<Product>(items, totalCount);
        }

        private static Expression<Func<Product, object>> GetKeySelector(string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy))
                return p => p.Title;

            return orderBy switch
            {
                nameof(Product.Price) => p => p.Price,
                nameof(Product.Quantity) => p => p.Quantity,
                _ => p => p.Title
            };
        }

        private static Expression<Func<Product, bool>> BuildFilter(ProductSearchCriteria productSearch)
        {
            var predicate = PredicateBuilder.New<Product>(true);
            if (!string.IsNullOrWhiteSpace(productSearch.Title))
                predicate = predicate.And(p => p.Title.Contains(productSearch.Title));

            if (productSearch.Provider is not null)
                predicate = predicate.And(p => p.Provider.Name == productSearch.Provider.ProviderName);

            if (productSearch.Price is not null)
            {
                if (productSearch.Price?.MinPrice is not null)
                {
                    predicate = predicate.And(p => p.Price >= productSearch.Price.MinPrice);
                }
                if (productSearch.Price?.MaxPrice is not null)
                {
                    predicate = predicate.And(p => p.Price <= productSearch.Price.MaxPrice);
                }
            }


            return predicate;
        }
    }
}