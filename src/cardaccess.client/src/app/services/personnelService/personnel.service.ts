import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable, InjectionToken } from '@angular/core';
import { Observable } from 'rxjs';
import { Personnel } from 'src/app/model/Personnel/personnel';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable({
  providedIn: 'root'
})
export class PersonnelService {

  private getBadgeApi: string = 'api/Personnel/getPersonnel';
  private url: string;

  private options_: any = {
    //observe: "response",
    // responseType: "blob",
    headers: new HttpHeaders({
      "Accept": "application/json"
    })
  };
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + this.getBadgeApi;
  }

  getBadges(): Observable<any> {
    return this.http.get<Personnel[]>(this.url, this.options_);
  }
}
