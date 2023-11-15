﻿namespace COP4365_Project3
{
    partial class Form_viewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_stockView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_patterns = new System.Windows.Forms.ComboBox();
            this.button_clearPatterns = new System.Windows.Forms.Button();
            this.smartCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aCandlestickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label_patternSelect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartCandlestickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_stockView
            // 
            chartArea1.AxisX.IsInterlaced = true;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.Name = "ChartArea_OHLC";
            chartArea2.Name = "ChartArea_Volume";
            this.chart_stockView.ChartAreas.Add(chartArea1);
            this.chart_stockView.ChartAreas.Add(chartArea2);
            this.chart_stockView.DataSource = this.smartCandlestickBindingSource;
            legend1.Name = "Legend1";
            this.chart_stockView.Legends.Add(legend1);
            this.chart_stockView.Location = new System.Drawing.Point(25, 83);
            this.chart_stockView.Name = "chart_stockView";
            this.chart_stockView.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea_OHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series1.Legend = "Legend1";
            series1.Name = "Series_OHLC";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.XValueMember = "Date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "high, low, open, close";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea_Volume";
            series2.Legend = "Legend1";
            series2.Name = "Series_Volume";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Volume";
            this.chart_stockView.Series.Add(series1);
            this.chart_stockView.Series.Add(series2);
            this.chart_stockView.Size = new System.Drawing.Size(806, 382);
            this.chart_stockView.TabIndex = 0;
            this.chart_stockView.Text = "chart_stockView";
            // 
            // button_Refresh
            // 
            this.button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Refresh.Location = new System.Drawing.Point(515, 27);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(105, 38);
            this.button_Refresh.TabIndex = 1;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_endDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(276, 42);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(222, 22);
            this.dateTimePicker_endDate.TabIndex = 2;
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(33, 42);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(222, 22);
            this.dateTimePicker_startDate.TabIndex = 3;
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_startDate.Location = new System.Drawing.Point(31, 17);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(89, 18);
            this.label_startDate.TabIndex = 4;
            this.label_startDate.Text = "Start Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(273, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "End Date:";
            // 
            // comboBox_patterns
            // 
            this.comboBox_patterns.FormattingEnabled = true;
            this.comboBox_patterns.Items.AddRange(new object[] {
            "Bullish",
            "Bearish",
            "Neutral",
            "Doji",
            "DragonFlyDoji",
            "GravestoneDoji",
            "Marubozu",
            "Hammer",
            "InvertedHammer"});
            this.comboBox_patterns.Location = new System.Drawing.Point(725, 26);
            this.comboBox_patterns.Name = "comboBox_patterns";
            this.comboBox_patterns.Size = new System.Drawing.Size(103, 21);
            this.comboBox_patterns.TabIndex = 6;
            this.comboBox_patterns.SelectedIndexChanged += new System.EventHandler(this.comboBox_patterns_SelectedIndexChanged);
            // 
            // button_clearPatterns
            // 
            this.button_clearPatterns.Location = new System.Drawing.Point(725, 50);
            this.button_clearPatterns.Name = "button_clearPatterns";
            this.button_clearPatterns.Size = new System.Drawing.Size(103, 23);
            this.button_clearPatterns.TabIndex = 7;
            this.button_clearPatterns.Text = "Clear";
            this.button_clearPatterns.UseMnemonic = false;
            this.button_clearPatterns.UseVisualStyleBackColor = true;
            this.button_clearPatterns.Click += new System.EventHandler(this.button_clearPatterns_Click);
            // 
            // smartCandlestickBindingSource
            // 
            this.smartCandlestickBindingSource.DataSource = typeof(COP4365_Project3.smartCandlestick);
            // 
            // aCandlestickBindingSource
            // 
            this.aCandlestickBindingSource.DataSource = typeof(COP4365_Project3.aCandlestick);
            // 
            // label_patternSelect
            // 
            this.label_patternSelect.AutoSize = true;
            this.label_patternSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_patternSelect.Location = new System.Drawing.Point(726, 8);
            this.label_patternSelect.Name = "label_patternSelect";
            this.label_patternSelect.Size = new System.Drawing.Size(101, 15);
            this.label_patternSelect.TabIndex = 8;
            this.label_patternSelect.Text = "Pattern Select:";
            // 
            // Form_viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(856, 477);
            this.Controls.Add(this.label_patternSelect);
            this.Controls.Add(this.button_clearPatterns);
            this.Controls.Add(this.comboBox_patterns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.chart_stockView);
            this.Name = "Form_viewer";
            this.Text = "Stock Viewer";
            this.Load += new System.EventHandler(this.Form_viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartCandlestickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCandlestickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockView;
        private System.Windows.Forms.BindingSource aCandlestickBindingSource;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource smartCandlestickBindingSource;
        private System.Windows.Forms.ComboBox comboBox_patterns;
        private System.Windows.Forms.Button button_clearPatterns;
        private System.Windows.Forms.Label label_patternSelect;
    }
}