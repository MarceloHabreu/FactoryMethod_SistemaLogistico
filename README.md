# 🚛 Sistema de Logística — SOLID + Factory Method em C#

Aplicação prática desenvolvida em C# com foco na **refatoração de código** aplicando os cinco princípios **SOLID** e o padrão criacional **Factory Method**. O projeto simula um sistema de logística que gerencia diferentes modalidades de transporte — Caminhão, Avião e Navio — com cálculo de frete e processamento de pedidos de entrega.

---

## 📋 Sobre o Projeto

Este projeto foi desenvolvido como parte de uma disciplina de **Padrões de Projeto de Software**, com o objetivo de demonstrar na prática como a aplicação dos princípios SOLID e do padrão Factory Method transforma um código desorganizado em uma arquitetura limpa, extensível e de fácil manutenção.

---

## 🏗️ Arquitetura

```
SistemaLogistica/
│
├── ITransporte.cs            # Interface — contrato de qualquer transporte
├── Caminhao.cs               # Implementação: transporte terrestre
├── Aviao.cs                  # Implementação: transporte aéreo
├── Navio.cs                  # Implementação: transporte marítimo
├── TipoTransporteEnum.cs     # Enum dos tipos disponíveis
├── TransporteFactory.cs      # Factory Method — cria os objetos de transporte
├── PedidoEntrega.cs          # Modelo de dados de um pedido
├── ServicoLogistica.cs       # Serviço que processa os pedidos
└── Program.cs                # Ponto de entrada — demonstração do sistema
```

> No repositório, todos os componentes estão reunidos no arquivo `Logistica.cs` para facilidade de execução.

---

## ✅ Princípios SOLID Aplicados

| Princípio | Como foi aplicado |
|-----------|------------------|
| **S** — Single Responsibility | Cada classe tem uma única responsabilidade: `PedidoEntrega` só armazena dados; `TransporteFactory` só cria objetos; `ServicoLogistica` só processa pedidos |
| **O** — Open/Closed | Adicionar um novo tipo de transporte (ex: Drone) exige apenas criar uma nova classe, sem modificar nenhuma existente |
| **L** — Liskov Substitution | `ServicoLogistica` usa `ITransporte` — qualquer implementação pode substituir outra sem quebrar o sistema |
| **I** — Interface Segregation | `ITransporte` contém apenas os métodos comuns a todos os transportes, sem forçar implementações desnecessárias |
| **D** — Dependency Inversion | `ServicoLogistica` depende da abstração `ITransporte`, nunca das classes concretas |

---

## 🏭 Factory Method

A classe `TransporteFactory` encapsula toda a lógica de criação de objetos:

```csharp
ITransporte transporte = TransporteFactory.CriarTransporte(TipoTransporteEnum.Aviao);
transporte.RealizarEntrega("São Paulo", "Manaus");
```

O código cliente **nunca usa `new` diretamente** para instanciar transportes — a fábrica é o único ponto de criação, garantindo desacoplamento total.

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)

### Passos

```bash
# 1. Clone o repositório
git clone https://github.com/seu-usuario/logistica-solid-factory.git

# 2. Acesse a pasta do projeto
cd logistica-solid-factory

# 3. Execute
dotnet run
```

### Saída esperada

```
==============================================
   SISTEMA DE LOGÍSTICA — SOLID + Factory    
==============================================

PEDIDO #1001
► Transporte selecionado: Caminhão
► Frete calculado: R$ 1.585,00
[CAMINHÃO] Saindo de São Paulo/SP com destino a Belo Horizonte/MG.
  → Rota terrestre calculada. Estimativa: 2 dias.

...

COMPARATIVO DE FRETES
  Caminhão     → R$ 2.550,00
  Avião        → R$ 8.250,00
  Navio        → R$ 825,00
```

---

## 🛠️ Tecnologias

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

---

## 📚 Referências

- GAMMA, E. et al. *Padrões de Projeto*. Bookman, 2000.
- MARTIN, Robert C. *Arquitetura Limpa*. Alta Books, 2019.
- [Documentação oficial C# — Microsoft](https://docs.microsoft.com/pt-br/dotnet/csharp/)

---

## 👤 Autor Marcelo Henrique Abreu Silva

Feito como projeto TDE para a disciplina de Padrões de Projeto de Software.
