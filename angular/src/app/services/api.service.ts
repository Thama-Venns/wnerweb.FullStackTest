import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private readonly http: HttpClient) { }

  public getFiles() {
    return this.http.get(`${environment.apis.default.url}/api/app/full-stack-test/files`)
  }

  public getFileById(id: string) {                                               // For some reason the call appends a (- / %E2%80%8B) character on the request.
    return this.http.get(`${environment.apis.default.url}/api/app/full-stack-test/${id.replace("%E2%80%8B", "")}/doc`)
  }

  public submitFile(formData: FormData) {
    // const headers = new HttpHeaders().append('Content-Disposition', 'multipart/form-data');
    // headers.append('Accept', 'application/json');
    return this.http.post(`${environment.apis.default.url}/api/app/full-stack-test/save-file-content`, formData)
  }
}
