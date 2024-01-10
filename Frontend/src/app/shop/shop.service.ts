import { HttpClient, HttpParams } from '@angular/common/http';
import { Type } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { Brands } from '../shared/Models/brands';
import { Pagenation } from '../shared/Models/Pagenation';
import { NewProduct, Product } from '../shared/Models/Products';
import { ShopParams } from '../shared/Models/ShopParams';
import { Types } from '../shared/Models/types';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = " https://localhost:5001/api/";
  formData: NewProduct = new NewProduct()
  formSubmitted: boolean = false;
  list: NewProduct[] = [];
  constructor(private http: HttpClient) { }

  getproducts(shopParams: ShopParams) {

    let params = new HttpParams();

    if (shopParams.brandId > 0) params = params.append('brandId', shopParams.brandId);
    if (shopParams.typeId) params = params.append('typeId', shopParams.typeId);
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);
    if (shopParams.search) params = params.append('search', shopParams.search);

    return this.http.get<Pagenation<Product[]>>(this.baseUrl + "products", { params });
  }
  getTypes() {
    return this.http.get<Types[]>(this.baseUrl + "products/types");
  }

  getBrands() {
    return this.http.get<Brands[]>(this.baseUrl + "products/brands");
  }
  getProductbyId(id: number) {
    return this.http.get<Product>(this.baseUrl + "products/" + id);
  }
  public Addproduct(model: any): Observable<any> {
    return this.http.post(this.baseUrl + "products", model);
  }  
  resetForm(form: NgForm) {
    form.form.reset()
    this.formData = new NewProduct()
    this.formSubmitted = false
  }

}

