import { Component, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Brands } from '../../shared/Models/brands';
import { NewProduct } from '../../shared/Models/Products';
import { Types } from '../../shared/Models/types';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent {
  addproduct: NewProduct = new NewProduct();

  @ViewChild("NewProduct")
  NewProduct!: NgForm;
  isSubmitted: boolean = false;
  types: Types[] = [];
  brands: Brands[] = []
  constructor(private router: Router, private Service: ShopService, private toastr: ToastrService) { }

  ngOnInit(): void {

    this.getbrands();
    this.getTypes();
}

  Addproduct(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.Service.Addproduct(this.addproduct).subscribe(async data => {
        if (data != null && data.body != null) {
          if (data != null && data.body != null) {
            var resultData = data.body;
            if (resultData != null && resultData.isSuccess) {
              this.toastr.success(resultData.message);
              setTimeout(() => {
                this.router.navigate(['']);
              }, 500);
            }
          }
        }
        this.toastr.success('Added successfully')
      },
        async (error: { message: string | undefined; }) => {
          this.toastr.error(error.message);
          setTimeout(() => {
            this.router.navigate(['']);
          }, 500);
        });
    }
  }
  getbrands() {
    this.Service.getBrands().subscribe(

      {
        next: Response => this.brands = [{ id: 0, name: 'All' }, ...Response],
        error: Error => console.log(Error)

      }
    )

  }
  getTypes() {
    this.Service.getTypes().subscribe(

      {
        next: Response => this.types = [{ id: 0, name: 'All' }, ...Response],
        error: Error => console.log(Error)

      }
    )
  }

}

  


  



