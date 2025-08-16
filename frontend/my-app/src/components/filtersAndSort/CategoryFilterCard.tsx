type CategoryFilterProps = {
    categoryTitles: string[];
}
export function CategoryFilterCard({categoryTitles}: CategoryFilterProps){
    return(
        <div className="bg-[#F8F9FA] rounded-xk">
            <h2 className="m-2">Категория</h2>
            <div className="m-2">
                <select name="" id="" className="border-1 border-[#E0E0E0] bg-[#EFEFEF] rounded-sm">
                    {categoryTitles.map((title, index) => (
                        <option value="" key={index}>{title}</option>
                    ))}
                </select>
            </div>
        </div>
    )
}