namespace WinFormsApp1
{
    public partial class reactionForm : Form
    {
        int teller;
        bool eerste = true;
        Random rnd = new Random();
        bool ingame = false;
        long score;
        bool canBePressed = false;
        long initial;
        long endinitial;
        public reactionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ingame)
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;
                initial = now.ToUnixTimeMilliseconds();
                button1.BackColor = Color.Red;
                button1.Text = "wait";
                button1.ForeColor = Color.White;
                
                timer1.Enabled = true;
                ingame = true;
                canBePressed = false;
            }
            else if(canBePressed)
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;
                endinitial = now.ToUnixTimeMilliseconds();
                // er is een offset bij het eindresultaat 
                score = (endinitial - initial) - 5000;
                
                MessageBox.Show("your reaction speed is " + score + "ms", "congrats!!", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                ingame = false;
                button1.BackColor = Color.White;
                button1.Text = "start";
                button1.ForeColor = Color.Black;
            }
            else
            {
                
                MessageBox.Show("Too early, Dunce!", "Moron!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ingame = false;
                button1.BackColor = Color.White;
                button1.Text = "start";
                button1.ForeColor = Color.Black;
            }
            eerste = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (eerste)
            {
                teller = 0;
                eerste = false;
                
            }
            if (teller > 3)
            {
                int chance = rnd.Next(1, 101);
                if (chance > 16)
                {
                    
                    button1.BackColor = Color.Green;
                    button1.Text = "click";
                    canBePressed=true;
                    
                    timer1.Enabled = false;
                }
            }
            teller += 1;

        }


    }
}