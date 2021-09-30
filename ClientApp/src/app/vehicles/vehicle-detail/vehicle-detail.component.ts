import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Vehicles } from '../../shared/vehicles.model';
import { VehiclesService } from '../../shared/vehicles.service';
import { Vmodels } from '../../shared/vmodels.model';

@Component({
  selector: 'app-vehicle-detail',
  templateUrl: './vehicle-detail.component.html',
  styleUrls: ['./vehicle-detail.component.css']
})
export class VehicleDetailComponent implements OnInit {
  public manufacturerid: number = 1;

  list: Vmodels[];
  yearlist: any[];
  statuslist: any[];
  colorlist: any[];
  constructor(public service: VehiclesService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Vmodels[]>(baseUrl + 'api/models').subscribe(result => {
      this.list = result;
      console.log(this.list);
    }, error => console.error(error));
    http.get<any[]>(baseUrl + 'api/Common/GetConfigValues/cYear').subscribe(result => {
      this.yearlist = result;
      console.log(result);
    }, error => console.error(error));
    http.get<any[]>(baseUrl + 'api/Common/GetConfigValues/cVehicleStatus').subscribe(result => {
      this.statuslist = result;
      console.log(result);
    }, error => console.error(error));
    http.get<any[]>(baseUrl + 'api/Common/GetConfigValues/cColour').subscribe(result => {
      this.colorlist = result;
      console.log(result);
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
    this.service.postVehicleDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        //this.toastr.success('Submitted successfully', 'Payment Detail Register')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putVehicleDetail().subscribe(
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
    this.service.formData = new Vehicles();
  }

  onChangeSelection(form: NgForm) {
    this.manufacturerid = 2;
  }

  setManufacturerid() {
    console.log('Hello')
    this.manufacturerid = parseInt("5");
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      //this.labelImport.nativeElement.innerText = file.name;
      //this.profileForm.patchValue({
      //  picture: file,
      //});
    }
  }
  
}
