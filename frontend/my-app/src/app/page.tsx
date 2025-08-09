import Link from "next/link";
import { Category, Product } from "./types";
import { Header } from "@/components/blocks/Header";
import { CategorySection } from "@/components/blocks/CategorySection";
import { ProductSection } from "@/components/blocks/ProductSection";

export default async function Home() {
  const res1 = await fetch('http://localhost:5270/ProductCategories', { cache: 'no-store'});
  const res2 = await fetch('http://localhost:5270/api/Products', { cache: 'no-store'});
  const categories: Category[] = await res1.json();
  const products: Product[] = await res2.json();
  return (
    <main>
      <Header/>
      <CategorySection categories={categories}/>
      <ProductSection products={products}/>
    </main>
  );
}
