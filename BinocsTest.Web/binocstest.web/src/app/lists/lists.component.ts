import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, of, tap } from 'rxjs';
import { List } from '../models';
import { ListsService } from '../services/list.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {

  
  @Output()
  private listCreated = new EventEmitter();
  newListName: string;
  //private _listDetailsOpenedSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  //public listDetailsOpened: Observable<boolean> = this._listDetailsOpenedSubject.asObservable();

  constructor(private readonly listsService: ListsService, private readonly router: Router) {

   }
  lists$ : Observable<List[]>;

  ngOnInit(): void {
    
    this.loadLists();
  }
  loadLists(){
    this.newListName = "";
    this.lists$ =  this.listsService.getAllLists();

  }
  goToList(listId: string, listName : string) {
   
    this.router.navigateByUrl('list/'+ listId);
  
  }

 async createNewList() {
    if(this.newListName ==""){
      alert(`List name is required`);
      return;
    }
    this.listsService.createNewList(this.newListName).pipe(tap(()=> this.loadLists())).subscribe();
    alert(`List with name ${this.newListName} has been created.`);
  
  }
}



