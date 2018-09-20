import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GarbageCollectionService } from '../../services/garbage-collection.service';
import { ToastrService } from 'ngx-toastr';

declare const require: any;
@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.scss']
})
export class LineChartComponent implements OnInit {
  options: any;
  constructor(private activatedRoute: ActivatedRoute,
    private garbageServices: GarbageCollectionService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe(queryParams => {
      const categoryId = queryParams.category;
      if (categoryId != null) {
        this.getAllLineCharts(categoryId);
      }
    });
  }
  getAllLineCharts(categoryId: number) {
    console.log(categoryId);

    this.garbageServices.getAllLineCharts(categoryId).subscribe((result: any) => {
      console.log(result);
      const dataAxis = [];
      const data = [];
      result = result.map(function (res) {
        dataAxis.push(res.createdTime);
        data.push(res.qty);
      });
      this.drawChart(dataAxis, data);
    });
  }

  drawChart(xAxisData: any, data: any) {
    // const xAxisData = [];
    // const data1 = [];
    // for (let i = 0; i < 50; i++) {
    //   xAxisData.push('category' + i);
    //   data1.push(i * 5);
    // }
    this.options = {
      legend: {
        data: ['bar'],
        align: 'left'
      },
      tooltip: {},
      xAxis: {
        data: xAxisData,
        silent: false,
        splitLine: {
          show: false
        }
      },
      yAxis: {
      },
      series: [{
        name: 'bar',
        type: 'bar',
        data: data,
        animationDelay: function (idx) {
          return idx * 10;
        }
      }],
      animationEasing: 'elasticOut',
      animationDelayUpdate: function (idx) {
        return idx * 5;
      }
    };
  }

}
