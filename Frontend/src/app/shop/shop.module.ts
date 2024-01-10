import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ShopRoutingModule } from './shop-routing.module';
import { AddproductComponent } from './addproduct/addproduct.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    ProductDetailsComponent,
    AddproductComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ShopRoutingModule,
    FormsModule
  ]

})
export class ShopModule { }
