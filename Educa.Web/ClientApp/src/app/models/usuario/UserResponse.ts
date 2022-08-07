
export class UserResponse {
  constructor(
    public id: number,
    public nome: string,
    public sobrenome: string,
    public email: string,
    public dataNascimento: string,
    public escolaridadeId: string,
    public historicoEscolarId: string,
  ) { }

}
