import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GarbageCollectionService } from '../../services/garbage-collection.service';
import { ToastrService } from 'ngx-toastr';

declare const require: any;

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.scss']
})
export class PieChartComponent implements OnInit {
  options: any;
  chartData: any;
  searchDate: any;
  echartsInstance: any;

  constructor(private activatedRoute: ActivatedRoute,
    private garbageServices: GarbageCollectionService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe(queryParams => {
      this.searchDate = queryParams.searchDate;
    }, err => {
      this.toastr.error('error');
    });

    this.getAllHistograms(this.searchDate);
  }

  onChartInit(e: any) {
    this.echartsInstance = e;
    console.log('on chart init:', e);
  }

  clear() {
    if (this.echartsInstance) {
      this.echartsInstance.clear();
      console.log('clear() called');
    }
  }
  getAllHistograms(createdTime: string) {
    this.garbageServices.getAllHistograms(createdTime).subscribe((result: any) => {
      if (result.length !== 0) {
        this.chartData = result.map(res => {
          return { value : res.qty, name: res.categoryName };
        });
console.log(this.chartData);

        if (this.chartData.length > 0) {
          this.drawChart(this.chartData );
        }

      } else {
        this.toastr.error(`没有查询到${this.searchDate}日的数据`);
      }
    }, err => {
      console.error(err);
      this.toastr.error(err);
    });
  }
  drawChart(chartData: any) {
    this.options = {
      backgroundColor: '#2c343c',

      title: {
        text: '回收分类',
        left: 'center',
        top: 20,
        textStyle: {
          color: '#ccc'
        }
      },

      tooltip: {
        trigger: 'item',
        formatter: '{a} <br/>{b} : {c} ({d}%)'
      },

      visualMap: {
        show: false,
        min: 80,
        max: 600,
        inRange: {
          colorLightness: [0, 1]
        }
      },
      series: [
        {
          name: '数量',
          type: 'pie',
          radius: '55%',
          center: ['50%', '50%'],
          data: chartData.sort(function (a, b) { return a.value - b.value; }),
          roseType: 'radius',
          label: {
            normal: {
              textStyle: {
                color: 'rgba(255, 255, 255, 0.3)'
              }
            }
          },
          labelLine: {
            normal: {
              lineStyle: {
                color: 'rgba(255, 255, 255, 0.3)'
              },
              smooth: 0.2,
              length: 10,
              length2: 20
            }
          },
          itemStyle: {
            normal: {
              color: '#c23531',
              shadowBlur: 200,
              shadowColor: 'rgba(0, 0, 0, 0.5)'
            }
          },

          animationType: 'scale',
          animationEasing: 'elasticOut',
          animationDelay: function (idx) {
            return Math.random() * 200;
          }
        }
      ]
    };
  }
}
