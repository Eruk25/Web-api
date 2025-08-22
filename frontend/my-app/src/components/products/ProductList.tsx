"use client"
import { useEffect, useState } from "react";
import { Pagination } from "../pagination/Pagination";
import { ProductCard } from "./ProductCard";
import { Product } from "@/app/types";

type Props = {
    filters: {
        search? : string,
        category? : string,
        provider? : string,
        priceRange? : [number, number];
        sortDirection?: string;
    }
}
export function ProductList({filters}: Props){
    const [currentPage, setCurrentPage] = useState(1);
    const [products, setProducts] = useState<Product[]>([]);
    const [totalPages, setTotalPages] = useState(1);
    const [isLoading, setIsLoading] = useState(false);
    const pageSize = 6;
    useEffect(() => {


        const fetchProducts = async () => {
            setIsLoading(true);
            const queryParams = new URLSearchParams();
            
            if (filters.search) queryParams.append("search", filters.search);
            if (filters.category) queryParams.append("category", filters.category);
            if (filters.provider) queryParams.append("provider", filters.provider);
            if (filters.priceRange) {
                queryParams.append("minPrice", filters.priceRange[0].toString());
                queryParams.append("maxPrice", filters.priceRange[1].toString());
            }
            if (filters.sortDirection) queryParams.append("sortDirection", filters.sortDirection);

            queryParams.append("page", currentPage.toString());
            queryParams.append("pageSize", pageSize.toString());


            const res = await fetch(`http://localhost:5270/Products?${queryParams.toString()}`);
            if (!res.ok) {
                console.error("Ошибка ответа сервера:", res.status, await res.text());
                return;
            }
            const data = await res.json();

            setProducts(data.items);
            setIsLoading(false);
            setTotalPages(Math.ceil((data.totalCount / pageSize)))
        }
        fetchProducts();
    }, [filters.search, filters.category, filters.provider, filters.priceRange, filters.sortDirection, currentPage]);

    if(isLoading) return <p className="text-center">Загрузка...</p>;
    return(
        <div>
            <h2 className="text-center mb-4 bg-gradient-to-r from-[#667EEA] to-[#764BA2] bg-clip-text text-transparent font-bold m-4">Товары</h2>
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4 justify-items-center">
                {products.map((product) =>(
                <ProductCard key={product.id} product={product}/>
            ))}
            </div>
            <Pagination
            currentPage={currentPage}
            totalPages={totalPages}
            onPageChange={setCurrentPage}/>
        </div>
        
    )
}