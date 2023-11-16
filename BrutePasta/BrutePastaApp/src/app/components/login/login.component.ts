import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AutenticationService } from './shared/autentication.service';
import { Router } from '@angular/router';
import ValidateForm from '../shared/validationForm';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private loginService: AutenticationService, private route: Router) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  login() {
    if (this.loginForm.valid) {
      console.log('Registrado com sucesso', this.loginForm.value);
      const clientObj : any = this.loginForm.value;

      this.loginService.autenticate(clientObj).subscribe((response) => {
        this.loginForm.reset();
        this.loginService.storeToken(response.token)
        this.route.navigate(['Products'])
      })
    } else {
      ValidateForm.validateAllFormFields(this.loginForm);
    }
  }
}
