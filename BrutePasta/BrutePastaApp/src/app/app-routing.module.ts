import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetProductComponent } from './components/get-product/get-product.component';
import { ProductComponent } from './components/product/product.component';

const routes: Routes = [
	{
		path: 'Products',
		component: GetProductComponent
	},
	{
		path: 'Product',
		component: ProductComponent
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
  	exports: [RouterModule]
})
export class AppRoutingModule { }
