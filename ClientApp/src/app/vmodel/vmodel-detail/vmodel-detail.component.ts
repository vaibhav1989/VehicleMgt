import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Manufacturers } from '../../shared/manufacturers.model';
import { Vmodels } from '../../shared/vmodels.model';
import { VmodelsService } from '../../shared/vmodels.service';

@Component({
  selector: 'app-vmodel-detail',
  templateUrl: './vmodel-detail.component.html',
  styleUrls: ['./vmodel-detail.component.css']
})
export class VmodelDetailComponent implements OnInit {
  list: Manufacturers[];
  constructor(public service: VmodelsService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Manufacturers[]>(baseUrl + 'api/manufacturers').subscribe(result => {
      this.list = result;
      console.log(this.list);
    }, error => console.error(error));
  }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postModelDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        //this.toastr.success('Submitted successfully', 'Payment Detail Register')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putModelDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        //this.toastr.info('Updated successfully', 'Payment Detail Register')
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Vmodels();
  }

}

interface Summary {
  name: string;
}
