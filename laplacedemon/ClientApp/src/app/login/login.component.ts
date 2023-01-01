import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AppComponent } from 'src/app/app.component';
import { FormGroup } from '@angular/forms';


const PHRASES = ['The bear marketing is coming, the reason I am saying it...',
  'Buy bitcoin right now, that is the best moment in history to...',
  'I am new here, but I think that...',
'no one will buy dodgecoin, it is useless and its price makes no sense'
,'I TOLD U ALL ABOUT FTX...']
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  text: string = "";
  message = "";
  speed = 50;
  index = 0;
  loginForm:FormGroup = new FormGroup({
    nickName: new FormControl(null, Validators.required),
    phrase1: new FormControl(null, 
      Validators.minLength(3),
      ),
    phrase2: new FormControl(null, 
      Validators.minLength(3),
      ),
    password: new FormControl(null, Validators.required)
  });

  constructor(private appComponent: AppComponent) {
    appComponent.showNavbar = false;
  }
  

  ngOnInit(): void {
    this.writer()
  }

  writer() {
    this.message = PHRASES[Math.floor(Math.random() * 6)]
    setInterval(() => {
      this.text += this.message[this.index] != undefined ? this.message[this.index] : '...' ;
      this.index++;
      if (this.index > 30) {
        this.index = 0;
        this.text = ""
        this.message = PHRASES[Math.floor(Math.random() * 5)]
      }
    }, this.speed);
  }

  login(){
    debugger;
    if(this.loginForm.valid){
      console.log(this.loginForm.value)      
    }
  }

}
