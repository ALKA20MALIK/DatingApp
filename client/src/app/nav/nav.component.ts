import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/User';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model:any={};
  currentUser$: Observable<User>;
  userName:string;

  constructor( public accountService: AccountService) { }
  ngOnInit(): void {
    //this.currentUser$ = this.accountService.currentUser$;
  }

  login(){
    this.accountService.login(this.model)
    .subscribe(response => {
      console.log(response);
    },
    error => {
      console.log("Unauthorized",error)
    });
  }
  logout(){
    this.accountService.logout();
  }
}
