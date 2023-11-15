import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from './shared/register.service';
import { Router } from '@angular/router';
import ValidateForm from '../shared/validationForm';
import { Client } from '../shared/client.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private registerService: RegisterService, private route: Router) {}

  ngOnInit(): void {
      this.registerForm = this.formBuilder.group({
        name: ['', Validators.required],
        email: ['', Validators.required],
        cpf: ['', Validators.required],
        password: ['', Validators.required],
        phoneNumber: ['', Validators.required]
      })
  }

  register() {
    if (this.registerForm.valid) {
      console.log('Registrado com sucesso', this.registerForm.value)
      const clientObj : Client = this.registerForm.value
      
      this.registerService.signUp(clientObj).subscribe((response) =>{
        console.log(response);
        this.registerForm.reset();
        this.route.navigate(['Login']);
      })
    } else {
      ValidateForm.validateAllFormFields(this.registerForm);
    }
  }
}
