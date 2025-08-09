import { Product } from "@/app/types"
import Image from "next/image"
type ProductCardProps = {
    product: Product;
}
export function ProductCard({product}: ProductCardProps){
    return(
        <div>
            <Image
            src={product.imegePath}
            alt="..."/>
            <h3>{product.title}</h3>
            <span>{product.description}</span>
            <span>{product.price}</span>
            <button type="button">Добавить в корзину</button>
        </div>
    )
}