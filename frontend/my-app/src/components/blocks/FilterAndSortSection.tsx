"use client"
import { useEffect, useState } from "react";
import { CategoryFilterCard } from "../filtersAndSort/CategoryFilterCard";
import { PriceFilterCard } from "../filtersAndSort/PriceFilterCard";
import { ProviderFilterCard } from "../filtersAndSort/ProviderFilterCard";
import { Category, Provider } from "@/app/types";
import { fetchCategories } from "@/services/categories";
type Props = {
    onFiltersChange: (filters: {
    category?: string;
    provider?: string;
    priceRange?: [number, number];
    sortDirection?: number;
  }) => void;
}
export function FilterAndSortSection({onFiltersChange}: Props){
    const [categories, setCategories] = useState<Category[]>([]);
    const [providers, setProviders] = useState<Provider[]>([]);
    useEffect(() => {
        const loadCategories = async () => {
            const data = await fetchCategories();
            setCategories(data);
        }
        const fetchProviders = async () => {
            await fetch("http://localhost:5270/Providers")
            .then((res) => res.json())
            .then((data) => setProviders(data));            
        }
        loadCategories();
        fetchProviders();
    }, [])
    return(
        <section className="bg-white/90 m-4 rounded-xl p-6 space-y-6">
            <div className="grid grid-cols-2">
                <h1 className="text-[#667EEA] font-bold text-lg justify-self-start">Фильтры и сортировка</h1>
                <button type="button" className="border-2 border-[#667EEA] rounded-3xl px-4 py-2 text-[#667EEA] font-bold justify-self-end">
                    Скрыть фильтры
                </button>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                <CategoryFilterCard onFilterChange={onFiltersChange} categoryTitles={categories.map((category) => category.title)} />
                <ProviderFilterCard onFilterChange={onFiltersChange} providerNames={providers.map((provider) => provider.name)}/>
                <PriceFilterCard onFilterChange={onFiltersChange}/>
            </div>

            <div className="flex flex-wrap gap-3">
                <button onClick={() => onFiltersChange({category: undefined, provider: undefined, priceRange: undefined, sortDirection: undefined})} className="px-4 py-2 rounded-full border border-gray-300 bg-white text-gray-800 hover:bg-gray-100 ">По умолчанию</button>
                <button onClick={() => onFiltersChange({sortDirection: 1})} className="px-4 py-2 rounded-full border border-gray-300 bg-white text-gray-800 hover:bg-gray-100 ">Цена: по возрастанию</button>
                <button onClick={() => onFiltersChange({sortDirection: 0})} className="px-4 py-2 rounded-full border border-gray-300 bg-white text-gray-800 hover:bg-gray-100 ">Цена: по убыванию</button>
                <button className="px-4 py-2 rounded-full bg-red-500 text-white font-bold hover:bg-red-600">Очистить фильтры</button>
            </div>
        </section>

    )
}