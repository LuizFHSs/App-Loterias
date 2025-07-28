using Loteria.Classes;
using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Loteria
{
    public partial class Form1 : Form
    {
        private readonly Loterias loterias = new();

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(0, 79, 159), // Cor inicial
                Color.FromArgb(0, 151, 215),    // Cor final
                90f))                  // Ângulo do gradiente
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Reduz flicker
            lblTimeCoracao.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaLoterias();
        }

        public async void CarregaLoterias()
        {
            await loterias.GetListLoteriasAsync();

            if (loterias.Modalidade != null)
            {
                foreach (var loteria in loterias.Modalidade)
                {
                    cbxLoterias.Items.Add(loteria);
                }
            }
            else
            {
                MessageBox.Show("Não foi possível carregar a lista de loterias.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxLoterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObterResultadoLoteria();
            textBox1.Clear();
            lblPontos.Text = "AGUARDANDO JOGO";
            lblAcertos.Text = "AGUARDANDO JOGO";
        }

        public async void ObterResultadoLoteria()
        {
            string selectedLoteria = cbxLoterias.SelectedItem.ToString();

            switch (selectedLoteria)
            {
                case "Mega-Sena":
                    lblTimeCoracao.Visible = false;
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    tabControl1.TabPages.Clear();

                    var megasena = await loterias.GetResultAsync<Megasena>("megasena");
                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {megasena.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{megasena.numero}";
                    lblDezenas.Text = $"Dezenas:\n\n{string.Join(" ", megasena.listaDezenas)}";
                    if (megasena.acumulado && megasena.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "6 acertos")?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else
                    {
                        lblAcumulou.Text = $"{megasena.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "6 acertos")?.numeroDeGanhadores} ganhadores";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {megasena.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {megasena.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {megasena.numeroConcursoProximo}";

                    foreach (var item in megasena.listaRateioPremio)
                    {
                        tabControl1.TabPages.Add(item.descricaoFaixa);
                    }

                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        var premio = megasena.listaRateioPremio.FirstOrDefault(p => p.descricaoFaixa == tab.Text);
                        string ganhadoresMega = "";

                        if (premio != null)
                        {
                            if (premio.numeroDeGanhadores == 0)
                            {
                                ganhadoresMega = "Não houve ganhadores";
                            }
                            else
                            {
                                ganhadoresMega = $"{premio.numeroDeGanhadores} ganhadores";
                            }

                            var label = new Label
                            {
                                Text = $"{ganhadoresMega}\n\nPremiação: {premio.valorPremio:C}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tab.Controls.Add(label);
                        }
                    }
                    CarregarJogosNoListView();
                    break;
                case "Quina":
                    lblTimeCoracao.Visible = false;
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    tabControl1.TabPages.Clear();

                    var quina = await loterias.GetResultAsync<Quina>("quina");
                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {quina.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{quina.numero}";
                    lblDezenas.Text = $"Dezenas:\n\n{string.Join(" ", quina.listaDezenas)}";
                    if (quina.acumulado && quina.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "5 acertos")?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else
                    {
                        lblAcumulou.Text = $"{quina.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "5 acertos")?.numeroDeGanhadores} ganhadores";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {quina.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {quina.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {quina.numeroConcursoProximo}";

                    foreach (var item in quina.listaRateioPremio)
                    {
                        tabControl1.TabPages.Add(item.descricaoFaixa);
                    }

                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        var premio = quina.listaRateioPremio.FirstOrDefault(p => p.descricaoFaixa == tab.Text);
                        string ganhadoresQuina = "";

                        if (premio != null)
                        {
                            if (premio.numeroDeGanhadores == 0)
                            {
                                ganhadoresQuina = "Não houve ganhadores";
                            }
                            else
                            {
                                ganhadoresQuina = $"{premio.numeroDeGanhadores} ganhadores";
                            }

                            var label = new Label
                            {
                                Text = $"{ganhadoresQuina}\n\nPremiação: {premio.valorPremio:C}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tab.Controls.Add(label);
                        }
                    }
                    CarregarJogosNoListView();
                    break;
                case "Lotofácil":
                    lblTimeCoracao.Visible = false;
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    tabControl1.TabPages.Clear();

                    var lotofacil = await loterias.GetResultAsync<Lotofacil>("lotofacil");
                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {lotofacil.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{lotofacil.numero}";
                    lblDezenas.Text = $"Dezenas:\n{string.Join(" ", lotofacil.listaDezenas.Take(5))}\n{string.Join(" ", lotofacil.listaDezenas.Skip(5).Take(5))}\n{string.Join(" ", lotofacil.listaDezenas.Skip(10).Take(10))}";
                    if (lotofacil.acumulado && lotofacil.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "15 acertos")?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else
                    {
                        lblAcumulou.Text = $"{lotofacil.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "15 acertos")?.numeroDeGanhadores} ganhadores";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {lotofacil.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {lotofacil.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {lotofacil.numeroConcursoProximo}";

                    foreach (var item in lotofacil.listaRateioPremio)
                    {
                        tabControl1.TabPages.Add(item.descricaoFaixa);
                    }

                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        var premio = lotofacil.listaRateioPremio.FirstOrDefault(p => p.descricaoFaixa == tab.Text);
                        string ganhadoresLoto = "";

                        if (premio != null)
                        {
                            if (premio.numeroDeGanhadores == 0)
                            {
                                ganhadoresLoto = "Não houve ganhadores";
                            }
                            else
                            {
                                ganhadoresLoto = $"{premio.numeroDeGanhadores} ganhadores";
                            }

                            var label = new Label
                            {
                                Text = $"{ganhadoresLoto}\n\nPremiação: {premio.valorPremio:C}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tab.Controls.Add(label);
                        }
                    }
                    CarregarJogosNoListView();
                    break;
                case "Dupla Sena":
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    lblTimeCoracao.Visible = false;
                    tabControl1.TabPages.Clear();

                    var duplasena = await loterias.GetResultAsync<Duplasena>("duplasena");

                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {duplasena.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{duplasena.numero}";
                    lblDezenas.Text = $"Dezenas:\n1° Sorteio: {string.Join(" ", duplasena.listaDezenas)}\n2° Sorteio: {string.Join(" ", duplasena.listaDezenasSegundoSorteio)}";

                    if (duplasena.acumulado && (duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 1)?.numeroDeGanhadores == 0) && duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 5)?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else if (duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 1)?.numeroDeGanhadores > 0 && duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 5)?.numeroDeGanhadores > 0)
                    {
                        lblAcumulou.Text = $"{duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 1)} ganhadores no 1° Sorteio\n{duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 5)?.numeroDeGanhadores} ganhadores no 2° Sorteio";
                    }
                    else if (duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 1)?.numeroDeGanhadores > 0 && duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 5)?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = $" {duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 1)?.numeroDeGanhadores} ganhadores no 1° Sorteio\nNão houve ganhadores no 2° Sorteio";
                    }
                    else
                    {
                        lblAcumulou.Text = $"Não houve ganhadores no 1° Sorteio\n{duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == 5)?.numeroDeGanhadores} ganhadores no 2° Sorteio";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {duplasena.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {duplasena.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {duplasena.numeroConcursoProximo}";

                    Dictionary<int, string> descricao = new Dictionary<int, string>();
                    string ganhadoresDupla = "";

                    foreach (var item in duplasena.listaRateioPremio)
                    {
                        descricao.Add(item.faixa, item.descricaoFaixa);
                    }

                    for (int i = 1; i < 5; i++)
                    {
                        tabControl1.TabPages.Add($"{descricao.GetValueOrDefault(i)} 1° Sorteio");
                        if (duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == i)?.numeroDeGanhadores == 0)
                        {
                            ganhadoresDupla = "Não houve ganhadores";
                        }
                        else
                        {
                            ganhadoresDupla = $"{duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == i)?.numeroDeGanhadores} ganhadores";
                        }

                        var label = new Label
                        {
                            Text = $"{ganhadoresDupla}\n\nPremiação: {duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == i)?.valorPremio:C}",
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        tabControl1.TabPages[i - 1].Controls.Add(label);
                    }

                    for (int i = 5; i < 9; i++)
                    {
                        tabControl1.TabPages.Add($"{descricao.GetValueOrDefault(i)} 2° Sorteio");
                        if (duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == i)?.numeroDeGanhadores == 0)
                        {
                            ganhadoresDupla = "Não houve ganhadores";
                        }
                        else
                        {
                            ganhadoresDupla = $"{duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == i)?.numeroDeGanhadores} ganhadores";
                        }

                        var label = new Label
                        {
                            Text = $"{ganhadoresDupla}\n\nPremiação: {duplasena.listaRateioPremio?.FirstOrDefault(p => p.faixa == i)?.valorPremio:C}",
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        tabControl1.TabPages[i - 1].Controls.Add(label);
                    }
                    CarregarJogosNoListView();
                    break;
                case "Lotomania":
                    lblTimeCoracao.Visible = false;
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    tabControl1.TabPages.Clear();

                    var lotomania = await loterias.GetResultAsync<Lotomania>("lotomania");
                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {lotomania.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{lotomania.numero}";
                    lblDezenas.Text = $"Dezenas:\n{string.Join(" ", lotomania.listaDezenas.Take(5))}\n{string.Join(" ", lotomania.listaDezenas.Skip(5).Take(5))}\n{string.Join(" ", lotomania.listaDezenas.Skip(10).Take(5))}\n{string.Join(" ", lotomania.listaDezenas.Skip(15).Take(5))}";
                    if (lotomania.acumulado && lotomania.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "20 acertos")?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else
                    {
                        lblAcumulou.Text = $"{lotomania.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "20 acertos")?.numeroDeGanhadores} ganhadores";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {lotomania.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {lotomania.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {lotomania.numeroConcursoProximo}";

                    foreach (var item in lotomania.listaRateioPremio)
                    {
                        tabControl1.TabPages.Add(item.descricaoFaixa);
                    }

                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        var premio = lotomania.listaRateioPremio.FirstOrDefault(p => p.descricaoFaixa == tab.Text);
                        string ganhadoresLotomania = "";

                        if (premio != null)
                        {
                            if (premio.numeroDeGanhadores == 0)
                            {
                                ganhadoresLotomania = "Não houve ganhadores";
                            }
                            else
                            {
                                ganhadoresLotomania = $"{premio.numeroDeGanhadores} ganhadores";
                            }

                            var label = new Label
                            {
                                Text = $"{ganhadoresLotomania}\n\nPremiação: {premio.valorPremio:C}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tab.Controls.Add(label);
                        }
                    }
                    CarregarJogosNoListView();
                    break;
                case "Timemania":
                    tabControl1.TabPages.Clear();
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    lblTimeCoracao.Visible = true;

                    var timemania = await loterias.GetResultAsync<Timemania>("timemania");

                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {timemania.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{timemania.numero}";
                    lblDezenas.Text = $"Dezenas:\n\n{string.Join(" ", timemania.listaDezenas)}";
                    lblTimeCoracao.Text = $"Time do Coração: {Regex.Replace(timemania.nomeTimeCoracaoMesSorte, @"\s+", " ")}";
                    if (timemania.acumulado && timemania.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "7 acertos")?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else
                    {
                        lblAcumulou.Text = $"{timemania.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "7 acertos")?.numeroDeGanhadores} ganhadores";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {timemania.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {timemania.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {timemania.numeroConcursoProximo}";


                    foreach (var item in timemania.listaRateioPremio)
                    {
                        if (item.descricaoFaixa != "Time do Coração")
                        {
                            tabControl1.TabPages.Add(item.descricaoFaixa);
                        }
                    }

                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        var premio = timemania.listaRateioPremio.FirstOrDefault(p => p.descricaoFaixa == tab.Text);
                        string ganhadoresTime = "";

                        if (premio != null)
                        {
                            if (premio.numeroDeGanhadores == 0)
                            {
                                ganhadoresTime = "Não houve ganhadores";
                            }
                            else
                            {
                                ganhadoresTime = $"{premio.numeroDeGanhadores} ganhadores";
                            }

                            var label = new Label
                            {
                                Text = $"{ganhadoresTime}\n\nPremiação: {premio.valorPremio:C}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tab.Controls.Add(label);
                        }
                    }
                    CarregarJogosNoListView();
                    break;
                case "Federal":
                    tabControl1.TabPages.Clear();
                    lblTimeCoracao.Visible = false;

                    var federal = await loterias.GetResultAsync<Federal>("federal");

                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {federal.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{federal.numero}";
                    lblDezenas.Text = "";

                    for (int i = 0; i < 5; i++)
                    {
                        lblDezenas.Text += $" {i + 1}° Sorteio: {federal.listaDezenas[i]}\n";
                    }

                    lblAcumulou.Visible = false;
                    lblValorEstimado.Visible = false;
                    lblDataProxConc.Visible = false;
                    lblNumProxConc.Visible = false;

                    break;
                case "Dia de Sorte":
                    lblTimeCoracao.Visible = true;
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    tabControl1.TabPages.Clear();

                    var diaDeSorte = await loterias.GetResultAsync<DiaDeSorte>("diadesorte");

                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {diaDeSorte.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{diaDeSorte.numero}";
                    lblDezenas.Text = $"Dezenas:\n\n{string.Join(" ", diaDeSorte.listaDezenas)}";
                    if (diaDeSorte.acumulado && diaDeSorte.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "7 acertos")?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else
                    {
                        lblAcumulou.Text = $"{diaDeSorte.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "7 acertos")?.numeroDeGanhadores} ganhadores";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {diaDeSorte.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {diaDeSorte.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {diaDeSorte.numeroConcursoProximo}";
                    lblTimeCoracao.Text = $"Mês da Sorte: {diaDeSorte.nomeTimeCoracaoMesSorte}";

                    foreach (var item in diaDeSorte.listaRateioPremio)
                    {
                        tabControl1.TabPages.Add(item.descricaoFaixa);
                    }

                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        var premio = diaDeSorte.listaRateioPremio.FirstOrDefault(p => p.descricaoFaixa == tab.Text);
                        string ganhadoresDia = "";

                        if (premio != null)
                        {
                            if (premio.numeroDeGanhadores == 0)
                            {
                                ganhadoresDia = "Não houve ganhadores";
                            }
                            else
                            {
                                ganhadoresDia = $"{premio.numeroDeGanhadores} ganhadores";
                            }

                            var label = new Label
                            {
                                Text = $"{ganhadoresDia}\n\nPremiação: {premio.valorPremio:C}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tab.Controls.Add(label);
                        }
                    }
                    CarregarJogosNoListView();
                    break;
                case "Super Sete":
                    lblTimeCoracao.Visible = false;
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    tabControl1.TabPages.Clear();

                    var superSete = await loterias.GetResultAsync<SuperSete>("supersete");
                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {superSete.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{superSete.numero}";
                    lblDezenas.Text = $"Dezenas:\n\n{string.Join(" ", superSete.listaDezenas)}";
                    if (superSete.acumulado && superSete.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "7 acertos")?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else
                    {
                        lblAcumulou.Text = $"{superSete.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "7 acertos")?.numeroDeGanhadores} ganhadores";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {superSete.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {superSete.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {superSete.numeroConcursoProximo}";

                    foreach (var item in superSete.listaRateioPremio)
                    {
                        tabControl1.TabPages.Add(item.descricaoFaixa);
                    }

                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        var premio = superSete.listaRateioPremio.FirstOrDefault(p => p.descricaoFaixa == tab.Text);
                        string ganhadoresSuper = "";

                        if (premio != null)
                        {
                            if (premio.numeroDeGanhadores == 0)
                            {
                                ganhadoresSuper = "Não houve ganhadores";
                            }
                            else
                            {
                                ganhadoresSuper = $"{premio.numeroDeGanhadores} ganhadores";
                            }

                            var label = new Label
                            {
                                Text = $"{ganhadoresSuper}\n\nPremiação: {premio.valorPremio:C}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tab.Controls.Add(label);
                        }
                    }
                    CarregarJogosNoListView();
                    break;
                case "+Milionária":
                    lblTimeCoracao.Visible = true;
                    lblAcumulou.Visible = true;
                    lblValorEstimado.Visible = true;
                    lblDataProxConc.Visible = true;
                    lblNumProxConc.Visible = true;
                    tabControl1.TabPages.Clear();

                    var maisMilionaria = await loterias.GetResultAsync<MaisMilionaria>("maismilionaria");
                    gpBInfoLoteria.Text = $"RESULTADOS DO DIA {maisMilionaria.dataApuracao}";
                    lblNumConcurso.Text = $"Concurso:\n{maisMilionaria.numero}";
                    lblDezenas.Text = $"Dezenas:\n\n{string.Join(" ", maisMilionaria.listaDezenas)}";
                    if (maisMilionaria.acumulado && maisMilionaria.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "6 acertos + 2 trevos")?.numeroDeGanhadores == 0)
                    {
                        lblAcumulou.Text = "Acumulou!";
                    }
                    else
                    {
                        lblAcumulou.Text = $"{maisMilionaria.listaRateioPremio?.FirstOrDefault(p => p.descricaoFaixa == "6 acertos + 2 trevos")?.numeroDeGanhadores} ganhadores";
                    }
                    lblValorEstimado.Text = $"Valor estimado do próximo concurso: {maisMilionaria.valorEstimadoProximoConcurso:C}";
                    lblDataProxConc.Text = $"Data do próximo concurso: {maisMilionaria.dataProximoConcurso}";
                    lblNumProxConc.Text = $"Próximo concurso: {maisMilionaria.numeroConcursoProximo}";
                    lblTimeCoracao.Text = $"Trevos Sorteado: {maisMilionaria.trevosSorteados[0]} e {maisMilionaria.trevosSorteados[1]}";

                    foreach (var item in maisMilionaria.listaRateioPremio)
                    {
                        tabControl1.TabPages.Add(item.descricaoFaixa);
                    }

                    foreach (TabPage tab in tabControl1.TabPages)
                    {
                        var premio = maisMilionaria.listaRateioPremio.FirstOrDefault(p => p.descricaoFaixa == tab.Text);
                        string ganhadoresSuper = "";

                        if (premio != null)
                        {
                            if (premio.numeroDeGanhadores == 0)
                            {
                                ganhadoresSuper = "Não houve ganhadores";
                            }
                            else
                            {
                                ganhadoresSuper = $"{premio.numeroDeGanhadores} ganhadores";
                            }

                            var label = new Label
                            {
                                Text = $"{ganhadoresSuper}\n\nPremiação: {premio.valorPremio:C}",
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleCenter
                            };
                            tab.Controls.Add(label);
                        }
                    }
                    CarregarJogosNoListView();
                    break;
                default:
                    MessageBox.Show($"Loteria não implementada! Selecione outra loteria!\n\nEntre em contato com LuizFHSs, caso deseje adicionar a loteria {selectedLoteria}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblAcumulou.Text = "AGUARDANDO SELEÇÃO";
                    gpBInfoLoteria.Text = "AGUARDANDO SELEÇÃO";
                    lblNumConcurso.Text = "AGUARDANDO SELEÇÃO";
                    lblDezenas.Text = "AGUARDANDO SELEÇÃO";
                    lblValorEstimado.Text = "AGUARDANDO SELEÇÃO";
                    lblDataProxConc.Text = "AGUARDANDO SELEÇÃO";
                    lblNumProxConc.Text = "AGUARDANDO SELEÇÃO";
                    tabControl1.TabPages.Clear();
                    lblTimeCoracao.Visible = false;
                    break;
            }

        }

        private void btnVerificarJogo_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && cbxLoterias.Text == "")
            {
                MessageBox.Show("Por favor, insira os números do seu jogo antes de verificar.\n\nCertifique-se de que tenha selecionado uma loteria antes de verificar seu jogo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor, insira os números do seu jogo antes de verificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (cbxLoterias.Text == "")
            {
                MessageBox.Show("Por favor, selecione uma loteria antes de verificar seu jogo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                VerificarJogo(cbxLoterias.SelectedItem.ToString());
            }
        }

        private void VerificarJogo(string loteria)
        {
            switch (loteria)
            {
                case "Lotofácil":
                    string resultadoLotofacil = lblDezenas.Text.Remove(0, 8).Replace("\n", " ").Trim();
                    string[] numerosSorteado = resultadoLotofacil.Split(" ");
                    string[] meuJogoloto = textBox1.Text.Trim().Split(" ");
                    int pontos = 0;
                    List<string> numerosAcertados = new List<string>();

                    foreach (string numero in meuJogoloto)
                    {
                        if (numerosSorteado.Contains(numero))
                        {
                            pontos++;
                            numerosAcertados.Add(numero);
                        }
                    }

                    if (pontos < 11)
                    {
                        lblPontos.Text = $"Não houve acertos para premiação! ({pontos} acertos)";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertados)}";
                    }
                    else
                    {
                        lblPontos.Text = $"Você acertou {pontos} pontos!";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertados)}";
                    }
                    break;
                case "Dupla Sena":
                    string[] resultadoDuplaSena = lblDezenas.Text.Remove(0, 21).Replace("2° Sorteio: ", " ").Split("\n");
                    string[] primeiroSorteio = resultadoDuplaSena[0].Trim().Split(" ");
                    string[] segundoSorteio = resultadoDuplaSena[1].Trim().Split(" ");
                    string[] meuJogoDupla = textBox1.Text.Trim().Split(" ");

                    int pontosDupla1 = 0;
                    int pontosDupla2 = 0;

                    List<string> numerosAcertadosDupla1 = new List<string>();
                    List<string> numerosAcertadosDupla2 = new List<string>();

                    foreach (string numero in meuJogoDupla)
                    {
                        if (primeiroSorteio.Contains(numero))
                        {
                            pontosDupla1++;
                            numerosAcertadosDupla1.Add(numero);
                        }

                        if (segundoSorteio.Contains(numero))
                        {
                            pontosDupla2++;
                            numerosAcertadosDupla2.Add(numero);
                        }

                    }

                    if (pontosDupla1 < 3 && pontosDupla2 < 3)
                    {
                        lblPontos.Text = $"Não houve acertos para premiação!\n({pontosDupla1} acertos no 1° Sorteio e {pontosDupla2} acertos no 2° Sorteio)";
                        lblAcertos.Text = $"Números acertados no 1° Sorteio: {string.Join(" ", numerosAcertadosDupla1)}\nNúmeros acertados no 2° Sorteio: {string.Join(" ", numerosAcertadosDupla1)}";
                    }
                    else
                    {
                        switch (pontosDupla1)
                        {
                            case 3:
                                lblPontos.Text = $"Parabéns! Você acertou um terno no 1° Sorteio!";
                                break;
                            case 4:
                                lblPontos.Text = $"Parabéns! Você acertou uma quadra no 1° Sorteio!";
                                break;
                            case 5:
                                lblPontos.Text = $"Parabéns! Você acertou uma quina no 1° Sorteio!";
                                break;
                            case 6:
                                lblPontos.Text = $"Parabéns! Você acertou uma sena no 1° Sorteio!";
                                break;
                            default:
                                lblPontos.Text = $"Você acertou {pontosDupla1} pontos no 1° Sorteio!";
                                break;
                        }

                        switch (pontosDupla2)
                        {
                            case 3:
                                lblPontos.Text += $"\nParabéns! Você acertou um terno no 2° Sorteio!";
                                break;
                            case 4:
                                lblPontos.Text += $"\nParabéns! Você acertou um terno no 2° Sorteio!";
                                break;
                            case 5:
                                lblPontos.Text += $"\nParabéns! Você acertou um terno no 2° Sorteio!";
                                break;
                            case 6:
                                lblPontos.Text += $"\nParabéns! Você acertou um terno no 2° Sorteio!";
                                break;
                            default:
                                lblPontos.Text += $"\nVocê acertou {pontosDupla2} pontos no 2° Sorteio!";
                                break;
                        }
                    }

                    lblAcertos.Text = $"Números acertados no 1° Sorteio: {string.Join(" ", numerosAcertadosDupla1)}\nNúmeros acertados no 2° Sorteio: {string.Join(" ", numerosAcertadosDupla2)}";

                    break;
                case "Lotomania":
                    string resultadoLotomania = lblDezenas.Text.Remove(0, 8).Replace("\n", " ").Trim();
                    string[] numerosSorteados = resultadoLotomania.Split(" ");
                    string[] meuJogoLotoMania = textBox1.Text.Trim().Split(" ");
                    int pontosLotoMania = 0;
                    List<string> numerosAcertadosLotoMania = new List<string>();
                    foreach (string numero in meuJogoLotoMania)
                    {
                        if (numerosSorteados.Contains(numero))
                        {
                            pontosLotoMania++;
                            numerosAcertadosLotoMania.Add(numero);
                        }
                    }
                    if (pontosLotoMania < 15 && pontosLotoMania != 0)
                    {
                        lblPontos.Text = $"Não houve acertos para premiação! ({pontosLotoMania} acertos)";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertadosLotoMania)}";
                    }
                    else
                    {
                        lblPontos.Text = $"Parabéns! Você fez {pontosLotoMania} acertos!";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertadosLotoMania)}";
                    }
                    break;
                default:
                    string[] jogo = textBox1.Text.Trim().Split(" ");
                    string[] resultado = lblDezenas.Text.Remove(0, 8).Trim().Split(" ");
                    int pontosGeral = 0;
                    List<string> numerosAcertadosGeral = new List<string>();

                    foreach (string numero in jogo)
                    {
                        if (resultado.Contains(numero))
                        {
                            pontosGeral++;
                            numerosAcertadosGeral.Add(numero);
                        }
                    }

                    if (pontosGeral < 2)
                    {
                        lblPontos.Text = $"Não houve acertos para premiação! ({pontosGeral} acertos)";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertadosGeral)}";
                    }
                    else if (pontosGeral == 2)
                    {
                        lblPontos.Text = $"Parabéns você acertou um duque!";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertadosGeral)}";
                    }
                    else if (pontosGeral == 3)
                    {
                        lblPontos.Text = $"Parabéns você acertou um terno!";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertadosGeral)}";
                    }
                    else if (pontosGeral == 4)
                    {
                        lblPontos.Text = $"Parabéns você acertou uma quadra!";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertadosGeral)}";
                    }
                    else if (pontosGeral == 5)
                    {
                        lblPontos.Text = $"Parabéns você acertou uma quina!";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertadosGeral)}";
                    }
                    else if (pontosGeral == 6)
                    {
                        lblPontos.Text = $"Parabéns você acertou uma sena!";
                        lblAcertos.Text = $"Números acertados: {string.Join(" ", numerosAcertadosGeral)}";
                    }
                    break;
            }
        }

        private void btnSalvarJogo_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            if (textBox1.Text == "" || cbxLoterias.SelectedItem == null)
            {
                MessageBox.Show("Por favor, insira os números do seu jogo e selecione uma loteria antes de salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CriarEsalvarArquivo();

                CarregarJogosNoListView();
            }
        }

        private void CriarEsalvarArquivo()
        {
            string pastaDoucmentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nomePasta = "Jogos LoteriaApp";
            string caminhoCompleto = Path.Combine(pastaDoucmentos, nomePasta);

            if (!Directory.Exists(caminhoCompleto))
            {
                Directory.CreateDirectory(caminhoCompleto);
            }

            string caminhoArquivo = Path.Combine(caminhoCompleto, "Jogos.json");

            var jogoAtual = textBox1.Text.Trim();
            var modalidade = cbxLoterias.SelectedItem.ToString();

            Dictionary<string, List<string>> jogosPorModalidade;

            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                jogosPorModalidade = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json) ?? new Dictionary<string, List<string>>();
            }
            else
            {
                jogosPorModalidade = new Dictionary<string, List<string>>();
            }

            if (!jogosPorModalidade.ContainsKey(modalidade))
            {
                jogosPorModalidade[modalidade] = new List<string>();
            }

            jogosPorModalidade[modalidade].Add(jogoAtual);

            var jsonFile = JsonSerializer.Serialize(jogosPorModalidade, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoArquivo, jsonFile);

            CarregarJogosNoListView();
        }

        private void CarregarJogosNoListView()
        {
            listView1.Items.Clear();

            string pastaDoucmentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nomePasta = "Jogos LoteriaApp";
            string caminhoCompleto = Path.Combine(pastaDoucmentos, nomePasta);
            string caminhoArquivo = Path.Combine(caminhoCompleto, "Jogos.json");

            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                var jogosPorModalidade = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

                if (jogosPorModalidade != null)
                {
                    foreach (var modalidade in jogosPorModalidade)
                    {
                        if (modalidade.Key == cbxLoterias.SelectedItem?.ToString())
                        {
                            foreach (var jogo in modalidade.Value)
                            {
                                listView1.Items.Add(jogo);
                            }
                        }
                    }
                }
            }
        }

        private void btnApagarJogo_Click(object sender, EventArgs e)
        {
            ApagarJogo();
        }

        private void ApagarJogo()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecione um jogo para apagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string pastaDoucmentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string nomePasta = "Jogos LoteriaApp";
                string caminhoCompleto = Path.Combine(pastaDoucmentos, nomePasta);
                string caminhoArquivo = Path.Combine(caminhoCompleto, "Jogos.json");

                if (File.Exists(caminhoArquivo))
                {
                    string json = File.ReadAllText(caminhoArquivo);
                    var jogosPorModalidade = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

                    if (jogosPorModalidade != null)
                    {
                        foreach (var modalidade in jogosPorModalidade)
                        {
                            if (modalidade.Key == cbxLoterias.SelectedItem?.ToString())
                            {
                                foreach (var jogo in modalidade.Value)
                                {
                                    if (listView1.SelectedItems.Count > 0)
                                    {
                                        jogosPorModalidade[modalidade.Key].Remove(jogo);
                                        var jsonFile = JsonSerializer.Serialize(jogosPorModalidade, new JsonSerializerOptions { WriteIndented = true });
                                        File.WriteAllText(caminhoArquivo, jsonFile);
                                        CarregarJogosNoListView();
                                    }
                                    break;
                                }
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Nenhum jogo encontrado para apagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números, espaço, backspace, Ctrl+C, Ctrl+V e Ctrl+X
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                // Permite Ctrl+C, Ctrl+V e Ctrl+X
                if (!(char.IsControl(e.KeyChar) && (e.KeyChar == 3 || e.KeyChar == 22 || e.KeyChar == 24)))
                {
                    e.Handled = true;
                }
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C && listView1.SelectedItems.Count > 0)
            {
                // Copia o texto do item selecionado (primeira coluna)
                Clipboard.SetText(listView1.SelectedItems[0].Text);
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].Text;
            }
            else
            {
                textBox1.Clear();
            }
        }
    }
}