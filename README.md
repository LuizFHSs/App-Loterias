# Aplicativo Loterias CAIXA - Aplicação Windows Forms para consulta, cadastro e verificação de jogos das principais loterias brasileiras.
## 1. Objetivo

Desenvolver um aplicativo para consulta de resultados das Loterias CAIXA, com funcionalidades adicionais para conferência e armazenamento de apostas realizadas, visando atender a necessidades reais de usuários que atualmente utilizam planilhas manuais.

## 2. Tecnologias Utilizadas

- Linguagem: C#
- Ambiente de desenvolvimento: Microsoft Visual Studio
- Consumo de API via HTTP GET
- Armazenamento de dados: arquivos JSON locais
- Componentes: ComboBox, Label, TabControl, TextBox, Botões

## 3. Fontes de Dados

- API REST pública (atualmente mantida por terceiros)
- Arquivo JSON retornado com dados de concursos e modalidades disponíveis

## 4. Visão Geral

O LoteriaApp permite ao usuário:
- Consultar resultados das loterias (Mega-Sena, Quina, Lotofácil, etc.)
- Salvar e gerenciar seus próprios jogos por modalidade
- Verificar automaticamente se um jogo foi premiado

## 5. Funcionalidades

- Consulta de Resultados: Busca automática dos resultados mais recentes de cada modalidade.
- Cadastro de Jogos: Permite salvar jogos por modalidade, armazenando em arquivo JSON.
- Verificação de Jogos: Compara o jogo salvo com o resultado do concurso e informa a premiação.
- Gerenciamento de Jogos: Listagem, exclusão e visualização dos jogos cadastrados.
- Interface Responsiva: Layout adaptável para diferentes resoluções, com gradiente de fundo e cores personalizadas.
- Suporte a Fontes Customizadas: Possibilidade de usar fontes externas no formulário.

## 6. Principais Classes e Métodos
- Form1
  -	OnPaintBackground: Desenha o gradiente de fundo do formulário.
  -	CarregaLoterias: Carrega as modalidades disponíveis no ComboBox.
  -	ObterResultadoLoteria: Busca e exibe o resultado da loteria selecionada.
  -	VerificarJogo: Compara o jogo do usuário com o resultado e exibe a premiação.
  -	CriarEsalvarArquivo: Salva o jogo do usuário em arquivo JSON, separado por modalidade.
  -	CarregarJogosNoListView: Exibe os jogos salvos no ListView conforme a modalidade selecionada.
  -	ApagarJogo: Remove o jogo selecionado do arquivo e atualiza a lista.
  -	Eventos de UI: Manipula eventos de clique, seleção e teclado para controles como TextBox e ListView.
- Loterias (em Classes\Loterias.cs)
  -	Métodos para buscar resultados das loterias via API ou fonte de dados.

## 7. Como Usar
1.	Selecione a modalidade de loteria desejada.
2.	Consulte o resultado mais recente.
3.	Digite seu jogo no campo apropriado (apenas números e espaços).
4.	Clique em "Salvar Jogo" para armazenar seu palpite.
5.	Use "Verificar Jogo" para comparar com o resultado e ver se foi premiado.
6.	Gerencie seus jogos usando o ListView (copiar, apagar, etc).

## 8. Customização Visual
- Gradiente de Fundo: Implementado em OnPaintBackground.
- Fonte e Cor: Pode ser personalizada no construtor do formulário e nos controles.
- GroupBox Customizado: Para manter o visual consistente com o gradiente do formulário, utilize um CustomGroupBox (veja exemplo na resposta anterior).

## 9. Requisitos
- .NET 8.0
- Windows Forms
- Permissões de leitura e escrita na pasta de Documentos do usuário

## 10. Observações
- Os jogos são salvos em Jogos.json na pasta Jogos LoteriaApp dentro de Documentos.
- O layout foi projetado para se manter organizado em resoluções a partir de 900x600.
- Para fontes customizadas, adicione o arquivo .ttf como recurso e carregue via PrivateFontCollection.
