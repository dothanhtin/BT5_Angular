import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialogConfig,MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { model } from '../../model';
import { ModelService } from '../../../shared/model.service';
import { EmployeeComponent } from '../employee/employee.component';
import { ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class EmployeeListComponent implements OnInit {
  models: model[] = [];

  listData!: MatTableDataSource<any>;
  displayedColumns: string[] = ['code', 'name', 'birthday', 'email', 'address', 'image', 'actions'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  searchKey!: string;

  constructor(private service: ModelService, private dialog: MatDialog) { }

  ngOnInit(): void {
    // this.service.getModels().subscribe(models => {
    //   // models = this.models;
    //   this.listData = new MatTableDataSource(models);
    //   this.listData.sort = this.sort;
    //   this.listData.paginator = this.paginator;
    // });
    this.loadData();
  }

  onCreate() {
    this.service.initializeFormGroup();
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "40%";
    let dialogRef = this.dialog.open(EmployeeComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      this.loadData();
    });
  }
  // src = 'http://localhost:4000/api/';
  onEdit(row: any) {
    console.log(row);
    this.service.populateForm(row);
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "40%";
    let dialogRef = this.dialog.open(EmployeeComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      // this.loadData();
      setTimeout(()=>{ this.loadData() }, 1000) //update bị chậm chờ couchbase thực hiện xong
    });
  }

  onDelete(id: any) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteModel(id);
      this.loadData();
    }
  }
  public loadData() {
    this.service.getModels()
      .subscribe(models => {
        // this.models = models;
        this.listData = new MatTableDataSource(models);
        this.listData.sort = this.sort;
        this.listData.paginator = this.paginator;
      });
  }
  

}
