import { Injectable } from '@angular/core';
import axios, { AxiosStatic } from 'axios';
import { VariableService } from '../General/variable.service';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  private pathUrl = '';
  private readonly rootUrl = 'Authentication';

  constructor(
    private _variableService: VariableService
  ) {
    this._variableService.getVariables().then(e => { this.pathUrl = this._variableService.data.Settings.ApiUrl; });
  }

  GetHeaderHttp() {
    return { headers: { 'Content-Type': 'application/json' } }
  }


  Authenticate() {
    return new Promise((resolve, reject) => {
      if (this.pathUrl === '') {
        this._variableService.getVariables().then(r => {
          this.pathUrl = this._variableService.data.Settings.ApiUrl;
          resolve(axios.post(`${this.pathUrl}${this.rootUrl}/Authentication`, this.GetHeaderHttp()));
        });
      } else {
        resolve(axios.post(`${this.pathUrl}${this.rootUrl}/Authentication`, this.GetHeaderHttp()));
      }
      (error: any) => reject(error);
    })
  }

}
