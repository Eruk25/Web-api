"use client";
import { Provider } from "@/app/types";
import { useEffect, useState } from "react";

export function ProviderFilterCard(){
    const [providers, setProviders] = useState<Provider[]>([]);

    useEffect(()=> {
        fetch(`http://localhost:5270/Providers`)
        .then((res) => res.json())
        .then((data) => setProviders(data));
    }, []);
    return(
        <div className="bg-[#F8F9FA] rounded-xk">
            <h2 className="m-2">Бренды</h2>
            <div className="m-2">
                <select className="border-1 border-[#E0E0E0] bg-[#EFEFEF]">
                    <option value="">Все бренды</option>
                    {providers.map((provider) => (
                        <option value={provider.name} key={provider.id}>{provider.name}</option>
                    ))}
                </select>
            </div>
        </div>
    );
}