using System;
using System.ComponentModel;

namespace BestOil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbFuelType.SelectedIndex = 0;
            lblFuelPrice.Text = $"Price per liter: {GetFuelPrice()} UAH.";
            txtLiters.Enabled = true;
            rbtnMoney.Checked = false;
            UpdatePaymentLabel();

            ComponentResourceManager resources = new ComponentResourceManager(this.GetType());
            resources.ApplyResources(this, "$this");
            foreach (Control control in this.Controls)
            {
                resources.ApplyResources(control, control.Name);
            }

            toolStripStatusLabelDayOfWeek.Text = DateTime.Now.ToString("dddd");
        }

        /// Refueling \\\

        private Dictionary<string, decimal> fuelPrices = new Dictionary<string, decimal>
        {
            { "92", 35.50M },
            { "95", 40.00M },
            { "Diesel", 25.20M }
        };

        private decimal GetFuelPrice()
        {
            string selectedFuelType = cmbFuelType.SelectedItem.ToString();

            if (fuelPrices.ContainsKey(selectedFuelType))
            {
                return fuelPrices[selectedFuelType];
            }
            else
            {
                return 0.0M;
            }
        }

        private void UpdatePaymentLabel()
        {
            if (rbtnLiters.Checked)
            {
                if (decimal.TryParse(txtLiters.Text, out decimal liters))
                {
                    decimal totalPrice = liters * GetFuelPrice();
                    lblPayment.Text = $" {totalPrice.ToString("F2")} UAH.";
                }
                else
                {
                    lblPayment.Text = "0 UAH.";
                }
            }
            else if (rbtnMoney.Checked)
            {
                if (decimal.TryParse(txtLiters.Text, out decimal money))
                {
                    decimal totalLiters = money / GetFuelPrice();
                    lblPayment.Text = $" {totalLiters.ToString("F2")} l.";
                }
                else
                {
                    lblPayment.Text = "0 l.";
                }
            }
        }

        private void cmbFuelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFuelPrice.Text = $"Price per liter: {GetFuelPrice()} UAH.";
            UpdatePaymentLabel();
        }

        /// cafe \\\

        private void chkProduct1_CheckedChanged(object sender, EventArgs e)
        {
            txtProduct1Quantity.Enabled = chkProduct1.Checked;
        }

        private void chkProduct2_CheckedChanged(object sender, EventArgs e)
        {
            txtProduct2Quantity.Enabled = chkProduct2.Checked;
        }

        private void chkProduct3_CheckedChanged(object sender, EventArgs e)
        {
            txtProduct3Quantity.Enabled = chkProduct3.Checked;
        }

        private void chkProduct4_CheckedChanged(object sender, EventArgs e)
        {
            txtProduct4Quantity.Enabled = chkProduct4.Checked;
        }

        private void btnCalculateTotal_Click(object sender, EventArgs e)
        {
            decimal totalCafePurchase = 0;

            if (chkProduct1.Checked)
            {
                int coffeeQuantity = 0;
                if (int.TryParse(txtProduct1Quantity.Text, out coffeeQuantity))
                {
                    totalCafePurchase += coffeeQuantity * 28;
                }
            }

            if (chkProduct2.Checked)
            {
                int teaQuantity = 0;
                if (int.TryParse(txtProduct2Quantity.Text, out teaQuantity))
                {
                    totalCafePurchase += teaQuantity * 15;
                }
            }

            if (chkProduct3.Checked)
            {
                int sandwichQuantity = 0;
                if (int.TryParse(txtProduct3Quantity.Text, out sandwichQuantity))
                {
                    totalCafePurchase += sandwichQuantity * 40;
                }
            }

            if (chkProduct4.Checked)
            {
                int barQuantity = 0;
                if (int.TryParse(txtProduct4Quantity.Text, out barQuantity))
                {
                    totalCafePurchase += barQuantity * 20;
                }
            }

            txtTotalCafePurchase.Text = totalCafePurchase.ToString("F2") + " UAH";
        }

        private decimal totalRevenue = 0;

        /////////////////////////////////////////////////
        private decimal CalculateCafeAmount()
        {
            decimal cafeAmount = 0;

            if (chkProduct1.Checked)
            {
                int coffeeQuantity = 0;
                if (int.TryParse(txtProduct1Quantity.Text, out coffeeQuantity))
                {
                    cafeAmount += coffeeQuantity * 28;
                }
            }

            if (chkProduct2.Checked)
            {
                int teaQuantity = 0;
                if (int.TryParse(txtProduct2Quantity.Text, out teaQuantity))
                {
                    cafeAmount += teaQuantity * 15;
                }
            }

            if (chkProduct3.Checked)
            {
                int sandwichQuantity = 0;
                if (int.TryParse(txtProduct3Quantity.Text, out sandwichQuantity))
                {
                    cafeAmount += sandwichQuantity * 40;
                }
            }

            if (chkProduct4.Checked)
            {
                int barQuantity = 0;
                if (int.TryParse(txtProduct4Quantity.Text, out barQuantity))
                {
                    cafeAmount += barQuantity * 20;
                }
            }

            return cafeAmount;
        }

        private decimal CalculateFuelAmount()
        {
            decimal fuelAmount = 0;

            int fuelQuantity = 0;
            if (rbtnLiters.Checked)
            {
                if (int.TryParse(txtLiters.Text, out fuelQuantity))
                {
                    decimal fuelPrice = GetFuelPrice();
                    fuelAmount = fuelQuantity * fuelPrice;
                }
            }
            else if (rbtnMoney.Checked)
            {
                if (decimal.TryParse(txtLiters.Text, out decimal moneyAmount))
                {
                    decimal fuelPrice = GetFuelPrice();

                    fuelQuantity = (int)(moneyAmount / fuelPrice);
                    fuelAmount = moneyAmount;
                }
            }

            return fuelAmount;
        }

        private void ClearForm()
        {
            chkProduct1.Checked = false;
            txtProduct1Quantity.Text = string.Empty;

            chkProduct2.Checked = false;
            txtProduct2Quantity.Text = string.Empty;

            chkProduct3.Checked = false;
            txtProduct3Quantity.Text = string.Empty;

            chkProduct4.Checked = false;
            txtProduct4Quantity.Text = string.Empty;

            cmbFuelType.SelectedIndex = 0;
            txtLiters.Text = string.Empty;
            rbtnLiters.Checked = true;
            rbtnMoney.Checked = false;

            lblCalculatedAmount.Text = string.Empty;
        }

        ///////////////////////////////////////////////////////////////

        private void btnCalculateAmount_Click(object sender, EventArgs e)
        {
            decimal cafeAmount = CalculateCafeAmount();

            decimal fuelAmount = CalculateFuelAmount();

            decimal overallAmount = cafeAmount + fuelAmount;

            totalRevenue += overallAmount;

            lblCalculatedAmount.Text = $"{overallAmount.ToString("F2")} UAH";

            clearFormTimer.Enabled = true;
            clearFormTimer.Start();
        }

        private void clearFormTimer_Tick(object sender, EventArgs e)
        {
            clearFormTimer.Stop();

            DialogResult result = MessageBox.Show("Clear the form for the next customer?", "Clear form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearForm();
            }
            else
            {
                clearFormTimer.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            toolStripStatusLabel1.Text = currentTime.ToString("HH:mm:ss");
        }

        private void ApplyResourcesRecursively(Control control, ComponentResourceManager manager)
        {
            manager.ApplyResources(control, control.Name);
            foreach (Control child in control.Controls)
            {
                ApplyResourcesRecursively(child, manager);
            }
        }

        private void ukrainianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("uk-UA");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("uk-UA");
            ComponentResourceManager manager = new ComponentResourceManager(this.GetType());
            manager.ApplyResources(this, "$this");
            ApplyResourcesRecursively(this, manager);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            ComponentResourceManager manager = new ComponentResourceManager(this.GetType());
            manager.ApplyResources(this, "$this");
            ApplyResourcesRecursively(this, manager);
        }


    }
}