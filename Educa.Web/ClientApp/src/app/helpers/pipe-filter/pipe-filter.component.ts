import { Input, Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: 'busca'
})

export class PipeFilterComponent implements PipeTransform {

  transform(listaBusca: any[], tipoConteudo: string, input: string | undefined) {
    if (input === "" || input === undefined) {
      return listaBusca;
    }

    var itensFiltrados: any[] = [];
    var busca = input.toLowerCase().split('');

    if (tipoConteudo === "empresa") {
      listaBusca.forEach(el => {
        var nome = el.nome.toLowerCase().split('');
        var apelido = el.apelido.toLowerCase().split('');
        var cnpj = el.cnpj.split('');
        var contemNoNome = this.contemInputBuscado(nome, busca);
        var contemNoApelido = this.contemInputBuscado(apelido, busca);
        var contemNoCnpj = this.contemInputBuscado(cnpj, busca);
        if (contemNoNome || contemNoApelido || contemNoCnpj) {
          itensFiltrados.push(el);
        }
      });
    }

    if (tipoConteudo === "tarefa") {
      listaBusca.forEach(el => {
        var nome = el.nomeEmpresa.toLowerCase().split('');
        var data = el.mesAno.toLowerCase().split('');
        var contemNoNome = this.contemInputBuscado(nome, busca);
        var contemNaData = this.contemInputBuscado(data, busca);
        if (contemNoNome || contemNaData) {
          itensFiltrados.push(el);
        }
      });
    }

    return itensFiltrados.length === 0 ? [] : itensFiltrados;
  }

  contemInputBuscado(conteudoOriginal: any[], input: any[]) {
    return input.every(char =>
      conteudoOriginal.includes(char)
      && input.filter(x => x === char).length
      <= conteudoOriginal.filter(y => y === char).length)
  }
}