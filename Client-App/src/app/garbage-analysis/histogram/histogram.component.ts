import { Component, OnInit } from '@angular/core';
import { graphic } from 'echarts';
import { ActivatedRoute } from '@angular/router';
import { GarbageCollectionService } from '../../services/garbage-collection.service';
import { ToastrService } from 'ngx-toastr';
import * as _ from 'underscore';

@Component({
  selector: 'app-histogram',
  templateUrl: './histogram.component.html',
  styleUrls: ['./histogram.component.scss']
})
export class HistogramComponent implements OnInit {

  options: any;
  detectEventChanges = true;
  searchDate: any;
  dataAxis = [];
  data = [];
  constructor(private activatedRoute: ActivatedRoute,
    private garbageServices: GarbageCollectionService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe(queryParams => {
      this.searchDate = queryParams.searchDate;
      console.log(this.searchDate);
    }, err => {
      this.toastr.error('error');
    });

    this.getAllHistograms(this.searchDate);
  }

  onChartEvent(event: any, type: string) {
    console.log('chart event:', type, event);
  }
  getAllHistograms(createdTime: string) {
    this.garbageServices.getAllHistograms(createdTime).subscribe((result: any) => {
      console.log(result);
      if (result.length !== 0) {
        const dataAxis = [];
        const data = [];
        result = result.map(function (res) {
          dataAxis.push(res.categoryName);
          data.push(res.qty);
        });
        this.dataAxis = dataAxis;
        this.data = data;
        if (result.length > 0) {
          this.drawChart();
        }

      } else {
        this.toastr.error(`没有查询到${this.searchDate}日的数据`);
      }
    }, err => {
      console.error(err);
      this.toastr.error(err);
    });
  }
  drawChart() {
    const yMax = _.max(this.data);
    const dataShadow = [];

    for (let i = 0; i < this.data.length; i++) {
      dataShadow.push(yMax);
    }

    this.options = {
      title: {
        text: this.searchDate + ' 日垃圾类别回收对比图'
      },
      xAxis: {
        data: this.dataAxis,
        axisLabel: {
          inside: true,
          textStyle: {
            color: '#003366'
          }
        },
        axisTick: {
          show: false
        },
        axisLine: {
          show: false
        },
        z: 10
      },
      yAxis: {
        axisLine: {
          show: false
        },
        axisTick: {
          show: false
        },
        axisLabel: {
          textStyle: {
            color: '#999'
          }
        }
      },
      dataZoom: [
        {
          type: 'inside'
        }
      ],
      series: [
        { // For shadow
          type: 'bar',
          itemStyle: {
            normal: { color: 'rgba(0,0,0,0.05)' }
          },
          barGap: '-100%',
          barCategoryGap: '40%',
          data: dataShadow,
          animation: false
        },
        {
          type: 'bar',
          itemStyle: {
            normal: {
              color: new graphic.LinearGradient(
                0, 0, 0, 1,
                [
                  { offset: 0, color: '#83bff6' },
                  { offset: 0.5, color: '#188df0' },
                  { offset: 1, color: '#188df0' }
                ]
              )
            },
            emphasis: {
              color: new graphic.LinearGradient(
                0, 0, 0, 1,
                [
                  { offset: 0, color: '#2378f7' },
                  { offset: 0.7, color: '#2378f7' },
                  { offset: 1, color: '#83bff6' }
                ]
              )
            }
          },
          data: this.data
        }
      ]
    };
  }
}
