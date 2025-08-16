export function Footer(){
    return(
    <footer className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8 px-6 py-10 bg-gray-100 text-gray-800 bg-white">
        <div>
            <h3 className="bg-gradient-to-r from-[#667EEA] to-[#764BA2] bg-clip-text text-transparent font-bold">TechStore</h3>
            <span>Современная электроника и
гаджеты по лучшим ценам.
Быстрая доставка по всей Беларуси
и гарантия качества.</span>
        </div>
        <div>
            <h3>Покупателям</h3>
            <ul>
                <li>Как оформить заказ</li>
                <li>Доставка и оплата</li>
                <li>Гарантия</li>
            </ul>
        </div>
        <div>
            <h3>О компании</h3>
            <ul>
                <li>О нас</li>
                <li>Новости</li>
            </ul>
        </div>
        <div>
            <h3>Контакты</h3>
            <ul>
                <li>+375 (25) 123-45-67</li>
                <li>infoTechStore@gmail.com</li>
                <li>г. Минск, ул. Тверская, д. 1</li>
                <li>Пн-Вс: 9:00 - 21:00</li>
            </ul>
        </div>
    </footer>
    )
}