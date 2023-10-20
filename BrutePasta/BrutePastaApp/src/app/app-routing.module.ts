import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './components/products/product/product.component';
import { GetProductsComponent } from './components/products/get-products/get-products.component';

const routes: Routes = [
	{
		path: 'Product',
		component: ProductComponent
	},
	{
		path: 'Products',
		component: GetProductsComponent
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
  	exports: [RouterModule]
})
export class AppRoutingModule { }
