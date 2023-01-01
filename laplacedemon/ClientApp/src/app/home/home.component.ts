import { Component, OnInit } from '@angular/core';
import { HomeService } from 'src/app/services/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  /**
   *
   */
  constructor(private homeService:HomeService) {}
  posts:any;
  ngOnInit() {
    this.getPosts();
  }

  getPosts(){
    this.homeService.getPosts().subscribe((response:any) => {
      this.posts = response.data
      debugger;
    },error => {

    }, ()=>{})
  }
}
