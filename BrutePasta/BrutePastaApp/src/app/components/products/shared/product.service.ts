import { HttpClient, HttpHeaders} from '@angular/common/http'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from './product.model';

const httpOptions = {
	headers: new HttpHeaders({
		'Content-Type': 'application/json'
	})
}

@Injectable({
  providedIn: 'root'
})
export class ProductService {
	private readonly APIURL = 'http://localhost:5000/Product/products'
  	constructor(private http: HttpClient) { }
	products(): Observable<Product[]> {
		return this.http.get<Product[]>(this.APIURL);
	}

	// buscar(placa: string): Observable<Product> {
	// 	const url = `${this.apiUrl}/buscar/${placa}`;
	// 	return this.http.get<Product>(url);
	// }
	
	// cadastrar(Product: Product): Observable<any> {
	// 	const url = `${this.apiUrl}/cadastrar`;
	// 	return this.http.post<Product>(url, Product, httpOptions);
	// }
	
	// atualizar(Product: Product): Observable<any> {
	// 	const url = `${this.apiUrl}/atualizar`;
	// 	return this.http.put<Product>(url, Product, httpOptions);
	// }
	
	// excluir(placa: string): Observable<any> {
	// 	const url = `${this.apiUrl}/buscar/${placa}`;
	// 	return this.http.delete<string>(url, httpOptions);
	// }
}
