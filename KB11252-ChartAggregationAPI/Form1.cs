﻿using Infragistics.Win.DataVisualization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chartDataAggregation_sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var categoryChart = new UltraCategoryChart();
            categoryChart.DataSource = new EnergyDataHistory();
            categoryChart.Dock = DockStyle.Fill;

            categoryChart.Dock = DockStyle.Fill;

            // InitialGropups の設定
            categoryChart.InitialGroups = "Country";

            // InitialSummaries の設定
            //categoryChart.InitialSummaries = "Sum(Coal) as CoalAmount";
            // InitialSummaries の設定 （複数設定）
            categoryChart.InitialSummaries = "Sum(Coal) as CoalAmount, Sum(Gas) as GasAmount";

            // GroupSorts の設定　Desc または Asc
            categoryChart.GroupSorts = "CoalAmount Desc";
            //categoryChart.GroupSorts = "CoalAmount Asc";

            this.Controls.Add(categoryChart);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }

    public class EnergyProduction
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Year { get; set; }

        // Non-Renewable Energy Sources
        public double Nuclear { get; set; }
        public double Coal { get; set; }
        public double Oil { get; set; }
        public double Gas { get; set; }
        // Renewable Energy Sources
        public double Hydro { get; set; }
        public double GeoThermal { get; set; }
        public double Solar { get; set; }
        public double Wind { get; set; }

        public double Total { get { return Renewable + NonRenewable; } }
        public double Renewable { get { return Hydro + GeoThermal + Wind + Solar; } }
        public double NonRenewable { get { return Coal + Oil + Gas + Nuclear; } }
    }


    public class EnergyDataHistory : List<EnergyProduction>
    {
        public EnergyDataHistory()
        {
            this.Add(new EnergyProduction { Year = "2000", Country = "Canada", Coal = 400, Oil = 100, Gas = 175, Nuclear = 225, Hydro = 350 });
            this.Add(new EnergyProduction { Year = "2010", Country = "Canada", Coal = 450, Oil = 150, Gas = 225, Nuclear = 255, Hydro = 400 });
            this.Add(new EnergyProduction { Year = "2020", Country = "Canada", Coal = 300, Oil = 200, Gas = 275, Nuclear = 325, Hydro = 450 });
            this.Add(new EnergyProduction { Year = "2000", Country = "China", Coal = 825, Oil = 200, Gas = 350, Nuclear = 400, Hydro = 625 });
            this.Add(new EnergyProduction { Year = "2010", Country = "China", Coal = 925, Oil = 250, Gas = 400, Nuclear = 420, Hydro = 685 });
            this.Add(new EnergyProduction { Year = "2020", Country = "China", Coal = 975, Oil = 300, Gas = 450, Nuclear = 450, Hydro = 725 });
            this.Add(new EnergyProduction { Year = "2000", Country = "Russia", Coal = 550, Oil = 200, Gas = 250, Nuclear = 475, Hydro = 425 });
            this.Add(new EnergyProduction { Year = "2010", Country = "Russia", Coal = 600, Oil = 220, Gas = 280, Nuclear = 525, Hydro = 485 });
            this.Add(new EnergyProduction { Year = "2020", Country = "Russia", Coal = 650, Oil = 250, Gas = 350, Nuclear = 575, Hydro = 525 });
            this.Add(new EnergyProduction { Year = "2000", Country = "Australia", Coal = 450, Oil = 100, Gas = 150, Nuclear = 175, Hydro = 350 });
            this.Add(new EnergyProduction { Year = "2010", Country = "Australia", Coal = 480, Oil = 120, Gas = 250, Nuclear = 225, Hydro = 400 });
            this.Add(new EnergyProduction { Year = "2020", Country = "Australia", Coal = 550, Oil = 180, Gas = 350, Nuclear = 275, Hydro = 450 });
            this.Add(new EnergyProduction { Year = "2000", Country = "United States", Coal = 800, Oil = 250, Gas = 475, Nuclear = 575, Hydro = 750 });
            this.Add(new EnergyProduction { Year = "2010", Country = "United States", Coal = 850, Oil = 300, Gas = 525, Nuclear = 625, Hydro = 800 });
            this.Add(new EnergyProduction { Year = "2020", Country = "United States", Coal = 900, Oil = 350, Gas = 575, Nuclear = 675, Hydro = 850 });
            this.Add(new EnergyProduction { Year = "2000", Country = "France", Coal = 375, Oil = 150, Gas = 350, Nuclear = 275, Hydro = 325 });
            this.Add(new EnergyProduction { Year = "2010", Country = "France", Coal = 425, Oil = 200, Gas = 400, Nuclear = 325, Hydro = 385 });
            this.Add(new EnergyProduction { Year = "2020", Country = "France", Coal = 455, Oil = 250, Gas = 450, Nuclear = 375, Hydro = 425 });
        }
    }
}
