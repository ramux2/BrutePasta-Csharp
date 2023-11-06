import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './components/products/product/product.component';
import { GetProductsComponent } from './components/products/get-products/get-products.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { CartComponent } from './components/cart/cart.component';

const routes: Routes = [
	{
		path: '',
		redirectTo: 'Home',
		pathMatch: 'full'
	},
	{
		path: 'Home',
		component: HomeComponent
	},
	{
		path: 'Login',
		component: LoginComponent
	},
	{
		path: 'Register',
		component: RegisterComponent
	},
	{
		path: 'Product',
		component: ProductComponent
	},
	{
		path: 'Products',
		component: GetProductsComponent
	},
	{
		path: 'Cart',
		component: CartComponent
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
  	exports: [RouterModule]
})
export class AppRoutingModule { }
