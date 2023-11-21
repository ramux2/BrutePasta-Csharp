import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AutenticationService } from './shared/autentication.service';
import { Router } from '@angular/router';
import ValidateForm from '../shared/validationForm';
import { UserService } from '../user/shared/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private loginService: AutenticationService, private route: Router, private userStore: UserService) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  login() {
    if (this.loginForm.valid) {
      console.log('Autenticado com sucesso', this.loginForm.value);
      const clientObj : any = this.loginForm.value;

      this.loginService.autenticate(clientObj).subscribe((response) => {
        this.loginForm.reset();
        console.log("Token do response", response.token)
        this.loginService.storeToken(response.token);
        console.log("Token descriptado", this.loginService.decodedToken());
        const tokenPayload = this.loginService.decodedToken();
        this.userStore.setEmailForStore(tokenPayload.unique_name);
        console.log("Email:", tokenPayload.unique_name)
        this.route.navigate(['Products']);
      })
    } else {
      ValidateForm.validateAllFormFields(this.loginForm);
    }
  }
}
