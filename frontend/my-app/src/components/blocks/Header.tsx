import Link from "next/link";

export function Header(){
    return(
        <header className="sticky top-0 z-50 bg-white shadow-sm px-4 py-2 flex items-center justify-between flex-wrap gap-4">
            <Link href="/" className="text-xl font-bold bg-gradient-to-r from-[#667EEA] to-[#764BA2] bg-clip-text text-transparent">
                TechStore
            </Link>

            <nav className="flex-1">
                <ul className="flex justify-center gap-6 font-medium text-gray-700">
                <li><Link href="/">Главная</Link></li>
                <li><Link href="/">Каталог</Link></li>
                <li><Link href="/">О нас</Link></li>
                <li><Link href="/">Контакты</Link></li>
                </ul>
            </nav>

            <form className="relative w-full max-w-sm">
                <input
                type="text"
                placeholder="Поиск товаров..."
                className="w-full border border-[#667EEA]/20 rounded-3xl pl-4 pr-10 py-2 transition focus:outline-none focus:ring-2 focus:ring-[#667EEA]/40"
                />
                <button
                type="submit"
                className="absolute right-2 top-1/2 -translate-y-1/2 text-gray-500 hover:text-[#667EEA] transition"
                aria-label="Поиск"
                >
                🔍
                </button>
            </form>

            <div className="flex gap-4">
                <button type="button" className="px-6 py-2 rounded-full bg-gradient-to-r from-blue-500 to-purple-600 text-white font-semibold shadow-md hover:shadow-lg transition">
                Корзина
                </button>
                <button type="button" className="px-6 py-2 rounded-full bg-gradient-to-r from-blue-500 to-purple-600 text-white font-semibold shadow-md hover:shadow-lg transition">
                Профиль
                </button>
            </div>
        </header>

    )
}