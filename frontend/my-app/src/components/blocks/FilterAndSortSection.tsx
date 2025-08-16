import { CategoryFilterCard } from "../filtersAndSort/CategoryFilterCard";
import { PriceFilterCard } from "../filtersAndSort/PriceFilterCard";
import { ProviderFilterCard } from "../filtersAndSort/ProviderFilterCard";
type FilterProps = {
    categoryTitles: string[];
    providerNames: string[];
}
export function FilterAndSortSection({categoryTitles, providerNames}: FilterProps){
    return(
        <section className="bg-white/90 m-4 rounded-xl p-6 space-y-6">
            <div className="grid grid-cols-2">
                <h1 className="text-[#667EEA] font-bold text-lg justify-self-start">Фильтры и сортировка</h1>
                <button type="button" className="border-2 border-[#667EEA] rounded-3xl px-4 py-2 text-[#667EEA] font-bold justify-self-end">
                    Скрыть фильтры
                </button>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                <CategoryFilterCard categoryTitles={categoryTitles} />
                <ProviderFilterCard />
                <PriceFilterCard />
            </div>

            <div className="flex flex-wrap gap-3">
                <button className="px-4 py-2 rounded-full border border-gray-300 bg-white text-gray-800 hover:bg-gray-100 ы">По умолчанию</button>
                <button className="px-4 py-2 rounded-full border border-gray-300 bg-white text-gray-800 hover:bg-gray-100 ">Цена: по возрастанию</button>
                <button className="px-4 py-2 rounded-full border border-gray-300 bg-white text-gray-800 hover:bg-gray-100 ">Цена: по убыванию</button>
                <button className="px-4 py-2 rounded-full border border-gray-300 bg-white text-gray-800 hover:bg-gray-100 ">По алфавиту</button>
                <button className="px-4 py-2 rounded-full bg-red-500 text-white font-bold hover:bg-red-600">Очистить фильтры</button>
            </div>
        </section>

    )
}