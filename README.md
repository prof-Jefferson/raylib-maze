# 🧩 Raylib Maze Generator

Projeto educacional em C# utilizando [Raylib-cs](https://github.com/ChrisDill/Raylib-cs), com foco na geração **procedural de labirintos** através do algoritmo **DFS Backtracking**, aplicando princípios sólidos de **Programação Orientada a Objetos (POO)**.

> 👨‍🏫 Ideal para ensino de lógica, estruturas de dados, POO e algoritmos gráficos interativos.

---

## ✨ Funcionalidades

- ✅ Geração de labirinto 2D em tempo real com animação
- ✅ Implementado em C# com estrutura modular
- ✅ Visualização colorida e interativa com Raylib-cs
- ✅ Células desenhadas com paredes removidas dinamicamente
- 🔜 (em desenvolvimento) Algoritmo de pathfinding (A*, BFS)
- 🔜 Interface com reinício de labirinto e escolha de tamanho

---

## 🎥 Demonstração

> *(Adicione aqui um gif ou screenshot do labirinto sendo gerado)*

---

## 🧠 Tecnologias

| Ferramenta        | Uso                              |
|-------------------|----------------------------------|
| C# (.NET)         | Lógica do projeto                |
| Raylib-cs         | Visualização gráfica             |
| Git / GitHub      | Versionamento e colaboração      |
| Terminal (CLI)    | Execução, build e controle Git   |

---

## 🧱 Estrutura de Pastas

```
RaylibMaze/
├── Program.cs            # Loop principal do jogo
├── Maze.cs               # Representa o labirinto completo
├── Cell.cs               # Célula individual com paredes e estado
├── MazeGenerator.cs      # Algoritmo DFS recursivo com backtracking
└── README.md             # Você está aqui 😊
```

---

## 🧩 Sobre o algoritmo

### 🔄 Geração de Labirinto (DFS Backtracking)

1. Começa de uma célula aleatória
2. Marca como visitada
3. Escolhe uma direção aleatória e avança, removendo paredes
4. Quando não há mais vizinhos não visitados, retrocede (backtrack)

### 🎨 Visual

- Células visitadas ganham cor
- Paredes são desenhadas com `DrawLine`
- Possibilidade de ajustar tamanho de grade facilmente

---

## 💡 Próximas melhorias

- [ ] Implementar A* para encontrar caminho do início ao fim
- [ ] Modo de animação mais lento/passo-a-passo
- [ ] Botão para reiniciar labirinto
- [ ] Interface com seleção de algoritmo

---

## 🚀 Como executar

### 1. Clone o repositório

```bash
git clone git@github.com:seu-usuario/raylib-maze.git
cd raylib-maze
```

### 2. Compile e rode com .NET

```bash
dotnet run
```

> Certifique-se de que o pacote `Raylib-cs` esteja instalado.

---

## 📚 Créditos

Projeto desenvolvido por **Jefferson Nogueira** com apoio do ChatGPT e da comunidade open source.  
Inspirado em algoritmos clássicos de computação gráfica e lógica de jogos.

---

## 🧠 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

> “Ensinar lógica com labirintos visuais é como transformar algoritmos em aventuras gráficas.” – 💡
