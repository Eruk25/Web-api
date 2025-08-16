import { Category } from "@/app/types";
import Image from "next/image";

type CategoryCardProps = {
    category: Category;
}
export function CategoryCard({category}: CategoryCardProps){
    return(
        <div className="flex flex-col items-center justify-center bg-gradient-to-r from-[#F093FB] to-[#F5576C] rounded-xl text-white font-bold min-h-30 max-h-72 w-50 overflow-hidden">
            <Image src={category.imagePath}
            alt="..."/>
            <span>{category.title}</span>
        </div>
    )
}