﻿namespace tmp_matching4
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_テンプレート = new System.Windows.Forms.Button();
            this.button_比較対象 = new System.Windows.Forms.Button();
            this.button_検査対象 = new System.Windows.Forms.Button();
            this.pictureBoxIpl = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_二値化 = new System.Windows.Forms.RadioButton();
            this.trackBar_th = new System.Windows.Forms.TrackBar();
            this.textBox_th = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_合成 = new System.Windows.Forms.RadioButton();
            this.button_合成 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_平均フィルタ = new System.Windows.Forms.Label();
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.radioButton_比較開始 = new System.Windows.Forms.RadioButton();
            this.button_比較開始 = new System.Windows.Forms.Button();
            this.button_画像保存 = new System.Windows.Forms.Button();
            this.radioButton_検査対象 = new System.Windows.Forms.RadioButton();
            this.radioButton_比較対象 = new System.Windows.Forms.RadioButton();
            this.radioButton_テンプレート = new System.Windows.Forms.RadioButton();
            this.button_正解リスト = new System.Windows.Forms.Button();
            this.button_評価開始 = new System.Windows.Forms.Button();
            this.radioButton_評価開始 = new System.Windows.Forms.RadioButton();
            this.button_全探索 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_th)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // button_テンプレート
            // 
            this.button_テンプレート.Location = new System.Drawing.Point(23, 0);
            this.button_テンプレート.Name = "button_テンプレート";
            this.button_テンプレート.Size = new System.Drawing.Size(75, 23);
            this.button_テンプレート.TabIndex = 0;
            this.button_テンプレート.Text = "テンプレート";
            this.button_テンプレート.UseVisualStyleBackColor = true;
            this.button_テンプレート.Click += new System.EventHandler(this.Click_テンプレート);
            // 
            // button_比較対象
            // 
            this.button_比較対象.Location = new System.Drawing.Point(23, 29);
            this.button_比較対象.Name = "button_比較対象";
            this.button_比較対象.Size = new System.Drawing.Size(75, 23);
            this.button_比較対象.TabIndex = 1;
            this.button_比較対象.Text = "比較対象";
            this.button_比較対象.UseVisualStyleBackColor = true;
            this.button_比較対象.Click += new System.EventHandler(this.Click_比較対象);
            // 
            // button_検査対象
            // 
            this.button_検査対象.Location = new System.Drawing.Point(23, 58);
            this.button_検査対象.Name = "button_検査対象";
            this.button_検査対象.Size = new System.Drawing.Size(75, 23);
            this.button_検査対象.TabIndex = 2;
            this.button_検査対象.Text = "検査対象";
            this.button_検査対象.UseVisualStyleBackColor = true;
            this.button_検査対象.Click += new System.EventHandler(this.Click_検査対象);
            // 
            // pictureBoxIpl
            // 
            this.pictureBoxIpl.Location = new System.Drawing.Point(117, 3);
            this.pictureBoxIpl.Name = "pictureBoxIpl";
            this.pictureBoxIpl.Size = new System.Drawing.Size(549, 328);
            this.pictureBoxIpl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl.TabIndex = 3;
            this.pictureBoxIpl.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_全探索);
            this.panel1.Controls.Add(this.radioButton_評価開始);
            this.panel1.Controls.Add(this.button_評価開始);
            this.panel1.Controls.Add(this.button_正解リスト);
            this.panel1.Controls.Add(this.radioButton_二値化);
            this.panel1.Controls.Add(this.trackBar_th);
            this.panel1.Controls.Add(this.textBox_th);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton_合成);
            this.panel1.Controls.Add(this.button_合成);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label_平均フィルタ);
            this.panel1.Controls.Add(this.textBox_filter);
            this.panel1.Controls.Add(this.trackBar);
            this.panel1.Controls.Add(this.radioButton_比較開始);
            this.panel1.Controls.Add(this.button_比較開始);
            this.panel1.Controls.Add(this.button_画像保存);
            this.panel1.Controls.Add(this.radioButton_検査対象);
            this.panel1.Controls.Add(this.radioButton_比較対象);
            this.panel1.Controls.Add(this.button_検査対象);
            this.panel1.Controls.Add(this.radioButton_テンプレート);
            this.panel1.Controls.Add(this.button_比較対象);
            this.panel1.Controls.Add(this.button_テンプレート);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 430);
            this.panel1.TabIndex = 4;
            // 
            // radioButton_二値化
            // 
            this.radioButton_二値化.AutoSize = true;
            this.radioButton_二値化.Location = new System.Drawing.Point(4, 194);
            this.radioButton_二値化.Name = "radioButton_二値化";
            this.radioButton_二値化.Size = new System.Drawing.Size(14, 13);
            this.radioButton_二値化.TabIndex = 15;
            this.radioButton_二値化.UseVisualStyleBackColor = true;
            this.radioButton_二値化.CheckedChanged += new System.EventHandler(this.CheckedChange_二値化);
            // 
            // trackBar_th
            // 
            this.trackBar_th.AutoSize = false;
            this.trackBar_th.Location = new System.Drawing.Point(20, 217);
            this.trackBar_th.Maximum = 255;
            this.trackBar_th.Name = "trackBar_th";
            this.trackBar_th.Size = new System.Drawing.Size(74, 14);
            this.trackBar_th.TabIndex = 14;
            this.trackBar_th.Value = 10;
            this.trackBar_th.ValueChanged += new System.EventHandler(this.ValueChanged_th);
            // 
            // textBox_th
            // 
            this.textBox_th.Location = new System.Drawing.Point(71, 192);
            this.textBox_th.Name = "textBox_th";
            this.textBox_th.Size = new System.Drawing.Size(23, 19);
            this.textBox_th.TabIndex = 13;
            this.textBox_th.Text = "10";
            this.textBox_th.TextChanged += new System.EventHandler(this.TextChanged_th);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "二値化";
            // 
            // radioButton_合成
            // 
            this.radioButton_合成.AutoSize = true;
            this.radioButton_合成.Location = new System.Drawing.Point(3, 165);
            this.radioButton_合成.Name = "radioButton_合成";
            this.radioButton_合成.Size = new System.Drawing.Size(14, 13);
            this.radioButton_合成.TabIndex = 11;
            this.radioButton_合成.UseVisualStyleBackColor = true;
            this.radioButton_合成.CheckedChanged += new System.EventHandler(this.CheckedChange_合成);
            // 
            // button_合成
            // 
            this.button_合成.Location = new System.Drawing.Point(23, 160);
            this.button_合成.Name = "button_合成";
            this.button_合成.Size = new System.Drawing.Size(75, 23);
            this.button_合成.TabIndex = 10;
            this.button_合成.Text = "合成";
            this.button_合成.UseVisualStyleBackColor = true;
            this.button_合成.Click += new System.EventHandler(this.Click_合成);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "*2+1";
            // 
            // label_平均フィルタ
            // 
            this.label_平均フィルタ.AutoSize = true;
            this.label_平均フィルタ.Location = new System.Drawing.Point(7, 90);
            this.label_平均フィルタ.Name = "label_平均フィルタ";
            this.label_平均フィルタ.Size = new System.Drawing.Size(62, 12);
            this.label_平均フィルタ.TabIndex = 8;
            this.label_平均フィルタ.Text = "平均フィルタ";
            this.label_平均フィルタ.Click += new System.EventHandler(this.Click_平均フィルタ);
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(44, 105);
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.Size = new System.Drawing.Size(23, 19);
            this.textBox_filter.TabIndex = 7;
            this.textBox_filter.Text = "0";
            // 
            // trackBar
            // 
            this.trackBar.AutoSize = false;
            this.trackBar.Location = new System.Drawing.Point(3, 304);
            this.trackBar.Maximum = 3;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(101, 30);
            this.trackBar.TabIndex = 6;
            this.trackBar.ValueChanged += new System.EventHandler(this.ValueChanged_trackBar);
            // 
            // radioButton_比較開始
            // 
            this.radioButton_比較開始.AutoSize = true;
            this.radioButton_比較開始.Location = new System.Drawing.Point(3, 136);
            this.radioButton_比較開始.Name = "radioButton_比較開始";
            this.radioButton_比較開始.Size = new System.Drawing.Size(14, 13);
            this.radioButton_比較開始.TabIndex = 5;
            this.radioButton_比較開始.UseVisualStyleBackColor = true;
            this.radioButton_比較開始.CheckedChanged += new System.EventHandler(this.CheckedChange_比較開始);
            // 
            // button_比較開始
            // 
            this.button_比較開始.Location = new System.Drawing.Point(23, 131);
            this.button_比較開始.Name = "button_比較開始";
            this.button_比較開始.Size = new System.Drawing.Size(75, 23);
            this.button_比較開始.TabIndex = 4;
            this.button_比較開始.Text = "比較開始";
            this.button_比較開始.UseVisualStyleBackColor = true;
            this.button_比較開始.Click += new System.EventHandler(this.Click_比較開始);
            // 
            // button_画像保存
            // 
            this.button_画像保存.Location = new System.Drawing.Point(18, 349);
            this.button_画像保存.Name = "button_画像保存";
            this.button_画像保存.Size = new System.Drawing.Size(75, 23);
            this.button_画像保存.TabIndex = 3;
            this.button_画像保存.Text = "画像保存";
            this.button_画像保存.UseVisualStyleBackColor = true;
            this.button_画像保存.Click += new System.EventHandler(this.Click_画像保存);
            // 
            // radioButton_検査対象
            // 
            this.radioButton_検査対象.AutoSize = true;
            this.radioButton_検査対象.Location = new System.Drawing.Point(3, 63);
            this.radioButton_検査対象.Name = "radioButton_検査対象";
            this.radioButton_検査対象.Size = new System.Drawing.Size(14, 13);
            this.radioButton_検査対象.TabIndex = 2;
            this.radioButton_検査対象.UseVisualStyleBackColor = true;
            this.radioButton_検査対象.CheckedChanged += new System.EventHandler(this.CheckedChange_検査対象);
            // 
            // radioButton_比較対象
            // 
            this.radioButton_比較対象.AutoSize = true;
            this.radioButton_比較対象.Location = new System.Drawing.Point(3, 34);
            this.radioButton_比較対象.Name = "radioButton_比較対象";
            this.radioButton_比較対象.Size = new System.Drawing.Size(14, 13);
            this.radioButton_比較対象.TabIndex = 1;
            this.radioButton_比較対象.UseVisualStyleBackColor = true;
            this.radioButton_比較対象.CheckedChanged += new System.EventHandler(this.CheckedChange_比較対象);
            // 
            // radioButton_テンプレート
            // 
            this.radioButton_テンプレート.AutoSize = true;
            this.radioButton_テンプレート.Checked = true;
            this.radioButton_テンプレート.Location = new System.Drawing.Point(3, 3);
            this.radioButton_テンプレート.Name = "radioButton_テンプレート";
            this.radioButton_テンプレート.Size = new System.Drawing.Size(14, 13);
            this.radioButton_テンプレート.TabIndex = 0;
            this.radioButton_テンプレート.TabStop = true;
            this.radioButton_テンプレート.UseVisualStyleBackColor = true;
            this.radioButton_テンプレート.CheckedChanged += new System.EventHandler(this.CheckedChange_テンプレート);
            // 
            // button_正解リスト
            // 
            this.button_正解リスト.Location = new System.Drawing.Point(23, 246);
            this.button_正解リスト.Name = "button_正解リスト";
            this.button_正解リスト.Size = new System.Drawing.Size(75, 23);
            this.button_正解リスト.TabIndex = 16;
            this.button_正解リスト.Text = "正解リスト";
            this.button_正解リスト.UseVisualStyleBackColor = true;
            this.button_正解リスト.Click += new System.EventHandler(this.Click_正解リスト);
            // 
            // button_評価開始
            // 
            this.button_評価開始.Location = new System.Drawing.Point(23, 275);
            this.button_評価開始.Name = "button_評価開始";
            this.button_評価開始.Size = new System.Drawing.Size(75, 23);
            this.button_評価開始.TabIndex = 17;
            this.button_評価開始.Text = "評価開始";
            this.button_評価開始.UseVisualStyleBackColor = true;
            this.button_評価開始.Click += new System.EventHandler(this.Click_評価開始);
            // 
            // radioButton_評価開始
            // 
            this.radioButton_評価開始.AutoSize = true;
            this.radioButton_評価開始.Location = new System.Drawing.Point(3, 280);
            this.radioButton_評価開始.Name = "radioButton_評価開始";
            this.radioButton_評価開始.Size = new System.Drawing.Size(14, 13);
            this.radioButton_評価開始.TabIndex = 18;
            this.radioButton_評価開始.UseVisualStyleBackColor = true;
            this.radioButton_評価開始.CheckedChanged += new System.EventHandler(this.CheckedChange_評価開始);
            // 
            // button_全探索
            // 
            this.button_全探索.Location = new System.Drawing.Point(18, 378);
            this.button_全探索.Name = "button_全探索";
            this.button_全探索.Size = new System.Drawing.Size(75, 23);
            this.button_全探索.TabIndex = 19;
            this.button_全探索.Text = "全探索";
            this.button_全探索.UseVisualStyleBackColor = true;
            this.button_全探索.Click += new System.EventHandler(this.Click_全探索);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(684, 494);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxIpl);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_th)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_テンプレート;
        private System.Windows.Forms.Button button_比較対象;
        private System.Windows.Forms.Button button_検査対象;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton_検査対象;
        private System.Windows.Forms.RadioButton radioButton_比較対象;
        private System.Windows.Forms.RadioButton radioButton_テンプレート;
        private System.Windows.Forms.Button button_画像保存;
        private System.Windows.Forms.RadioButton radioButton_比較開始;
        private System.Windows.Forms.Button button_比較開始;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_平均フィルタ;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.RadioButton radioButton_合成;
        private System.Windows.Forms.Button button_合成;
        private System.Windows.Forms.TrackBar trackBar_th;
        private System.Windows.Forms.TextBox textBox_th;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_二値化;
        private System.Windows.Forms.Button button_評価開始;
        private System.Windows.Forms.Button button_正解リスト;
        private System.Windows.Forms.RadioButton radioButton_評価開始;
        private System.Windows.Forms.Button button_全探索;
    }
}

