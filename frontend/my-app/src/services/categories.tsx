import { Category } from "@/app/types";

export const fetchCategories = async (): Promise<Category[]> =>{
    const res = await fetch("http://localhost:5270/ProductCategories")
    const data = await res.json()
    return data;
}