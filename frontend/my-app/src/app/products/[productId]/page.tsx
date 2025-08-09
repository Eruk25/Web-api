// app/products/[productId]/page.tsx

import { Product } from "@/app/types"; // тип должен быть отдельно определён

export default async function ProductPage({params}: {params: { productId: string };}) {
  const { productId } = params;

  const res = await fetch(`http://localhost:5270/api/Products/${productId}`, {
    cache: "no-store",
  });

  if (!res.ok) {
    return <div>Ошибка загрузки товара</div>;
  }

  const product: Product = await res.json();

  return (
    <div>
      <h1>{product.title}</h1>
      <p>{product.description}</p>
      <p>{product.price}</p>
    </div>
  );
}
