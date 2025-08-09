import Link from "next/link";

export function Header(){
    return(
        <header>
            <nav>
                <ul>
                    <li><Link href="/">Главная</Link></li>
                    <li><Link href="/">Каталог</Link></li>
                    <li><Link href="/">О нас</Link></li>
                    <li><Link href="/">Контакты</Link></li>
                </ul>
            </nav>
            <form action="">
                <input type="text" placeholder="Поиск товаров..."/>
                <button type="submit">🔍</button>
                <button type="button">Корзина</button>
                <button type="button">Профиль</button>
            </form>
        </header>
    )
}