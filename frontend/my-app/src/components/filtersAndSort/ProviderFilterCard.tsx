"use client";
type ProviderFilterProps = {
    providerNames : string[];
    onFilterChange: (filters: {
        provider? : string;
    }) => void;
}
export function ProviderFilterCard({providerNames, onFilterChange}: ProviderFilterProps){
    return(
        <div className="bg-[#F8F9FA] rounded-xk">
            <h2 className="m-2">Бренды</h2>
            <div className="m-2">
                <select onChange={(e) => onFilterChange({provider: e.target.value})} className="border-1 border-[#E0E0E0] bg-[#EFEFEF]">
                    <option value="">Все бренды</option>
                    {providerNames.map((name, index) => (
                        <option value={name} key={index}>{name}</option>
                    ))}
                </select>
            </div>
        </div>
    );
}