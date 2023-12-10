export interface Root {
  pageIndex: number
  totalCount: number
  pageSize: number
  data: Product[]
}

export interface Product {
  id: number
  name: string
  description: string
  price: number
  pictureUrl: string
  productType: string
  productBrand: string
}
