﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Form : System.Windows.Forms.Form
    {
        SortedDictionary<string, int> FuelPrice = new SortedDictionary<string, int>();
        public Form()
        {
            InitializeComponent();

            FuelPrice.Add("A-95 Premium", 49);
            FuelPrice.Add("A-95", 47);
            FuelPrice.Add("A-92", 46);
            FuelPrice.Add("Diesel", 47);
            FuelPrice.Add("Gas", 22);

            this.ComboPetrol.Items.AddRange(FuelPrice.Keys.ToArray());
        }
        private void ComboPetrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ComboPrice.Text = FuelPrice[ComboPetrol.SelectedItem.ToString()].ToString();
        }
        private void RadioPrice_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBoxCount.ReadOnly = true;
            this.TextBoxPrice.ReadOnly = false;
        }
        private void RadioCount_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBoxCount.ReadOnly = false;
            this.TextBoxPrice.ReadOnly = true;
        }
        private void TextBoxPrice_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBoxPrice.Text == "") this.LableRefuelingPrice.Text = "0,0";
            else this.LableRefuelingPrice.Text = this.TextBoxPrice.Text;
            this.TextBoxCount.Text = (Convert.ToDouble(this.TextBoxPrice.Text) / FuelPrice[ComboPetrol.SelectedItem.ToString()]).ToString();
        }
        private void GeneralChangesPrices(object sender, EventArgs e)
        {
            this.LablePayPrice.Text = (Convert.ToDouble(this.LableRefuelingPrice.Text) + Convert.ToDouble(this.LableCafePrice.Text)).ToString();
        }

        private void TextBoxPrice_Leave(object sender, EventArgs e)
        {
            if (this.TextBoxPrice.Text == "   ,") this.TextBoxCount.Text = "00000";
            else
            {
                this.TextBoxCount.Text = (FuelPrice[ComboPetrol.SelectedItem.ToString()] / Convert.ToDouble(this.TextBoxPrice.Text)).ToString();
                this.LableRefuelingPrice.Text = this.TextBoxPrice.Text;
            }
        }

        private void TextBoxCount_Leave(object sender, EventArgs e)
        {
            if (this.TextBoxCount.Text == "   ,") this.TextBoxPrice.Text = "00000";
            else
            {
                this.TextBoxPrice.Text = (Convert.ToDouble(this.TextBoxCount.Text) * FuelPrice[ComboPetrol.SelectedItem.ToString()]).ToString();
                this.LableRefuelingPrice.Text = this.TextBoxPrice.Text;
            }
        }

        private void CheckFood1_CheckedChanged(object sender, EventArgs e)
        {
            if(MaskedFood1.ReadOnly = !this.CheckFood1.Checked) MaskedFood1.Text = "";
        }

        private void CheckFood2_CheckedChanged(object sender, EventArgs e)
        {
            if (MaskedFood2.ReadOnly = !this.CheckFood2.Checked) MaskedFood2.Text = "";
        }

        private void CheckFood3_CheckedChanged(object sender, EventArgs e)
        {
            if (MaskedFood3.ReadOnly = !this.CheckFood3.Checked) MaskedFood3.Text = "";
        }

        private void CheckFood4_CheckedChanged(object sender, EventArgs e)
        {
            if (MaskedFood4.ReadOnly = !this.CheckFood4.Checked) MaskedFood4.Text = "";
        }
        private void CafePriceChange(object sender, EventArgs e)
        {
            double res = 0;
            if (MaskedFood1.Text != "") res += Convert.ToDouble(MaskedFood1.Text) * Convert.ToDouble(this.TextBoxFood1.Text);
            if (MaskedFood2.Text != "") res += Convert.ToDouble(MaskedFood2.Text) * Convert.ToDouble(this.TextBoxFood2.Text);
            if (MaskedFood3.Text != "") res += Convert.ToDouble(MaskedFood3.Text) * Convert.ToDouble(this.TextBoxFood3.Text);
            if (MaskedFood4.Text != "") res += Convert.ToDouble(MaskedFood4.Text) * Convert.ToDouble(this.TextBoxFood4.Text);
            this.LableCafePrice.Text = res.ToString();
        }
    }
}
