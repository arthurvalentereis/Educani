export class NewUserRequest {
    constructor(
        public nome: string,
        public sobrenome: string,
        public email: string,
        public dataNascimento: string,
        public escolaridadeId: string,
        public historicoEscolar: File,
    ) { }
}
