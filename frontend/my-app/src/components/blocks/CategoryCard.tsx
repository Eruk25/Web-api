import { Category } from "@/app/types";
import Image from "next/image";

type CategoryCardProps = {
    category: Category;
}
export function CategoryCard({category}: CategoryCardProps){
    return(
        <div>
            <Image src={category.imagePath}
            alt="..."/>
            <span>{category.title}</span>
        </div>
    )
}