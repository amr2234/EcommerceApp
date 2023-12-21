import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from '../../../environment/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent {
  baseUrl = environment.apiUrl;
  ValidatioError : string [] = [];
  constructor(private http: HttpClient) { }

  get404Error() {
    this.http.get(this.baseUrl + 'products/42').subscribe({
      next: Response => console.log(Response),
      error: Error => console.log(Error)
    })
  }
  get500Error() {
    this.http.get(this.baseUrl + 'buggy/servererror').subscribe({
      next: Response => console.log(Response),
      error: Error => console.log(Error)
    })
  }
  get400Error() {
    this.http.get(this.baseUrl + 'buggy/badrequest').subscribe({
      next: Response => console.log(Response),
      error: Error => console.log(Error)
    })
  }
  get400ValidationError() {
    this.http.get(this.baseUrl + 'products/fortytwo').subscribe({
      next: Response => console.log(Response),
      error: Error => {
        this.ValidatioError = Error.errors;
        console.log(Error)
      }
    })
  }

}
