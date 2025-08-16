export interface Product{
  id: number;
  title: string;
  description: string;
  price: number
  imegePath: string;
}

export interface Category{
  id: number;
  title: string;
  imagePath: string;
}

export interface Provider{
  id: number;
  name: string;
}