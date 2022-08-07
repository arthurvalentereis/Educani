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
  private readonly downloadUrl = `${environment.apiUrl}usuario/DownloadHistoricoEscolar`;

  constructor(private httpClient: HttpClient) { }

  getUsers(): Observable<UserResponse[]> {
    return this.httpClient.get<UserResponse[]>(this.listarUsuariosUrl);
  }

  createUsuario(newUserRequest: NewUserRequest): Observable<NewUserRequest> {
    const formData = new FormData();
    formData.append('nome', newUserRequest.nome.toString());
    formData.append('sobrenome', newUserRequest.sobrenome.toString());
    formData.append('email', newUserRequest.email);
    formData.append('dataNascimento', newUserRequest.dataNascimento);
    formData.append('escolaridadeId', newUserRequest.escolaridadeId);
    formData.append('historicoEscolar', newUserRequest.historicoEscolar);

    return this.httpClient.post<NewUserRequest>(this.criarUsuarioUrl, formData);
  }

  editUsuario(userResponse: UserResponse): Observable<UserResponse> {
    console.log(userResponse);
    return this.httpClient.put<UserResponse>(this.editarUsuarioUrl, userResponse);
  }

  deleteUsuario(id: string): Observable<any> {
    return this.httpClient.delete<any>(this.deleteUsuarioUrl + '?id=' + id);
  }

  getUsuarioById(id: number): Observable<any> {
    return this.httpClient.get<any>(this.getUsuarioByIdUrl + '?id=' + id);
  }
  downloadHistoricoEscolar(id: number) {
    return this.httpClient.get(`${this.downloadUrl}/${id}`, { reportProgress: true, responseType: 'blob' });
  }
}
