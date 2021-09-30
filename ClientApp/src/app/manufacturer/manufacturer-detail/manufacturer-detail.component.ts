import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Manufacturers } from '../../shared/manufacturers.model';
import { ManufacturersService } from '../../shared/manufacturers.service';

@Component({
  selector: 'app-manufacturer-detail',
  templateUrl: './manufacturer-detail.component.html',
  styleUrls: ['./manufacturer-detail.component.css']
})
export class ManufacturerDetailComponent implements OnInit {

  constructor(public service: ManufacturersService) { }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postManufacturerDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
        //this.toastr.success('Submitted successfully', 'Payment Detail Register')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putManufacturerDetail().subscribe(
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
    this.service.formData = new Manufacturers();
  }

}
