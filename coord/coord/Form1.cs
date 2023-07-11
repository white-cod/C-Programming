namespace coord
{
    public partial class Form1 : Form
    {
        private const int RECTANGLE_BORDER_WIDTH = 10;

        private Rectangle _rectangle;

        public Form1()
        {
            InitializeComponent();

            int rectWidth = ClientRectangle.Width - 2 * RECTANGLE_BORDER_WIDTH;
            int rectHeight = ClientRectangle.Height - 2 * RECTANGLE_BORDER_WIDTH;
            int rectX = ClientRectangle.X + RECTANGLE_BORDER_WIDTH;
            int rectY = ClientRectangle.Y + RECTANGLE_BORDER_WIDTH;
            _rectangle = new Rectangle(rectX, rectY, rectWidth, rectHeight);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, _rectangle);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                if (_rectangle.Contains(e.Location))
                {
                    MessageBox.Show("Точка внутри прямоугольника");
                }
                else
                {
                    Rectangle borderRect = new Rectangle(_rectangle.X - RECTANGLE_BORDER_WIDTH,
                                                          _rectangle.Y - RECTANGLE_BORDER_WIDTH,
                                                          _rectangle.Width + 2 * RECTANGLE_BORDER_WIDTH,
                                                          _rectangle.Height + 2 * RECTANGLE_BORDER_WIDTH);
                    if (borderRect.Contains(e.Location))
                    {
                        MessageBox.Show("Точка на границе прямоугольника");
                    }
                    else
                    {
                        MessageBox.Show("Точка за пределами прямоугольника");
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Text = $"Width = {ClientRectangle.Width}, Height = {ClientRectangle.Height}";
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Text = $"X = {e.X}, Y = {e.Y}";
        }
    }
}