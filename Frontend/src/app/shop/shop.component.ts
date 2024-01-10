import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Brands } from '../shared/Models/brands';
import { NewProduct, Product } from '../shared/Models/Products';
import { ShopParams } from '../shared/Models/ShopParams';
import { Types } from '../shared/Models/types';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef;
  products: Product[] = [];
  types: Types[] = [];
  brands: Brands[] = []
  shopParams = new ShopParams();
  SortOption = [
    { name: "Alphabetical", value: "name" },
    { name: "Price: Low to high", value: "priceAsc" },
    { name: "Price: high to Low", value: "priceDesc" },
  ];
  totalCount = 0;

  constructor(private shopService: ShopService, private toastr: ToastrService) { }



  ngOnInit(): void {
    this.getproducts();
    this.getbrands();
    this.getTypes();
  }

  getproducts() {
    this.shopService.getproducts(this.shopParams).subscribe({
      next: Response => {
        this.products = Response.data
        this.shopParams.pageNumber = Response.pageIndex;
        this.shopParams.pageSize = Response.pageSize;
        this.totalCount = Response.totalCount;
      },
      error: Error => console.log(Error),

    })
  }
  getbrands() {
    this.shopService.getBrands().subscribe(

      {
        next: Response => this.brands = [{ id: 0, name: 'All' }, ...Response ],
        error: Error => console.log(Error)

      }
    )

  }



  getTypes() {
    this.shopService.getTypes().subscribe(

      {
        next: Response => this.types = [{ id: 0, name: 'All' }, ...Response ],
        error: Error => console.log(Error)

      }
    )
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getproducts();
  }
  onTypesSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getproducts();
  }
  onSelectedSort(event: any) {
    this.shopParams.sort = event.target.value;
    this.getproducts();
  }
  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getproducts();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getproducts();
  }
  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getproducts();

  }
}











