using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Load += delegate
            {
                PictureBox pb = new PictureBox();
                pb.Dock= DockStyle.Fill;
                this.Controls.Add(pb);

                //GraphicsControl g = new GraphicsControl(pb);
                Game game = new Game(pb);
                game.Start();

                //Rectangle rec = new Rectangle(10, 10, 100, 100);
                //Image img = Image.FromFile(@"C:\Users\mom1ct\Desktop\sidivirto.jfif");

                //g.DrawRec(rec);

                //g.DrawImg(img);

                //g.DrawImgRec(img, rec);
            };
        }
    }

    public class Game
    {
        public Timer tm = new Timer();

        Image img { get; set; }
        GraphicsControl gc { get; set; } 
        public Game(PictureBox pb)
        {
            gc = new GraphicsControl(pb);
            img = Image.FromFile(@"C:\Users\mom1ct\Desktop\sidivirto.jfif");
            this.g = g;
            gc.InitGraphics();
        }

        public void Start()
        {
            int x = 1, y = 1;
            
            tm.Interval = 100;
            tm.Start();

            tm.Tick += delegate
            {
                gc.DrawImg(img, new Point(x, y));
                x++;
                y++;

                gc.DrawImgRec(img, new Rectangle(100, 100, 200, 100));

                gc.ClearAll();

                //if( x == 10) tm.Stop();
            };
        }
    }

    public class GraphicsControl
    {
        public Graphics g { get; set; }
        public Bitmap bitmap { get; set; }

        public PictureBox pb { get; set; }
        public GraphicsControl(PictureBox pb) => this.pb = pb;

        public void InitGraphics()
        {
            bitmap = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            pb.Image = bitmap;
        }

        public void DrawRec(Rectangle rec) => g.DrawRectangle(Pens.Black, rec);

        //public void DrawImg(Image img) => g.DrawImage(img, 0, 0);

        public void DrawImg(Image img, Point point) => g.DrawImage(img, point.X, point.Y);

        public void DrawImgRec(Image img, Rectangle rec) => g.DrawImage(img, rec);

        public void ClearAll()
        {
            pb.Refresh();
            g.Clear(Color.White);
        }
    }
}