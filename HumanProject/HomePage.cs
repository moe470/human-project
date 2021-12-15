using System;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace HumanProject
{
    public partial class HomePage : Form
    {

        private bool confirmed = false;
        private Point point;
        private double totalPrice;
        public static object Thread { get; private set; }

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            // hide panels
            BurgerCartPanel.Visible = false;
            WedgeCartPanel.Visible = false;
            WaterCartPanel.Visible = false;
            PepsiCartPanel.Visible = false;
            SteakCartPanel.Visible = false;
            MashedCartPanel.Visible = false;

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

            if(e.Button == MouseButtons.Left)
            {
                point = e.Location;
            }

        }

       

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                this.Left = e.X + this.Left - point.X;
                this.Top = e.Y + this.Top - point.Y;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)// close button
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)// minimize button
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void MainCourse_Click(object sender, EventArgs e)
        {
            // hide items
            ConfirmOrderButton.Visible = false;
            ConfirmLabel.Visible = false;
            CartPanel.Visible = false;
            DishPanel.Visible = true;
            BurgerPanel.Visible = true;
            SteakPanel.Visible = true;
            Waterpanel.Visible = false;
            MashedTatersPanel.Visible = false;
            WedgePotatoPanel.Visible = false;
            DietPepsiPanel.Visible = false;
            TotalPriceLabel.Visible = false;
            TotalPriceLbl.Visible = false;
            ContactPanel.Visible = false;
            RedIndecator.Top = MainDishButton.Top;
        }
        private void SideDishButton_Click(object sender, EventArgs e)
        {
            // hide items
            ConfirmOrderButton.Visible = false;
            ConfirmLabel.Visible = false;
            CartPanel.Visible = false;
            DishPanel.Visible = true;
            ContactPanel.Visible = false;
            MashedTatersPanel.Visible = true;
            WedgePotatoPanel.Visible = true;
            DietPepsiPanel.Visible = false;
            Waterpanel.Visible = false;
            BurgerPanel.Visible = false;
            SteakPanel.Visible = false;
            TotalPriceLabel.Visible = false;
            TotalPriceLbl.Visible = false;
            // change location for side dish
            MashedTatersPanel.Top = SteakPanel.Top;
            MashedTatersPanel.Left = SteakPanel.Left;
            WedgePotatoPanel.Top = BurgerPanel.Top;
            WedgePotatoPanel.Left = BurgerPanel.Left;

            RedIndecator.Top = SideDishButton.Top;
        }

        private void DrinksButton_Click(object sender, EventArgs e)
        {
            ConfirmOrderButton.Visible = false;
            ConfirmLabel.Visible = false;
            DishPanel.Visible = true;
            CartPanel.Visible = false;
            DietPepsiPanel.Visible = true;
            Waterpanel.Visible = true;
            MashedTatersPanel.Visible = false;
            WedgePotatoPanel.Visible = false;
            BurgerPanel.Visible = false;
            SteakPanel.Visible = false;
            TotalPriceLabel.Visible = false;
            TotalPriceLbl.Visible = false;
            ContactPanel.Visible = false;
            //change location 
            Waterpanel.Top= SteakPanel.Top;
            Waterpanel.Left = SteakPanel.Left;
            DietPepsiPanel.Top = BurgerPanel.Top;
            DietPepsiPanel.Left = BurgerPanel.Left;

            RedIndecator.Top = DrinksButton.Top;
        }

        private void CartButton_Click(object sender, EventArgs e)
        {
            // change posistion and make visible
            ConfirmOrderButton.Visible = true;
            DishPanel.Visible = false;
            CartPanel.Visible = true;
            ContactPanel.Visible = false;
            CartPanel.Top = DishPanel.Top;
            CartPanel.Left = DishPanel.Left;
            RedIndecator.Top = CartButton.Top;
            CartPanel.Width = DishPanel.Width;
            CartPanel.Height = DishPanel.Height;

            //calcualte total price
            TotalPriceLabel.Visible = true;
            TotalPriceLbl.Visible = true;
            calculateTotalPrice();
            if (totalPrice == 0)
            {
                ConfirmOrderButton.Visible = false;
            }
            else
            {
                ConfirmOrderButton.Visible = true;
            }
            
                     
            

        }
        private void calculateTotalPrice()
        {
            if (!confirmed)
            {
                totalPrice = (Double.Parse(CartBurQuan.Text) * 3.5 + Double.Parse(CartWedgeQuan.Text) * 1.5
                    + Double.Parse(CartMashQuan.Text) * 1.5 + Double.Parse(CartWaterQuan.Text) * 0.1
                    + Double.Parse(CartPepQuan.Text) * 0.3 + Double.Parse(CartSteakQuan.Text) * 8.5);
                TotalPriceLbl.Text = totalPrice + " OMR";
            }

            // show empty cart massage
            if (totalPrice == 0)
            {
                TotalPriceLabel.Text = "OOPS Empty Cart!!!";
                TotalPriceLabel.Top = 250;
                TotalPriceLabel.Left = 350;
                TotalPriceLbl.Visible = false;
            }
            else
            {
                TotalPriceLabel.Text = "Total Price";
                TotalPriceLabel.Top = TotalPriceLbl.Top;
                TotalPriceLabel.Left = 130;
            }
        }
        private void ContactUsButton_Click(object sender, EventArgs e)
        {
            ConfirmLabel.Visible = false;
            ConfirmOrderButton.Visible = false;
            ContactPanel.Top = DishPanel.Top;
            ContactPanel.Left = DishPanel.Left;
            ContactPanel.Visible = true;
            DishPanel.Visible = false;
            CartPanel.Visible = false;
            TotalPriceLabel.Visible = false;
            TotalPriceLbl.Visible = false;
            RedIndecator.Top = ContactUsButton.Top;
        }

        private void burgerControl1_Load(object sender, EventArgs e)
        {

        }

        private void burgerControl1_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //////// Order buttons////////////////////////////////////////////////
        private void OrderBurgerButton_Click(object sender, EventArgs e)
        {
            CartBurQuan.Text = BurgerQuantity.Text;
            BurgerCartPanel.Visible = true;
            
        }
        private void OrderSteakButton_Click(object sender, EventArgs e)
        {
            CartSteakQuan.Text = SteakQuantity.Text;
            SteakCartPanel.Visible = true;
        }
        private void OrderWedgeButton_Click(object sender, EventArgs e)
        {
            CartWedgeQuan.Text = WedgeQuantity.Text;
            WedgeCartPanel.Visible = true;
        }
        private void OrderMashedButton_Click(object sender, EventArgs e)
        {
            CartMashQuan.Text = MashedQuantity.Text;
            MashedCartPanel.Visible = true;
        }
        private void OrderPepsiButton_Click(object sender, EventArgs e)
        {
            CartPepQuan.Text = PepsiQuantity.Text;
            PepsiCartPanel.Visible = true;
        }

        private void OrderWaterButton_Click(object sender, EventArgs e)
        {
            CartWaterQuan.Text = WaterQuantity.Text;
            WaterCartPanel.Visible = true;
        }
        // delete buttons///////////////////////////////////////////////
        private void DelBurgerButton_Click(object sender, EventArgs e)
        {
            BurgerCartPanel.Visible = false;
            CartBurQuan.Text = "0";
            calculateTotalPrice();
            if (totalPrice == 0)
            {
                ConfirmOrderButton.Visible = false;
            }
            else
            {
                ConfirmOrderButton.Visible = true;
            }

        }

        private void DelSteakButton_Click(object sender, EventArgs e)
        {
            SteakCartPanel.Visible = false;
            CartSteakQuan.Text = "0";
            calculateTotalPrice();
            if (totalPrice == 0)
            {
                ConfirmOrderButton.Visible = false;
            }
            else
            {
                ConfirmOrderButton.Visible = true;
            }

        }

        private void DelWedgeButton_Click(object sender, EventArgs e)
        {
            WedgeCartPanel.Visible = false;
            CartWedgeQuan.Text = "0";
            calculateTotalPrice();
            if (totalPrice == 0)
            {
                ConfirmOrderButton.Visible = false;
            }
            else
            {
                ConfirmOrderButton.Visible = true;
            }

        }

        private void DelPotatoButton_Click(object sender, EventArgs e)
        {
            MashedCartPanel.Visible = false;
            CartMashQuan.Text = "0";
            calculateTotalPrice();
            if (totalPrice == 0)
            {
                ConfirmOrderButton.Visible = false;
            }
            else
            {
                ConfirmOrderButton.Visible = true;
            }

        }

        private void DelWaterButton_Click(object sender, EventArgs e)
        {
            WaterCartPanel.Visible = false;
            CartWaterQuan.Text = "0";
            calculateTotalPrice();
            if (totalPrice == 0)
            {
                ConfirmOrderButton.Visible = false;
            }
            else
            {
                ConfirmOrderButton.Visible = true;
            }

        }

        private void DelPepsiButton_Click(object sender, EventArgs e)
        {
            PepsiCartPanel.Visible = false;
            CartPepQuan.Text = "0";
            calculateTotalPrice();
            if (totalPrice == 0)
            {
                ConfirmOrderButton.Visible = false;
            }
            else
            {
                ConfirmOrderButton.Visible = true;
            }

        }
        /// calculate price when quantity change
        private void CartBurQuan_TextChanged(object sender, EventArgs e)
        {
            calculateTotalPrice();
        }

        private void CartSteakQuan_TextChanged(object sender, EventArgs e)
        {
            calculateTotalPrice();
        }

        private void CartWedgeQuan_TextChanged(object sender, EventArgs e)
        {
            calculateTotalPrice();
        }

        private void CartWaterQuan_TextChanged(object sender, EventArgs e)
        {
            calculateTotalPrice();
        }

        private void CartPepQuan_TextChanged(object sender, EventArgs e)
        {
            calculateTotalPrice();
        }

        private void CartMashQuan_TextChanged(object sender, EventArgs e)
        {
            calculateTotalPrice();
        }

        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            DelBurgerButton.Visible = false;
            DelSteakButton.Visible = false;
            DelPepsiButton.Visible = false;
            DelPotatoButton.Visible = false;
            DelWaterButton.Visible = false;
            DelWedgeButton.Visible = false;
            CartBurQuan.Visible = false;
            CartWedgeQuan.Visible = false;
            CartPepQuan.Visible = false;
            CartMashQuan.Visible = false;
            CartWaterQuan.Visible = false;
            CartSteakQuan.Visible = false;

            ConfirmLabel.Visible = true;
            confirmed = true;

        }

        private void TotalPriceLbl_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void SendFeedButton_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = File.CreateText(@"C:\Users\fsqum\source\repos\HumanProject\user Feedback.txt"))
            {
                writer.WriteLine(feedBackBox.Text);
            }
            if(feedBackBox.Text.Length!=0)
            feedBackBox.Text = "thank you for your feedback!!!";
        }
    }
}
