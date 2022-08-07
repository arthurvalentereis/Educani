import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MustMatch } from 'src/app/helpers/must-match/must-match.validator';
import { NewUserRequest } from 'src/app/models/usuario/NewUserRequest';
import { UpdateUserRequest } from 'src/app/models/usuario/UpdateUserRequest';
import { Usuario } from 'src/app/models/usuario/Usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-add-edit-usuario',
  templateUrl: './add-edit-usuario.component.html',
  styleUrls: ['./add-edit-usuario.component.scss']
})
export class AddEditUsuarioComponent implements OnInit {
  form!: FormGroup;
  id!: number;
  isAddMode!: boolean;
  loading = false;
  submitted = false;
  newUser!: NewUserRequest;
  user!: UpdateUserRequest;

  public historicoEscolar: any;


  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private usuarioService: UsuarioService,
    private spinnerService: NgxSpinnerService,
    private snackBar: MatSnackBar,
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    this.form = this.formBuilder.group({
      id: ['', this.isAddMode ? Validators.nullValidator : Validators.required],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      dataNascimento: ['', Validators.required],
      escolaridadeId: ['', Validators.required],
      historicoEscolar: [''],
      historicoEscolarId: [''],
    });

    if (!this.isAddMode) {
      this.spinnerService.show(undefined, {
        color: 'rgb(255,153,0)',
        size: 'large',
        bdColor: 'rgba(255,255,255, .8)'
      });
      this.usuarioService.getUsuarioById(this.id)
        .subscribe((usuario: Usuario) => {
          this.form.patchValue(usuario);
          this.spinnerService.hide();
        }
        );
    }
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;


    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    if (this.isAddMode) {
      this.createUser();
    } else {
      this.updateUser();
    }
  }

  private createUser() {
    this.newUser = new NewUserRequest(
      this.form.get('nome')?.value,
      this.form.get('sobrenome')?.value,
      this.form.get('email')?.value,
      this.form.get('dataNascimento')?.value,
      this.form.get('escolaridadeId')?.value,
      this.historicoEscolar
    );

    this.usuarioService.createUsuario(this.newUser)
      .subscribe({
        next: () => {
          this.router.navigate(['../'], { relativeTo: this.route });
          this.spinnerService.hide();
        },
        error: (error: HttpErrorResponse) => {
          this.spinnerService.hide();
          this.loading = false;
        }
      });
  }

  private updateUser() {
    this.user = new UpdateUserRequest(
      this.form.get('id')?.value,
      this.form.get('nome')?.value,
      this.form.get('sobrenome')?.value,
      this.form.get('email')?.value,
      this.form.get('dataNascimento')?.value,
      this.form.get('escolaridadeId')?.value,
      this.form.get('historicoEscolarId')?.value,
    );
    console.log(this.user);
    this.usuarioService.editUsuario(this.user)
      .subscribe({
        next: () => {
          this.router.navigate(['../../'], { relativeTo: this.route });
          this.spinnerService.hide();
        },
        error: (error: HttpErrorResponse) => {
          this.spinnerService.hide();
          this.loading = false;
        }
      });
  }

  onFileAntigoChange(file: any) {
    let extensionAllowed = { "pdf": true, "docx": true };

    if (file.target.files[0].size / 1024 / 1024 > 20) {
      alert("File size should be less than 20MB")
      return;
    }

    if ((extensionAllowed)) {
      var nam = file.target.files[0].name.split('.').pop();
      if (!extensionAllowed.hasOwnProperty(nam)) {
        alert("Please upload " + Object.keys(extensionAllowed) + " file.")
        return;
      }
    }
    this.historicoEscolar = file.target.files[0];

    // console.log('file', this.form.controls["historicoEscolarFile"]);
  }
}
