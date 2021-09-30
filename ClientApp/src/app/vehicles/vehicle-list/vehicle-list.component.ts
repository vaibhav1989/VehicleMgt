import { Component, OnInit } from '@angular/core';
import { Vehicles } from '../../shared/vehicles.model';
import { VehiclesService } from '../../shared/vehicles.service';

@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {

  constructor(public service: VehiclesService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Vehicles) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteVehicleDetail(id)
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
