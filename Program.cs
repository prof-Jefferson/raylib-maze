using Raylib_cs;

/// <summary>
/// Classe principal do programa, responsável por inicializar a janela,
/// configurar o jogo e executar o loop principal que desenha o labirinto e aplica o algoritmo A*.
/// </summary>
class Program
{
    // Tamanho de cada célula em pixels
    const int CellSize = 20;

    // Número de colunas e linhas do labirinto
    const int Cols = 30;
    const int Rows = 20;

    /// <summary>
    /// Ponto de entrada do programa.
    /// Inicializa a janela, cria o labirinto e executa o loop de renderização.
    /// </summary>
    static void Main()
    {
        // Inicializa a janela com base nas dimensões do labirinto
        Raylib.InitWindow(Cols * CellSize, Rows * CellSize, "Labirinto Procedural com DFS + A*");
        Raylib.SetTargetFPS(60); // Define taxa de atualização para 60 FPS

        // Cria o labirinto e o gerador de labirinto
        var maze = new Maze(Cols, Rows);
        var generator = new MazeGenerator(maze);
        Pathfinder? pathfinder = null;

        // Flag para saber se a geração terminou
        bool mazeComplete = false;

        // Loop principal do jogo
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Se ainda está gerando o labirinto, continua o processo
            if (!mazeComplete)
            {
                generator.GenerateStepwise();

                // Verifica se a pilha está vazia para saber se terminou
                if (maze.Stack.Count == 0)
                {
                    mazeComplete = true;
                    pathfinder = new Pathfinder(maze); // Inicializa o A*
                }
            }
            else if (pathfinder != null && !pathfinder.IsFinished())
            {
                pathfinder.Step(); // Executa um passo da busca A*
            }

            // Desenha o labirinto e o progresso do pathfinding
            maze.Draw(CellSize);
            pathfinder?.Draw(CellSize);

            Raylib.EndDrawing();
        }

        // Encerra a janela ao sair
        Raylib.CloseWindow();
    }
}
