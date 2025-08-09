import { Product } from "@/app/types";
import { ProductCard } from "../products/ProductCard";

export function ProductSection({products}: {products: Product[]}){
    return(
        <section>
            <h2>Популярные товары</h2>
            {products.map((product) =>(
                <ProductCard key={product.id} product={product}/>
            ))}
        </section>
    )
}