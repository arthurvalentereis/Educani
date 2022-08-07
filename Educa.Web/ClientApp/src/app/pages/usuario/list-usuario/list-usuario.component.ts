import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, SecurityContext } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Escolaridade } from 'src/app/models/enum/enum.escolaridade';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-list-usuario',
  templateUrl: './list-usuario.component.html',
  styleUrls: ['./list-usuario.component.scss'],
  providers: [UsuarioService]
})
export class UsuarioComponent implements OnInit {
  usuarios: any = null;

  constructor(
    private usuarioService: UsuarioService,
    private sanitizer: DomSanitizer,
  ) { }

  ngOnInit(): void {

    this.usuarioService.getUsers()
      .subscribe((users: any) => {
        this.usuarios = users;
      });
  }

  deleteUser(id: string) {

    const user = this.usuarios.find((x: { id: string; }) => x.id === id);
    user.isDeleting = true;
    this.usuarioService.deleteUsuario(id)
      .subscribe(() => {
        this.usuarios = this.usuarios.filter((x: { id: string; }) => x.id !== id);
      });
  }

  obterNomeEscolaridade(id: number) {
    return Escolaridade.get(id);
  }

  baixarHistorico(id: number) {
    this.usuarioService.downloadHistoricoEscolar(id).subscribe({
      next: (result) => {
        this.download(result);
      },
      error: (e: HttpErrorResponse) => {
        console.log(e);
      },
    });
  }

  download(data: any) {
    const a = document.createElement('a');
    const urlArquivo = URL.createObjectURL(data);
    console.log(data);
    this.sanitizer.sanitize(SecurityContext.URL, urlArquivo);
    a.setAttribute('href', urlArquivo);
    a.setAttribute('download', 'file');
    a.click();
  }
}
