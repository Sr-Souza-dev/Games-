using System.Text.Json;
using System.Net.Http;

namespace jogoVelha_api_
{
    public partial class Form1 : Form
    {
        const string baseURL = "http://localhost:9000/";
        string moveURL = "";
        string[][]? currentBoard;
        int moveLine = 0;
        int moveColumn = 0;
        int aux = 0;

        public Form1()
        {
            InitializeComponent();
            reloadInit();
        }

        private void setGame(string[][] board)
        {
            try
            {
                ps00.Text = board[0][0];
                ps01.Text = board[0][1];
                ps02.Text = board[0][2];

                ps10.Text = board[1][0];
                ps11.Text = board[1][1];
                ps12.Text = board[1][2];

                ps20.Text = board[2][0];
                ps21.Text = board[2][1];
                ps22.Text = board[2][2];

                currentBoard = board;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void reloadInit()
        {
            try
            {
                var connection = (new HttpClient()).GetAsync(baseURL + "api/jogo");
                var stringBoard = connection.Result.Content.ReadAsStringAsync().Result;
                string[][] board = JsonSerializer.Deserialize<string[][]>(stringBoard)!;
                setGame(board);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private int[]? analysisHorizont()
        {
            int cont = 0;
            int position = -1;

            for(int i =0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if (currentBoard![i][j] != "")
                    {
                        if (currentBoard![i][j] != select.Text)
                        {
                            cont++;
                        }
                    }
                    else 
                    {
                        position = j;
                    }
                    if (cont == 2 && position != -1)
                    {
                        return new int[2] { i, position };
                    }
                }
                cont = 0;
                position = -1;
            }
            return null;
        }

        private int[]? analysisVertic()
        {
            int cont = 0;
            int position = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentBoard![j][i] != "")
                    {
                        if (currentBoard![j][i] != select.Text)
                        {
                            cont++;
                        }
                    }
                    else 
                    {
                        position = j;
                    }
                    if (cont == 2 && position != -1)
                    {
                        return new int[2] { position, i };
                    }
                }
                cont = 0;
                position = -1;
            }
            return null;
        }

        private int[]? analysisDiag()
        {
            int cont = 0;
            int position = -1;

            for(int i = 0; i<3; i++)
            {
                if (currentBoard![i][i] != "")
                {
                    if (currentBoard![i][i] != select.Text)
                    {
                        cont++;
                    }
                }
                else if (currentBoard![i][i] == "")
                {
                    position = i;
                }
                if(cont == 2 && position != -1) {
                    return new int[2] { position, position };
                }
            }

            int column = 2;
            cont = 0;
            int positionL = -1;
            int positionC = -1;

            for (int line = 0; line<3; line++)
            {
                if(currentBoard![line][column] != "")
                {
                    if(currentBoard![line][column] != select.Text)
                    {
                        cont++;
                    }
                }
                else if (currentBoard![line][column] == "")
                {
                    positionL = line;
                    positionC = column;
                }
                if(cont == 2 && positionC != -1 && positionL != -1)
                {
                    return new int[2] { positionL, positionC };
                }
                column--;   
            }
            return null;
        }

        private bool defense()
        {
            var analysis = analysisHorizont()   != null ? analysisHorizont()
                            : analysisVertic()  != null ? analysisVertic()
                            : analysisDiag()    != null ? analysisDiag() : null;

            if (analysis != null)
            {
                moveLine = analysis[0];
                moveColumn = analysis[1];
                return true;
            }
            return false;
        }

        private double howManyMoves()
        {
            int cont = 0;
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    if(currentBoard![i][j] != "")
                    {
                        cont++;
                    }
                }
            }   

            return cont/2.0;
        }

        private bool atack()
        {
            double moves = howManyMoves();

            if (moves == 0)
            {
                moveLine = 0;
                moveColumn = 0;
                return true;
            } else if(moves > 0 && moves < 1)
            {
                if(currentBoard![1][1] == "")
                {
                    moveLine = 1;
                    moveColumn = 1;
                    return true;
                }
                else
                {
                    moveLine = 0;
                    moveColumn = 0;
                    return true;
                }
            } else if(moves == 1)
            {
                if(currentBoard![0][2] != "" || currentBoard![2][0] != "" || currentBoard![1][1] != "")
                {
                    moveLine = 2;
                    moveColumn = 2;
                    return true;
                }
                else
                {
                    moveLine = 1;
                    moveColumn = 1;
                    return true;
                }
            }
            else if (moves > 1 && moves < 2)
            {
                if((currentBoard![0][2] != "" && currentBoard![2][0] != "") || (currentBoard![0][0] != "" && currentBoard![2][2] != "" && currentBoard![0][0] != select.Text))
                {
                    moveLine = 1;
                    moveColumn = 0;
                    return true;
                } else if(currentBoard![1][1] != "" && currentBoard![1][1] != select.Text && currentBoard![2][2] != "")
                {
                    moveLine = 0;
                    moveColumn = 2;
                    return true;
                }
            } else if(moves == 2)
            {
                if(currentBoard![0][0] == select.Text && currentBoard![2][2] == select.Text)
                {
                    if(currentBoard![0][1] == "" && currentBoard![1][2] == "" && currentBoard![0][2] == "") {
                        moveLine = 0;
                        moveColumn = 2;
                        return true;
                    } else if(currentBoard![1][0] == "" && currentBoard![2][1] == "" && currentBoard![2][0] == "")
                    {
                        moveLine = 2;
                        moveColumn = 0;
                        return true;
                    }

                }
                else if(currentBoard![0][0] == select.Text && currentBoard![1][1] == select.Text)
                {
                    if(currentBoard![0][1] == "" && currentBoard![0][2] == "")
                    {
                        if(currentBoard![2][1] == "")
                        {
                            moveLine = 0;
                            moveColumn = 1;
                            return true;
                        } else if(currentBoard![2][0] == "")
                        {
                            moveLine = 0;
                            moveColumn = 2;
                            return true;
                        }
                    } else if (currentBoard![1][0] == "" && currentBoard![2][0] == "")
                    {
                        if (currentBoard![1][2] == "")
                        {
                            moveLine = 1;
                            moveColumn = 0;
                            return true;
                        }
                        else if (currentBoard![0][2] == "")
                        {
                            moveLine = 2;
                            moveColumn = 0;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void randonMove()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentBoard![i][j] == "")
                    {
                        moveLine = i;
                        moveColumn = j;
                        return;
                    }
                }
            }
        }

        private int[]? win()
        {
            int conth = 0;
            int positionh = -1;

            int contv = 0;
            int positionv = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Vitoria na horizontal
                    
                    if (currentBoard![i][j] != "")
                    {
                        if (currentBoard![i][j] == select.Text)
                        {
                            conth++;
                        }
                    }
                    else
                    {
                        positionh = j;
                    }
                    if (conth == 2 && positionh != -1)
                    {
                        return new int[2] { i, positionh };
                    }

                    // vitoria na vertical
                 
                    if (currentBoard![j][i] != "")
                    {
                        if (currentBoard![j][i] == select.Text)
                        {
                            contv++;
                        }
                    }
                    else
                    {
                        positionv = j;
                    }
                    if (contv == 2 && positionv != -1)
                    {
                        return new int[2] { positionv, i };
                    }
                }
         
                conth = 0;
                positionh = -1;

                contv = 0;
                positionv = -1;
            }

            // ganhar diagonal
            int cont = 0;
            int position = -1;

            for (int i = 0; i < 3; i++)
            {
                if (currentBoard![i][i] != "")
                {
                    if (currentBoard![i][i] == select.Text)
                    {
                        cont++;
                    }
                }
                else if (currentBoard![i][i] == "")
                {
                    position = i;
                }
                if (cont == 2 && position != -1)
                {
                    return new int[2] { position, position };
                }
            }

            int column = 2;
            cont = 0;
            int positionL = -1;
            int positionC = -1;

            for (int line = 0; line < 3; line++)
            {
                if (currentBoard![line][column] != "")
                {
                    if (currentBoard![line][column] == select.Text)
                    {
                        cont++;
                    }
                }
                else if (currentBoard![line][column] == "")
                {
                    positionL = line;
                    positionC = column;
                }
                if (cont == 2 && positionC != -1 && positionL != -1)
                {
                    return new int[2] { positionL, positionC };
                }
                column--;
            }

            return null;
        }
        
  
        private void newPlay()
        {
            var analysis = win();
            if (analysis != null)
            {
                moveLine = analysis[0];
                moveColumn = analysis[1];
                MessageBox.Show("for win");
            }
            else if (defense())
            {
                MessageBox.Show("for defence");
            }
            else if(atack())
            {
                MessageBox.Show("for atack");
            }
            else
            {
                MessageBox.Show("for randon");
                randonMove();
            }
        }

        private void analyzeBoard (){
            reloadInit();

            if (select.Text != "Select") {
                // Exemplo de test

                newPlay();
                currentBoard![moveLine][moveColumn] = select.Text;
                setGame(currentBoard);


                moveURL = baseURL 
                    + "api/jogo?marcador=" + select.Text 
                    + "&linha=" + moveLine 
                    + "&coluna=" + moveColumn;
                aux = 2;
            }
            else
            {
                MessageBox.Show("Selecione uma forma (X ou O)");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void approve_Click(object sender, EventArgs e)
        {
                if (aux == 2)
            {
                try
                {
                    HttpClient client = new HttpClient();
                    var response = client.GetAsync(moveURL).Result;

                    var stringBoard = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        string[][] board = JsonSerializer.Deserialize<string[][]>(stringBoard)!;
                        setGame(board);

                        MessageBox.Show("Jogada Realizada");
                    }catch(Exception ex)
                    {
                        MessageBox.Show(stringBoard + ex);
                    }
                }
                catch(Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("A jogada não foi Análisada até o momento (Faça uma análise e tente novamente)!");
            }
            aux = 1;
        }

        private void analyze_Click(object sender, EventArgs e)
        {
            aux = 2;
            analyzeBoard();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            aux = 1;
            reloadInit();
        }
    }
}