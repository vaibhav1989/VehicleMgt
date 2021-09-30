import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Vmodels } from './vmodels.model';

@Injectable({
  providedIn: 'root'
})
export class VmodelsService {

  readonly baseURL;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  formData: Vmodels = new Vmodels();
  list: Vmodels[];

  postModelDetail() {
    return this.http.post(this.baseURL + 'api/models', this.formData);
  }

  putModelDetail() {
    return this.http.put('${this.baseURL}/${this.formData.id}', this.formData);
  }

  deleteModelDetail(id: number) {
    return this.http.delete('${this.baseURL}/${id}');
  }

  refreshList() {
    this.http.get(this.baseURL + 'api/models')
      .toPromise()
      .then(res => this.list = res as Vmodels[]).then(res => console.log(res)).then(res => console.log(res));
      
  }


}
