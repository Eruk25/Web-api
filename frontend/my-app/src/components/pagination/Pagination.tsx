type PaginationProps = {
    currentPage: number;
    totalPages: number;
    onPageChange: (page: number) => void;
}

export function Pagination({currentPage, totalPages, onPageChange}: PaginationProps){
    return(
        <div>
            <div className="flex justify-center gap-2 mt-6">
      <button
        onClick={() => onPageChange(currentPage - 1)}
        disabled={currentPage === 1}
        className="px-3 py-1 border rounded disabled:opacity-50"
      >
        ← Назад
      </button>

      <span className="px-3 py-1 text-sm">
        Страница {currentPage} из {totalPages}
      </span>

      <button
        onClick={() => onPageChange(currentPage + 1)}
        disabled={currentPage === totalPages}
        className="px-3 py-1 border rounded disabled:opacity-50"
      >
        Вперёд →
      </button>
    </div>
        </div>
    );
}