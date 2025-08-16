import { Product } from "@/app/types"
import Image from "next/image"
import { ProductButton } from "../buttons/ProductButton";
type ProductCardProps = {
    product: Product;
}
export function ProductCard({product}: ProductCardProps){
    return(
        <div className="flex flex-col shadow-lg">
            <div className="bg-gradient-to-r from-[#F5F7FA] to-[#C3CFE2] rounded-t-lg">
                <Image
            src={product.imegePath}
            alt="..."
            className="self-center"/>
            </div>
            <div className="flex flex-col rounded-b-lg bg-white">
                <h3 className="font-bold">{product.title}</h3>
                <span className="text-gray-400">{product.description}</span>
                <span className="font-bold text-[#667EEA]">{product.price}₽</span>
                <ProductButton/>
            </div>
        </div>
    )
}