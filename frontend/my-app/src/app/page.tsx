import { Category, Product, Provider} from "./types";
import { Header } from "@/components/blocks/Header";
import { CategorySection } from "@/components/blocks/CategorySection";
import { ProductSection } from "@/components/blocks/ProductSection";
import { Footer } from "@/components/blocks/Footer";
import { FilterAndSortSection } from "@/components/blocks/FilterAndSortSection";

export default async function Home() {
  const res1 = await fetch('http://localhost:5270/ProductCategories', { cache: 'no-store'});
  const res2 = await fetch('http://localhost:5270/Products', { cache: 'no-store'});
  const res3 = await fetch('http://localhost:5270/Providers', { cache: 'no-store'});
  const categories: Category[] = await res1.json();
  const products: Product[] = await res2.json();
  const providers: Provider[] = await res3.json();
  const categoryTitles = categories.map((category)=>category.title)
  const providerNames = providers.map((provider) => (provider.name));
  return (
    <main className="bg-[#6975DE]">
      <Header/>
      <FilterAndSortSection categoryTitles={categoryTitles} providerNames={providerNames}/>
      <CategorySection categories={categories}/>
      <ProductSection/>
      <Footer/>
    </main>
  );
}
