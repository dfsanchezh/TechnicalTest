import { Component } from '@angular/core';
import { TokenService } from '../../Services/General/token.service';
import { TokenModule } from '../../Models/token/token.module';
import { AmarisModule } from '../../Models/amaris/amaris.module';
import { AmarisService } from '../../Services/Amaris/Amaris.service';
import swal from 'sweetalert2';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})

export class ListComponent {

  IdEmploye: number
  _TokenModule: TokenModule = new TokenModule();

  DataListEmploye: Array<AmarisModule>;

  DataEmploye: AmarisModule = new AmarisModule();

  constructor(
    private _TokenService: TokenService,
    private _AmarisService: AmarisService,
  ) { }


  ngOnInit(): void {
    var that = this;
    sessionStorage.clear();
    that.GetToken();
  }

  GetToken() {
    var that = this;
    var token = sessionStorage.getItem("jwt");
    if (token == null || token == "") {
      return that._TokenService.Authenticate().then((response: any) => {
        if (response.status == 200) {
          that._TokenModule.token = response.data.token;
          sessionStorage.setItem("jwt", that._TokenModule.token);
        }
      }).catch((err: any) => {

      }).finally(() => { });
    }
  }

  ValdateIdEmploye(event: any) {
    var that = this;
    var val = event.target.value;
    var rex = new RegExp('[0-9]+$');
    if (rex.test(val) == false) {
      that.IdEmploye = null;
    }
  }

  SearchInfo() {
    var that = this;
    if (that.IdEmploye > 0) {
      that.GetById(that.IdEmploye)
    } else {
      that.GetAll();
    }
    
  }

  GetAll() {
    var that = this;
    that._AmarisService.GetAll().then((response: any) => {
      if (response.status == 200) {
        that.DataListEmploye = response.data
      }
    }).catch((err: any) => {
      that.DataListEmploye = [];
      swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Something went wrong with service! Try again.'
      });
    }).finally(() => {

    });
  }

  GetById(IdEmploye){
    var that = this;
    that._AmarisService.GetById(IdEmploye).then((response: any) => {
      if (response.status == 200) {
        that.DataEmploye = response.data
        that.DataListEmploye = [];
        that.DataListEmploye.push(that.DataEmploye)
      }else{
       
      }
    }).catch((err: any) => {
      that.DataListEmploye = [];
      swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Something went wrong with service! Try again.'
      });
    }).finally(() => {

    });

    
  }

}
