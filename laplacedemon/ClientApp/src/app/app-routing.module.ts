import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from './components/counter/counter.component';
import { FetchDataComponent } from './components/fetch-data/fetch-data.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
    { path: '', component: LoginComponent, pathMatch: 'full' },
    { path: 'counter', component: CounterComponent },
    { path: 'fetch-data', component: FetchDataComponent },
]

@NgModule({
    imports: [RouterModule.forRoot(routes,{
      scrollPositionRestoration: 'enabled',
    })],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }