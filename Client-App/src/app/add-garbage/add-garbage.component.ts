import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { GarbageCollectionService } from '../services/garbage-collection.service';
import { Subscription } from 'rxjs';
import { NgForm } from '@angular/forms';
import { Garbage } from '../models/garbage-collection';

@Component({
  selector: 'app-add-garbage',
  templateUrl: './add-garbage.component.html',
  styleUrls: ['./add-garbage.component.scss']
})
export class AddGarbageComponent implements OnInit {

  generalCategoryList = [];
  subcategoryList = [];
  selectedItems = [];
  categorysettings = {};
  subCategorysettings = {};
  formModel = {
    generalCate: [],
    subCate: [],
    createdDate: new Date(),
    recyclingQty: 10
  };
  submitted = false;
  model = {
    CreatedTime: new Date(),
    SubId: 0,
    RecyclingQty: 0
  };
  busy: Subscription;
  disableSubCategory = true;
  disableSaveBtn = false;
  constructor(
    private garbageServices: GarbageCollectionService,
    private toastr: ToastrService) { }

  ngOnInit() {
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
    this.model.CreatedTime = this.formModel.createdDate;
    this.model.SubId = this.formModel.subCate[0].id;
    this.model.RecyclingQty = this.formModel.recyclingQty;
    this.submitted = true;

    const op = this.garbageServices.createNewGarbage(this.model);
    this.busy = op.subscribe(result => {
      if (result) {
        this.toastr.success('添加成功');
      }
    }, err => {
      console.error(err);
      this.toastr.error('发生了错误');
    }, () => {
      this.formModel.recyclingQty = 10;
      // this.reset();
      // location.reload();
    });
  }
  reset() {
    this.formModel.generalCate = [];
    this.formModel.subCate = [];
    this.formModel.recyclingQty = 0;
    this.generalCategoryList = [];
    this.subcategoryList = [];
  }
}
