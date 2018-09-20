import { Component, OnInit } from '@angular/core';

import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { GarbageCollectionService } from '../services/garbage-collection.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-garbage-list',
  templateUrl: './garbage-list.component.html',
  styleUrls: ['./garbage-list.component.scss']
})
export class GarbageListComponent implements OnInit {
  constructor(
    private garbageServices: GarbageCollectionService,
    private toastr: ToastrService) { }
    contentArray = new Array(90).fill('');
    returnedArray: string[];
    garbageList = [];

  ngOnInit(): void {
    this.contentArray = this.contentArray.map((v: string, i: number) => `Content line ${i + 1}`);
    this.returnedArray = this.contentArray.slice(0, 10);
    this.getAllGarbages();
  }

  pageChanged(event: PageChangedEvent): void {
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedArray = this.contentArray.slice(startItem, endItem);
  }
  getAllGarbages() {
    this.garbageServices.getAllGarbages().subscribe((result: any) => {
      this.garbageList = result;
      console.log(this.garbageList);
    }, err => {
      console.error(err);
      this.toastr.error(err);
    });
  }
}
