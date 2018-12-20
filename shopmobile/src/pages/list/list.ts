import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-list',
  templateUrl: 'list.html'
})
export class ListPage {

  private histories: History[];

  constructor(public navCtrl: NavController, public http: HttpClient) {
    this.refreshPage();
  }

  // DeleteOrderHistory(history) {  history.Id
  DeleteOrderHistory(historyId: string) {
    var url = "http://localhost:5000/api/Order/" + historyId;
    this.http.delete(url).subscribe(
      it => {
        this.refreshPage();
      });
  }

  UpdateOrderHistory(historyId: string) {
    var url = "http://localhost:5000/api/Order/" + historyId;
    this.http.put(url,
    {
        name: "123456789",
    }).subscribe(
      it => {
        this.refreshPage();
      });
  }

  refreshPage(){
    this.http.get<History[]>("http://localhost:5000/api/Order").subscribe(
      it => {
        this.histories = it;
      });
  }
}
