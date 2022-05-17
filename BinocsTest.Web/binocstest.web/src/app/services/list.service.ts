import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, shareReplay, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { List, ListItem, TotalListItemCount, CreateListResponse } from '../models';


@Injectable({
  providedIn: 'root'
})
export class ListsService {
  invalidator = new Subject<void>();
  list : List;
  private baseUrl = environment.baseUrl;
  
  constructor(private readonly http: HttpClient) { 

  }

  getAllLists(): Observable<List[]> { 
    console.log(`${this.baseUrl}/list`);
    return this.http.get<List[]>(`${this.baseUrl}/list`).pipe(
    map(res=> res["allLists"]),
    shareReplay()
  );}

  getAllListAndItemsCount() : Observable<TotalListItemCount> {  
      return this.http.get<TotalListItemCount>(`${this.baseUrl}/list/total`).pipe(
    map(res => res),
    shareReplay()
  );}
  
  createNewList(name: string) : Observable<any> {
     
      return this.http.post(`${this.baseUrl}/list`, { name }).pipe( shareReplay());
     
  }

  getListItems(listId: string)  : Observable<ListItem[]> {
      return  this.http.get<ListItem[]>(`${this.baseUrl}/list/${listId}/listitems`)
      .pipe(
            map(res => res["listItems"]),
            shareReplay()
            )
      }
  postListItem(listId: string, content: string) : Observable<any> {
    return this.http.post(`${this.baseUrl}/list/${listId}/listitem`, { content })
    .pipe(shareReplay());
  }
  deleteListItem(listItemId: string) : Observable<any> {
    return this.http.delete(`${this.baseUrl}/list/listitem/${listItemId}`)
    .pipe(shareReplay());
  }
}
