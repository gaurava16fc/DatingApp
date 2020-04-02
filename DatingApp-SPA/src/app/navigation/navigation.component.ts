import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  model: any = {};
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login(){
    console.log(this.model);
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged-in successfully!');
    }, error => {
      console.log('Failed to Login');
    });
  }

}
