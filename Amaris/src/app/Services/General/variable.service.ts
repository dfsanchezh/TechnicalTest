import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VariableService {

  data: any;
  private ConfigRoute = "./assets/variable/variable-config.json";

  constructor(
    private http: HttpClient
  ) { }

  getVariables() {
    var that = this;
    return that.http.get(that.ConfigRoute).toPromise().then(
      r => { that.data = r; }
    );
  }
}
