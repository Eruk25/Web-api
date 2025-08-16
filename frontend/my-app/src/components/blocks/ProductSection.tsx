"use client";
import { Product } from "@/app/types";
import { ProductCard } from "../products/ProductCard";
import { useEffect, useState } from "react";
import { Pagination } from "../pagination/Pagination";

export function ProductSection(){
    const [currentPage, setCurrentPage] = useState(1);
    const [products, setProducts] = useState<Product[]>([]);
    const [totalPages, setTotalPages] = useState(1);
    const pageSize = 6;

    useEffect(() => {
        fetch(`http://localhost:5270/Products?page=${currentPage}&pageSize=${pageSize}`)
            .then((res) => res.json())
            .then((data) => {
                setProducts(data.items)
                setTotalPages(Math.ceil(data.totalCount / pageSize))
            });
    }, [currentPage]);
    return(
        <section className="bg-white m-4 rounded-xl">
            <h2 className="text-center mb-4 bg-gradient-to-r from-[#667EEA] to-[#764BA2] bg-clip-text text-transparent font-bold m-4">Популярные товары</h2>
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4 justify-items-center">
                {products.map((product) =>(
                <ProductCard key={product.id} product={product}/>
            ))}
            </div>
            <Pagination
            currentPage={currentPage}
            totalPages={totalPages}
            onPageChange={setCurrentPage}/>
        </section>
    );
};