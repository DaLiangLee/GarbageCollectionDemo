import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TvNetworkUpdate } from '../models/tv-network-update';
import { TvNetwork } from '../models/tv-network';
import { SubCategory, Garbage } from '../models/garbage-collection';

@Injectable()
export class GarbageCollectionService {

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  constructor(
    private http: HttpClient
  ) { }

  getAllGarbages() {
    return this.http.get<any[]>('/api/getAllGarbages', this.httpOptions);
  }
  getCategories() {
    return this.http.get<any[]>('/api/getCategories', this.httpOptions);
  }

  getSubCategoriesById(cId: number | string): Observable<SubCategory> {
    return this.http.get<SubCategory>(`/api/getSuCategories/${cId}`, this.httpOptions);
  }
  createNewGarbage(createModel: any): Observable<Garbage> {
    console.log(createModel);
    return this.http.post<Garbage>('/api/addNewGarbage', createModel, this.httpOptions);
  }

  create(createModel: any): Observable<TvNetworkUpdate> {
    return this.http.post<TvNetworkUpdate>('/api/tvnetworks', createModel, this.httpOptions);
  }

  update(id: string | number, updateModel: TvNetworkUpdate): Observable<TvNetworkUpdate> {
    return this.http.put<TvNetworkUpdate>(`/api/tvnetworks/${id}`, updateModel, this.httpOptions);
  }

  delete(id: string | number): Observable<any> {
    return this.http.delete(`/api/tvnetworks/${id}`, this.httpOptions);
  }
  getAllHistograms(createdTime: string) {
    return this.http.get<any[]>(`/api/getCountByDate/${createdTime}`, this.httpOptions);
  }
  getAllLineCharts(categoryId: number) {
    return this.http.get<any[]>(`/api/getLineChartByCategoryId/${categoryId}`, this.httpOptions);
  }

}
