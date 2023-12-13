namespace Hangman_Game
{
    public partial class Form1 : Form
    {
        List<string> wordList = new List<string>();
        List<string> letterList = new List<string>();
        List<char> hidden = new List<char>();
        int pos = 0;
        string secret = "";
        public Form1()
        {
            InitializeComponent();
        }
        static Image sprite1 = Hangman_Game.Resource1.Hangman_sprite1;
        static Image sprite2 = Hangman_Game.Resource1.Hangman_sprite2;
        static Image sprite3 = Hangman_Game.Resource1.Hangman_sprite3;
        static Image sprite4 = Hangman_Game.Resource1.Hangman_sprite4;
        static Image sprite5 = Hangman_Game.Resource1.Hangman_sprite5;
        static Image sprite6 = Hangman_Game.Resource1.Hangman_sprite6;
        static Image sprite7 = Hangman_Game.Resource1.Hangman_sprite7;
        static Image sprite8 = Hangman_Game.Resource1.Hangman_sprite8;
        static Image sprite9 = Hangman_Game.Resource1.Hangman_sprite9;
        static Image sprite10 = Hangman_Game.Resource1.Hangman_sprite10;

        Image[] sprites = new Image[] { sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8, sprite9, sprite10 };
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("../../../resources/ukenglish.txt");
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    if (ln.Length > 2 && ln.Length < 9)
                    {
                        wordList.Add(ln);
                    }

                }
                file.Close();
                Random random = new Random();
                int pos = random.Next(0, wordList.Count);
                string word = wordList[pos - 1];
                for (int i = 0; i < word.Length; i++)
                {
                    hidden.Add('_');
                    textBox1.Text += hidden[i];
                }
                secret = word;
            }
        }

        public bool lettercheck(string word)
        {
            if (word == "")
            {
                return false;
            }
            else
            {
                if ((word == secret))
                {
                    return true;
                }
                bool update = false;
                for (int i = 0; i < hidden.Count; i++)
                {
                    if (word[0] == secret[i])
                    {
                        hidden[i] = word[0];
                        update = true;
                    }
                }
                if (!update)
                {
                    textBox2.Text += word[0];
                }
                return update;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lettercheck(textBox3.Text);
            textBox1.Text = string.Empty;
            for (int i = 0; i < hidden.Count; i++)
            {
                textBox1.Text += hidden[i];
            }
            if (!lettercheck(textBox3.Text))
            {
                pos = pos + 1;
                pictureBox1.Image = sprites[pos];
                if (pos == 9)
                {
                    textBox1.Text = "You Fail, word was " + secret;
                    textBox2.Text = "You Fail, word was " + secret;
                    textBox3.Text = "You Fail, word was " + secret;
                }
            }
            else if (textBox1.Text == secret)
            {
                textBox1.Text = "You Win";
                textBox2.Text = "You Win";
                textBox3.Text = "You Win";
            }
        }
    }
}