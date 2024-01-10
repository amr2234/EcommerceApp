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
export class NewProduct {
  id: number =0
  name: string = ""
  description: string =""
  price: number = 0
  pictureUrl: string= ""
  productTypeId: number =0
  productBrandId: number =0
}
