import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Pagenation } from './shared/Models/Pagenation';
import { Product } from './shared/Models/Products';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Ecommerce';
  Products: Product[] = [];
  constructor(private http: HttpClient) {

  }
  ngOnInit(): void {
    this.http.get<Pagenation<Product[]>>('https://localhost:5001/api/Products').subscribe({
      next: Response   => this.Products = Response.data,
      error: Error => console.log(Error),
      complete: () => {
        console.log("Completed");
      }
    })
    }
}
