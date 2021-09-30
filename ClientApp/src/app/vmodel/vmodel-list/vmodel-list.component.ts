import { Component, OnInit } from '@angular/core';
import { VehiclesService } from '../../shared/vehicles.service';
import { Vmodels } from '../../shared/vmodels.model';
import { VmodelsService } from '../../shared/vmodels.service';

@Component({
  selector: 'app-vmodel-list',
  templateUrl: './vmodel-list.component.html',
  styleUrls: ['./vmodel-list.component.css']
})
export class VmodelListComponent implements OnInit {

  constructor(public service: VmodelsService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Vmodels) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteModelDetail(id)
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
