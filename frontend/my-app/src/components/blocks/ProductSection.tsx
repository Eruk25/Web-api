"use client";
import { Category, Product } from "@/app/types";
import { ProductCard } from "../products/ProductCard";
import { useEffect, useState } from "react";
import { ProductList } from "../products/ProductList";
import { FilterAndSortSection } from "./FilterAndSortSection";
import { CategorySection } from "./CategorySection";
import { fetchCategories } from "@/services/categories";

export function ProductSection(){
    const [categories, setCategories] = useState<Category[]>([]);
    const [filters, setFilters] = useState<{
        category?: string;
        provider?: string;
        priceRange?: [number, number];
        sort?: string;
    }>({});
    useEffect(() => {
        const loadCategories = async () => {
            const data = await fetchCategories();
            const categoriesSet = [...new Set(data.map((category) => category))]; 
            setCategories(categoriesSet);
        }
        loadCategories();
    }, []) 
    return(
        <section className="bg-white m-4 rounded-xl">
            <div>
                <FilterAndSortSection onFiltersChange={(newFilters) => 
                    setFilters((prev) => ({...prev, ...newFilters}))
                }/>
            </div>
            <div>
                <CategorySection onFiltersChange={(newFilters) => 
                    setFilters((prev) => ({...prev, ...newFilters}))
                } categories={categories}/>
            </div>
            <div>
                <ProductList filters={filters}/>
            </div>
        </section>
    );
};