import { Category } from "@/app/types";
import { CategoryCard } from "./CategoryCard";

export function CategorySection({categories}: {categories: Category[]}){
    return(
        <section>
            <h2>Категории товаров</h2>
            {categories.map((category) => (
                <CategoryCard key={category.id} category={category}/>
            ))}
        </section>
    )
}