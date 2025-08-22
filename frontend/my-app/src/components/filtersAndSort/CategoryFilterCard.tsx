type CategoryFilterProps = {
    categoryTitles: string[];
    onFilterChange: (filters: {
        category? : string;
    }) => void;
}
export function CategoryFilterCard({categoryTitles, onFilterChange}: CategoryFilterProps){
    return(
        <div className="bg-[#F8F9FA] rounded-xk">
            <h2 className="m-2">Категория</h2>
            <div className="m-2">
                <select onChange={(e) => onFilterChange({category: e.target.value})} className="border-1 border-[#E0E0E0] bg-[#EFEFEF] rounded-sm">
                    <option value="">Все категирии</option>
                    {categoryTitles.map((title, index) => (
                        <option value={title} key={index}>{title}</option>
                    ))}
                </select>
            </div>
        </div>
    )
}