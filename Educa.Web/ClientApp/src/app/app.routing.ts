import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CounterComponent } from "./pages/counter/counter.component";
import { FetchDataComponent } from "./pages/fetch-data/fetch-data.component";
import { AddEditUsuarioComponent } from "./pages/usuario/add-edit-usuario/add-edit-usuario.component";
import { HomeComponent } from "./pages/home/home.component";
import { UsuarioComponent } from "./pages/usuario/list-usuario/list-usuario.component";

//Mapeando rotas
const routes : Routes = [
  {
      path: '', component: HomeComponent,
      children: [
          // { path: '', component: HomeComponent, pathMatch: 'full' },
          { path: '', component: HomeComponent},
          { path: 'usuarios', component: UsuarioComponent},
          { path: 'usuarios/adicionar-usuario', component: AddEditUsuarioComponent},
          { path: 'usuarios/editar-usuario/:id', component: AddEditUsuarioComponent},
          { path: 'counter', component: CounterComponent },
          { path: 'fetch-data', component: FetchDataComponent },
      ]
  },
];

@NgModule({
  imports : [RouterModule.forRoot(routes)],
  exports : [RouterModule]
})

export class AppRoutingModule {}
