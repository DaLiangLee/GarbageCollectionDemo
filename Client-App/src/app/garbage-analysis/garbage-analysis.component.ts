import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { GarbageCollectionService } from '../services/garbage-collection.service';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-garbage-analysis',
  templateUrl: './garbage-analysis.component.html',
  styleUrls: ['./garbage-analysis.component.scss'],
  providers: [DatePipe]
})
export class GarbageAnalysisComponent implements OnInit {
  generalCategoryList = [];
  subcategoryList = [];
  selectedItems = [];
  categorysettings = {};
  subCategorysettings = {};
  settings = {};
  formModel = {
    generalCate: [],
    subCate: [],
    searchDate: new Date()
  };
  showCategory = true;
  showDate = true;
  busy: Subscription;
  disableSubCategory = true;
  disableSaveBtn = false;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe,
    private garbageServices: GarbageCollectionService,
    private toastr: ToastrService) { }

  ngOnInit() {
    const condition = this.route.snapshot.paramMap.get('condition');
    console.log(condition);
    if (condition) {
      switch (condition) {
        case 'category':
          this.showCategory = false;
          break;
        case 'date':
          this.showDate = false;
          break;
      }
    }


    this.generalCategoryList = [
      { 'id': 1, 'itemName': '可回收垃圾' },
      { 'id': 2, 'itemName': '厨余垃圾' },
      { 'id': 3, 'itemName': '有害垃圾' },
      { 'id': 4, 'itemName': '其他垃圾' }
    ];

    this.subcategoryList = [
      { 'id': 1, 'itemName': '废纸(废纸盒<黄板纸、花纸>)' },
      { 'id': 2, 'itemName': '废塑料' },
      { 'id': 3, 'itemName': '废金属' },
      { 'id': 4, 'itemName': '废玻璃' },
      { 'id': 5, 'itemName': '纺织物' }
    ];


    this.categorysettings = { singleSelection: true, text: '选择大类' };
    this.subCategorysettings = { singleSelection: true, text: '选择子类' };
  }

  onItemSelect(item: any) {
    console.log(item);
    console.log(this.selectedItems);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
  onDeSelectAll(items: any) {
    console.log(items);
  }
  search() {
    console.log(this.formModel);

    if (this.showCategory) {
      const date = this.datePipe.transform(this.formModel.searchDate, 'yyyy-MM-dd');

      this.router.navigate(['histogram'], {
        queryParams: {
          searchDate: date
        }
      });
    } else {
      this.router.navigate(['lineChart'], {
        queryParams: {
          category: this.formModel.generalCate[0].id
        }
      });
    }
  }
  // 柱状图
  onCategorySelect(item: any) {
    console.log(item);
    this.disableSubCategory = false;
    this.subcategoryList = [];
    this.garbageServices.getSubCategoriesById(this.formModel.generalCate[0].id).subscribe((result: any) => {
      this.subcategoryList = result;
      this.formModel.subCate = [];
      console.log(this.subcategoryList);
    }, err => {
      console.error(err);
      this.toastr.error(err);
    });
  }
  OnItemDeSelect(item: any) {
    this.subcategoryList = [];
  }
  onSubmit(form: NgForm) {
    this.disableSaveBtn = true;
  }
}
