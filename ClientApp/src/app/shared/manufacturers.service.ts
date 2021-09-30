import { Inject, Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Manufacturers } from './manufacturers.model';

@Injectable({
  providedIn: 'root'
})
export class ManufacturersService {
  readonly baseURL;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  formData: Manufacturers = new Manufacturers();
  list: Manufacturers[];

  postManufacturerDetail() {
    return this.http.post(this.baseURL + 'api/manufacturers', this.formData);
  }

  putManufacturerDetail() {
    return this.http.put('${this.baseURL}/${this.formData.paymentDetailId}', this.formData);
  }

  deleteManufacturerDetail(id: number) {
    return this.http.delete('${this.baseURL}/${id}');
  }

  refreshList() {
    this.http.get(this.baseURL + 'api/manufacturers')
      .toPromise()
      .then(res => this.list = res as Manufacturers[]);
  }

}
