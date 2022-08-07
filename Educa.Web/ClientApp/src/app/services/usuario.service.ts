import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { NewUserRequest } from '../models/usuario/NewUserRequest';
import { UserResponse } from '../models/usuario/UserResponse';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private readonly listarUsuariosUrl = `${environment.apiUrl}usuario`;
  private readonly criarUsuarioUrl = `${environment.apiUrl}usuario/create`;
  private readonly editarUsuarioUrl = `${environment.apiUrl}usuario/update`;
  private readonly deleteUsuarioUrl = `${environment.apiUrl}usuario/remove`;
  private readonly getUsuarioByIdUrl = `${environment.apiUrl}usuario/getUserById`;
  constructor(private httpClient: HttpClient ) { }

  getUsers():Observable<UserResponse[]>{
    console.log(this.listarUsuariosUrl);
    return this.httpClient.get<UserResponse[]>(this.listarUsuariosUrl);
  }

  createUsuario(newUserRequest: NewUserRequest): Observable<NewUserRequest>{
    return this.httpClient.post<NewUserRequest>(this.criarUsuarioUrl, newUserRequest);
  }

  editUsuario(userResponse: UserResponse):Observable<UserResponse>{
    return this.httpClient.put<UserResponse>(this.editarUsuarioUrl, userResponse);
  }

  deleteUsuario(id: string): Observable<any>{
    return this.httpClient.delete<any>(this.deleteUsuarioUrl + '?id=' + id);
    }

  getUsuarioById(id: number): Observable<any>{
      return this.httpClient.get<any>(this.getUsuarioByIdUrl + '?id=' + id);
    }
}
