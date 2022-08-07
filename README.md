# Educani

## Objetivo
Projeto destinado apenas para avaliação de empresa.

## Setup 

- 1. Modifique a connectionstring no Appsettings.Development. 
- 2. Após modificar utilize o comando `Update-database` para atualizar sua base de dados.

### Observações
- Os uploads de arquivo serão salvos na  `"C:\\HistoricoEscolar\\"`

````json
{
  "ConnectionStrings": {
    "Educani": "Data Source=localhost\\sqlexpress;Initial Catalog=Educani;Integrated Security=true;Connect Timeout=1440;TrustServerCertificate=True"
  },
  "Ambiente": {
    "CaminhoArquivosHistoricoEscolar": "C:\\HistoricoEscolar\\"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}

````

# Lets test ❤️‍🔥🚀