<h1 align="center">Slime Farm</h1>

<p align="center">
  <b>Clique, colete Goo e transforme um prado silencioso no ecossistema definitivo de slimes.</b>
</p>

<p align="center">
  <img alt="Status: em desenvolvimento" src="https://img.shields.io/badge/status-em%20desenvolvimento-yellow">
  <img alt="Gênero: incremental, idle, clicker" src="https://img.shields.io/badge/g%C3%AAnero-incremental%20%2F%20idle%20%2F%20clicker-brightgreen">
  <img alt="Disciplina: XDES17" src="https://img.shields.io/badge/disciplina-XDES17-blue">
</p>

<p align="center">
  <img alt="Tela principal do Slime Farm" width="720" src="https://github.com/user-attachments/assets/e7e3a22a-ebb8-4f6c-99a0-059e11ec3aeb" />
</p>

---

## Índice

- [Sobre o jogo](#sobre-o-jogo)
- [Capturas de tela](#capturas-de-tela)
- [Funcionalidades](#funcionalidades)
- [Como jogar](#como-jogar)
- [Ambientação e arte](#ambientação-e-arte)
- [História](#história)
- [Referências](#referências)
- [Tecnologias](#tecnologias)
- [Como executar](#como-executar)
- [Créditos](#créditos)
- [Equipe](#equipe)

---

## Sobre o jogo

**Slime Farm** é um jogo incremental (*idle / clicker*) em pixel art, desenvolvido como projeto final da disciplina **XDES17 – Introdução a Codificação de Jogos Digitais**.

Tudo começa com um único slime verde em um prado tranquilo. Ao clicar nele, você extrai **Goo**, a substância viva que funciona como a moeda principal do jogo. Com o Goo, você compra novos slimes (cada um com a sua própria produção de Goo por segundo), melhora seus cliques, abre mais espaço no prado e tenta a sorte com ovos raros que podem revelar slimes especiais.

O ciclo do jogo é simples:

> **Clicar → coletar Goo → comprar slimes e melhorias → produzir ainda mais Goo → repetir**

A graça está em otimizar a produção e alcançar valores cada vez maiores de Goo.

---

## Capturas de tela

<!--
  Como adicionar imagens:
  1. Crie a pasta docs/images/ e salve os prints lá.
  2. Use os mesmos nomes de arquivo abaixo ou altere o src correspondente.
  3. Para incluir mais prints, copie um bloco <td>...</td> (ou uma linha <tr>...</tr> inteira).
-->

<table>
  <tr>
    <td align="center" width="50%">
      <img alt="Loja de slimes" src="https://github.com/user-attachments/assets/16683a34-684e-4919-91d3-ab22e77d6999" />
      <br><sub><b>Loja</b> — slimes, novos slots e powerups!</sub>
    </td>
    <td align="center" width="50%">
      <img alt="Sistema de gacha com ovos raros" src="https://github.com/user-attachments/assets/949c2620-81f5-422c-8dd2-4f737bddd601" />
      <br><sub><b>Conquistas</b> — sistema de recompensas por conquistas! (em desenvolvimento)</sub>
    </td>
  </tr>
</table>

<p align="center">
  <img alt="Gameplay do Slime Farm" width="640" src="https://github.com/user-attachments/assets/dcf8d7c1-0a2f-4f18-bfa6-1393bc2385d3" />
  <br><sub><b>Gameplay</b></sub>
</p>

---

## Funcionalidades

> **Em desenvolvimento.** O jogo já é jogável: dá para clicar nos slimes, comprar na loja, expandir os slots, abrir ovos no gacha e usar power-ups. Os demais sistemas estão em construção.

| Recurso | Descrição | Status |
|---|---|---|
| **Coleta de Goo** | Clique nos slimes para produzir Goo, a moeda principal do jogo. | ✅ Funcionando |
| **Loja de slimes** | Compre diferentes tipos de slimes; cada um gera uma quantidade específica de Goo por segundo. | ✅ Pronto |
| **Slots** | Existe um limite máximo de slimes no prado. Novos slots podem ser comprados na loja. | ✅ Funcionando |
| **Gacha** | Ovos raros com chance de render slimes especiais e mais valiosos. | ✅ Funcionando |
| **Power-ups** | Melhorias que aumentam o Goo obtido por clique e automatizam os cliques (auto-clique). | ✅ Funcionando |
| **Conquistas** | Objetivos que concedem recompensas em Goo ao serem completados. | 🚧 Em construção |
| **Síntese** | Combine dois slimes para tentar criar um slime melhor. Há chance de falha e, nesse caso, os dois slimes são perdidos. | 🚧 Em construção |
| **Enciclopédia** | Catálogo com todos os slimes do jogo. Os que ainda não foram obtidos aparecem bloqueados. | 🚧 Em construção |

---

## Como jogar

1. **Clique no slime** para extrair Goo.
2. **Abra a Loja** pelo menu inferior e compre novos slimes: eles passam a produzir Goo sozinhos.
3. **Compre power-ups** para ganhar mais Goo por clique e automatizar os cliques.
4. **Acompanhe seus slots.** O contador de slimes (por exemplo, `1/10`) mostra quantos slimes você tem e quantos cabem no prado. Quando encher, compre novos slots.
5. **Abra ovos raros no gacha** na esperança de conseguir slimes especiais, que rendem mais Goo.
6. **Reinvista o Goo** e repita para crescer cada vez mais.

### Interface

O jogo acontece em uma única tela fixa, como no Cookie Clicker, para que tudo fique a poucos cliques de distância.

| Região | O que você encontra |
|---|---|
| **Centro** | Os slimes sobre o chão, que são o alvo principal dos cliques. A grama ao redor é onde os novos slimes (comprados ou sorteados) aparecem. |
| **Canto superior esquerdo** | Quantidade de Goo acumulada e contador de slimes (ex.: `1/10`). |
| **Canto superior direito** | Botões rápidos de configuração, como áudio e fechar/sair. |
| **Barra inferior** | Menu fixo com ícones redondos: **Loja**, **Enciclopédia**, **Síntese** e **Conquistas**. |

---

## Ambientação e arte

- **Estilo:** pixel art clássico, em visão lateral.
- **Cenário:** um campo ensolarado ao ar livre, com montanhas verdes sutis ao fundo e um céu azul-claro com nuvens estilizadas em tons de roxo e azul-escuro.
- **Chão:** camada de grama verde vibrante sobre terra/rocha em tom marrom.
- **Atmosfera:** simples, leve e direta. O foco está sempre no slime sobre a grama.

---

## História

O Slime Farm não tem uma narrativa dramática nem personagens com diálogos: a história é contada de forma ambiental e contemplativa.

Em um mundo pacífico e isolado, o **Goo** é a fonte fundamental de energia e matéria. O universo começa silencioso, habitado apenas por um slime verde solitário em um prado tranquilo. À medida que o jogador interage e extrai Goo, ele dispara uma reação em cadeia de evolução biológica.

Essa evolução é revelada pela **Enciclopédia de Slimes**: cada espécie descoberta, cada ovo chocado no gacha e cada síntese realizada desvenda mais um pedaço do catálogo evolutivo dessas criaturas, até que aquele pequeno gramado se torne o ecossistema definitivo de slimes.

---

## Referências

- **[Cookie Clicker](https://orteil.dashnet.org/cookieclicker/)**: referência do ciclo central dos jogos incrementais. Clica-se para produzir, gasta-se para comprar estruturas que produzem sozinhas e melhorias que as tornam mais eficientes, e há conquistas para desbloquear.
- **[The MachinEGG](https://quantumgames-studio.itch.io/the-machinegg)**: jogo incremental de fazenda e automação, em que uma pequena criação de galinhas vira uma linha de produção de ovos. Referência de progressão visual: o avanço aparece no cenário, e não só nos números.

---

## Tecnologias

- **Engine / linguagem:** Unity / C#

---

## Equipe

Projeto desenvolvido para a disciplina **XDES17 – Introdução a Codificação de Jogos Digitais**.

| Nome | Matrícula |
|---|---|
| Rodrigo Ruan Souza Viana | 2024004644 |
| Rodolfo Henrique Faria | 2024008886 |
