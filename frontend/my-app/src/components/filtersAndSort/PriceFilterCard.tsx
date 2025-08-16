export function PriceFilterCard(){
    return(
        <div className="bg-[#F8F9FA] rounded-xk">
            <h2>Цена (₽)</h2>
            <div className="grid grid-cols-2 gap-3 p-1">
                <input type="text" className="border-2 border-[#757575]/30 rounded-md" placeholder="От"/>
                <input type="text" className="border-2 border-[#757575]/30 rounded-md" placeholder="До"/>
            </div>
        </div>
    )
}