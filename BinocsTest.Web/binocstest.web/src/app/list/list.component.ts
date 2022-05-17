import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { filter, map, Observable, tap } from 'rxjs';
import { List, ListItem } from '../models';
import { ListsService } from '../services/list.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(private readonly listsService: ListsService, private readonly route: ActivatedRoute, private readonly router: Router) { }
  listId!: string | null;
  listItems$: Observable<ListItem[]>;
  newListItemContent$: string;
  listName!: string | null;
  ngOnInit(): void {
      this.route.params.subscribe(params => {
      this.listId = params['id'];
      this.loadListItems();
    });

  }
  loadListItems() {

    this.listItems$ = this.listsService.getListItems(this.listId ?? "");

  }
  deleteItem(listItemId : string) {
    this.listsService.deleteListItem(listItemId).pipe(tap(()=> this.loadListItems())).subscribe();
    alert(`ListItem with id ${listItemId} has been deleted.`);
  }

  async addNewItem(id: string) {
    if(this.newListItemContent$ ==""){
      alert(`List item content is required`);
      return;
    }
    this.listsService.postListItem(id, this.newListItemContent$).pipe(tap(()=> this.loadListItems())).subscribe();
    this.newListItemContent$ = "";
  }
  goBack() {
    this.listId = null;
    this.router.navigateByUrl('/');
  }
}
