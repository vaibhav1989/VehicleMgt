import { Component, OnInit } from '@angular/core';
import { Manufacturers } from '../../shared/manufacturers.model';
import { ManufacturersService } from '../../shared/manufacturers.service';

@Component({
  selector: 'app-manufacturer-list',
  templateUrl: './manufacturer-list.component.html',
  styleUrls: ['./manufacturer-list.component.css']
})
export class ManufacturerListComponent implements OnInit {

  constructor(public service: ManufacturersService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Manufacturers) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteManufacturerDetail(id)
        .subscribe(
          res => {
            this.service.refreshList();
            //this.toastr.error("Deleted successfully", 'Payment Detail Register');
          },
          err => { console.log(err) }
        )
    }
  }

}
