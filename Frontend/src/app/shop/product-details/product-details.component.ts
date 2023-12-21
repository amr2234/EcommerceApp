import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../shared/Models/Products';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product?: Product;
  constructor(private shopService: ShopService, private activeatedRoute: ActivatedRoute) { }
  ngOnInit(): void {
    this.loadProducts();
    }

  loadProducts() {
    const id = this.activeatedRoute.snapshot.paramMap.get('id');
    
    if (id) this.shopService.getProductbyId(+id).subscribe({
      next: product => this.product = product,
      error: Error => console.log(Error)
    });
  }

}
