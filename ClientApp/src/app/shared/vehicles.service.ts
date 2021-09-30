import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Vehicles } from './vehicles.model';

@Injectable({
  providedIn: 'root'
})
export class VehiclesService {

  readonly baseURL;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  formData: Vehicles = new Vehicles();
  list: Vehicles[];

  postVehicleDetail() {
    return this.http.post(this.baseURL + 'api/vehicles', this.formData);
  }

  putVehicleDetail() {
    return this.http.put('${this.baseURL}/${this.formData.id}', this.formData);
  }

  deleteVehicleDetail(id: number) {
    return this.http.delete('${this.baseURL}/${id}');
  }

  refreshList() {
    this.http.get(this.baseURL + 'api/vehicles')
      .toPromise()
      .then(res => this.list = res as Vehicles[]).then(res => console.log(res));
  }
}
