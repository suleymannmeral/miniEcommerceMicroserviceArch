import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FlexiToastService } from 'flexi-toast';
import { ResultModel } from '../../Models/result.model';
import { UserModel } from '../../Models/user.model';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterLink,FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})

export class RegisterComponent {
  
  model=signal<UserModel>(new UserModel());

  constructor(
  private http:HttpClient,
  private toast:FlexiToastService,
  private router:Router,

  ){}
  register(){
    this.http.post<ResultModel<string>>('http://localhost:5000/auth/register',this.model()).subscribe({
      next:(res)=>{
       this.toast.showToast("Successfully",res.data!,"success");
       this.router.navigateByUrl("/login");
      },
      error:(err:HttpErrorResponse)=>{
        console.log(err);
        this.toast.showToast("Error!","Something went wrong","error");
      }
    })
  }
}
