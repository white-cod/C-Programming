namespace ClockWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 2;
            int handLength = Math.Min(ClientSize.Width, ClientSize.Height) / 3;

            DateTime now = DateTime.Now;
            int hours = now.Hour % 12;
            int minutes = now.Minute;
            int seconds = now.Second;

            int circleDiameter = handLength * 2;
            Rectangle circleRect = new Rectangle(centerX - handLength, centerY - handLength, circleDiameter, circleDiameter);
            g.DrawEllipse(Pens.Black, circleRect);

            float hourAngle = 360 * (hours + minutes / 60f) / 12;
            DrawHand(g, centerX, centerY, hourAngle, handLength, 8);

            float minuteAngle = 360 * (minutes + seconds / 60f) / 60;
            DrawHand(g, centerX, centerY, minuteAngle, handLength, 4);

            float secondAngle = 360 * seconds / 60;
            DrawHand(g, centerX, centerY, secondAngle, handLength, 2);
        }

        private void DrawHand(Graphics g, int centerX, int centerY, float angle, int length, int width)
        {
            float radians = (angle - 90) * (float)Math.PI / 180;
            float x = centerX + length * (float)Math.Cos(radians);
            float y = centerY + length * (float)Math.Sin(radians);

            Pen pen = new Pen(Color.Black, width);
            g.DrawLine(pen, centerX, centerY, x, y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}