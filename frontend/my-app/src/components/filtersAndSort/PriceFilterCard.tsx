"use client"
import { useState } from "react";

type Props = {
    onFilterChange: ( filters:{
        priceRange: [number, number]
    }) => void;
}
export function PriceFilterCard({onFilterChange}: Props){
    const [minPrice, setMinPrice] = useState<number>(0);
    const [maxPrice, setMaxPrice] = useState<number>(0);

    const handleMaxPriceChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const newMaxPrice = Number(e.target.value); 
        setMaxPrice(newMaxPrice);
        onFilterChange({ priceRange: [minPrice, newMaxPrice]});
    }
    return(
        <div className="bg-[#F8F9FA] rounded-xk">
            <h2>Цена (₽)</h2>
            <div className="grid grid-cols-2 gap-3 p-1">
                <input onChange={(e) => setMinPrice(Number(e.target.value))} type="number" className="border-2 border-[#757575]/30 rounded-md" placeholder="От"/>
                <input onChange={handleMaxPriceChange} type="number" className="border-2 border-[#757575]/30 rounded-md" placeholder="До"/>
            </div>
        </div>
    )
}