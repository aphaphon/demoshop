import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../models/product';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  private products: Product[];
  private ProductOrderId: string;
  private ProductOrderAmount: number;

  constructor(public navCtrl: NavController, public http: HttpClient) {
    this.http.get<Product[]>("http://localhost:5000/api/Product").subscribe(
      it => {
        console.log(it);
        this.products = it;
      });
  }

  OrderProduct(){
    this.http.post("http://localhost:5000/api/Order",
    {
        Id: this.ProductOrderId,
        Amount: this.ProductOrderAmount
    }).subscribe(
        it => {
        // SUCCESS: Do something
        console.log('success')
        }, 
        error => {
            // ERROR: Do something
            console.log("fail")
        });
  }

}
