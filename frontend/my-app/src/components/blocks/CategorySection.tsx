import { Category } from "@/app/types";
import { CategoryCard } from "../categories/CategoryCard";
type Props = {
    categories: Category[];
    onFiltersChange: (filters: {
        category?: string;
    }) => void;
}
export function CategorySection({categories, onFiltersChange}: Props){
    return(
        <section className="px-4 py-6 bg-white m-4 rounded-xl">
            <h1 className="text-center mb-4 bg-gradient-to-r from-[#667EEA] to-[#764BA2] bg-clip-text text-transparent font-bold">Категории товаров</h1>
            <div className="grid grid-cols-1 sm:grid-cols-2 sm:grid-cols-3 lg:grid-cols-4 gap-6 justify-items-center">
                {categories.map((category) => (
                <CategoryCard onFiltersChange={onFiltersChange} key={category.id} category={category}/>
            ))}
            </div>
        </section>
    )
}