import { Component, OnInit } from '@angular/core';
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
}
