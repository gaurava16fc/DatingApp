import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  Values: any;
  apiBaseUrl = '';

  constructor(private http: HttpClient) {
    this.apiBaseUrl = environment.apiBaseUrl;
  }

  ngOnInit() {
    this.getValues();
  }

  getValues() {
    this.http.get(this.apiBaseUrl + 'values')
      .subscribe(response => {
        this.Values = response;
      },
      error => {
        console.log(error);
      });
  }

}
