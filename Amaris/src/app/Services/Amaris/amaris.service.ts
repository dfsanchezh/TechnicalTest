import { Injectable } from '@angular/core';
import axios from 'axios';
import { HttpClient } from '@angular/common/http';
import { VariableService } from '../General/variable.service';
import { AmarisModule } from '../../Models/amaris/amaris.module';

@Injectable({
  providedIn: 'root'
})
export class AmarisService {

  private pathUrl = '';
  private readonly rootUrl = 'Employe';

  constructor(
    private http: HttpClient,
    private _variableService: VariableService,
  ) {
    this._variableService.getVariables().then(e => { this.pathUrl = this._variableService.data.Settings.ApiUrl; });
  }

  GetHeaderHttp() {
    var that = this;
    return {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + sessionStorage.getItem("jwt"),
      }
    }
  }

  GetAll() {
    return new Promise((resolve, reject) => {
      if (this.pathUrl === '') {
        this._variableService.getVariables().then(r => {
          this.pathUrl = this._variableService.data.Settings.ApiUrl;
          resolve(axios.get(`${this.pathUrl}${this.rootUrl}/GetEmployeAll`, this.GetHeaderHttp()));
        });
      } else {
        resolve(axios.get(`${this.pathUrl}${this.rootUrl}/GetEmployeAll`, this.GetHeaderHttp()));
      }
      (error: any) => reject(error);
    });
  }


  GetById(IdEmploye: number) {
    return new Promise((resolve, reject) => {
      if (this.pathUrl === '') {
        this._variableService.getVariables().then(r => {
          this.pathUrl = this._variableService.data.Settings.ApiUrl;
          resolve(axios.get(`${this.pathUrl}${this.rootUrl}/GetDataEmploye?IdEmploye=${IdEmploye}`, this.GetHeaderHttp()));
        });
      } else {
        resolve(axios.get(`${this.pathUrl}${this.rootUrl}/GetDataEmploye?IdEmploye=${IdEmploye}`, this.GetHeaderHttp()));
      }
      (error: any) => reject(error);
    });
  }

}
