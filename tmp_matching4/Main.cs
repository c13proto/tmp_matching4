using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace tmp_matching4
{
    public partial class Main : Form
    {
        Mat テンプレート;
        Mat[] 比較対象;
        Mat[] 検査対象;

        Mat[] 比較対象_filtered;
        Mat[] 検査対象_filtered;

        Mat[] 比較結果;
        Mat 合成結果;
        
        MyCV mycv = new MyCV();
        public Main()
        {
            InitializeComponent();
        }

        private void Click_テンプレート(object sender, EventArgs e)
        {
            if (テンプレート != null) テンプレート = null;
            テンプレート = new Mat();
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名をすべて表示する
                foreach (var file in dialog.FileNames.Select((value, index) => new { value, index }))
                {
                    var index = file.index;
                    テンプレート = new Mat(file.value, ImreadModes.GrayScale);
                    mycv.二値化(ref テンプレート, 254);
                }

                if (radioButton_テンプレート.Checked) 表示画像更新();
                radioButton_テンプレート.Checked = true;
            }
        }
        private void Click_比較対象(object sender, EventArgs e)
        {
            if (比較対象 != null)
            {
                比較対象 = null;
                比較対象_filtered = null;
            }
            比較対象 = new Mat[4];
            比較対象_filtered = new Mat[4];
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名をすべて表示する
                foreach (var file in dialog.FileNames.Select((value, index) => new { value, index }))
                {
                    var index = file.index;
                    比較対象[index] = new Mat(file.value, ImreadModes.GrayScale);
                    比較対象_filtered[index]= 比較対象[index].Blur(new OpenCvSharp.Size(int.Parse(textBox_filter.Text)*2+1, int.Parse(textBox_filter.Text)*2+1));
                }

                if (radioButton_比較対象.Checked) 表示画像更新();
                radioButton_比較対象.Checked = true;
            }
        }

        private void Click_検査対象(object sender, EventArgs e)
        {
            if (検査対象 != null)
            {
                検査対象 = null;
                検査対象_filtered = null;
            }
            検査対象 = new Mat[4];
            検査対象_filtered = new Mat[4];
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名をすべて表示する
                foreach (var file in dialog.FileNames.Select((value, index) => new { value, index }))
                {
                    var index = file.index;
                    検査対象[index] = new Mat(file.value, ImreadModes.GrayScale);
                    検査対象_filtered[index] = 検査対象[index].Blur(new OpenCvSharp.Size(int.Parse(textBox_filter.Text) * 2 + 1, int.Parse(textBox_filter.Text) * 2 + 1));
                }

                if (radioButton_検査対象.Checked) 表示画像更新();
                radioButton_検査対象.Checked = true;
            }
        }


        private void Click_画像保存(object sender, EventArgs e)
        {
            if (pictureBoxIpl.ImageIpl != null)
            {
                //System.IO.Directory.CreateDirectory(@"result");//resultフォルダの作成
                SaveFileDialog sfd = new SaveFileDialog();//SaveFileDialogクラスのインスタンスを作成
                                                          //sfd.FileName = textBox_Gaus.Text + "_" + textBox_Bright.Text + "_" + textBox_Cont.Text;//はじめのファイル名を指定する
                                                          //sfd.InitialDirectory = @"result\";//はじめに表示されるフォルダを指定する
                sfd.Filter = "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*";//[ファイルの種類]に表示される選択肢を指定する
                sfd.FilterIndex = 1;//[ファイルの種類]ではじめに「画像ファイル」が選択されているようにする
                sfd.Title = "保存先のファイルを選択してください";//タイトルを設定する
                sfd.RestoreDirectory = true;//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                sfd.OverwritePrompt = true;//既に存在するファイル名を指定したとき警告する．デフォルトでTrueなので指定する必要はない
                sfd.CheckPathExists = true;//存在しないパスが指定されたとき警告を表示する．デフォルトでTrueなので指定する必要はない

                //ダイアログを表示する
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき
                    //選択されたファイル名を表示する
                    System.Diagnostics.Debug.WriteLine(sfd.FileName);
                    pictureBoxIpl.ImageIpl.SaveImage(sfd.FileName);
                }
            }
        }




        private void Click_平均フィルタ(object sender, EventArgs e)
        {
            
            
            if (比較対象 != null)
            {
                比較対象_filtered = null;
                比較対象_filtered = new Mat[4];
                for (int i = 0; i < 4; i++)
                    比較対象_filtered[i] = 比較対象[i].Blur(new OpenCvSharp.Size(int.Parse(textBox_filter.Text) * 2 + 1, int.Parse(textBox_filter.Text) * 2 + 1));
            }
            if (検査対象 != null)
            {
                検査対象_filtered = null;
                検査対象_filtered = new Mat[4];
                for (int i = 0; i < 4; i++)
                    検査対象_filtered[i] = 検査対象[i].Blur(new OpenCvSharp.Size(int.Parse(textBox_filter.Text) * 2 + 1, int.Parse(textBox_filter.Text) * 2 + 1));
            }


            if (radioButton_比較対象.Checked) 表示画像更新();
            radioButton_比較対象.Checked = true;

        }

        private void Click_比較開始(object sender, EventArgs e)
        {
            if (比較対象_filtered != null && 検査対象_filtered != null && テンプレート!=null)
            {
                if (比較結果 != null) 比較結果 = null;
                比較結果 = new Mat[4];

                for (int i = 0; i < 4; i++)
                {
                    比較結果[i]=new Mat(比較対象[i].Height, 比較対象[i].Width, MatType.CV_8UC1);
                    Cv2.Absdiff(比較対象_filtered[i], 検査対象_filtered[i],比較結果[i]);
                    Cv2.Add(比較結果[i],テンプレート, 比較結果[i]);
                }
            }
            if (radioButton_比較開始.Checked) 表示画像更新();
            radioButton_比較開始.Checked = true;
            
        }

        private void Click_合成(object sender, EventArgs e)
        {
            if (比較結果 != null)
            {
                if (合成結果 != null) 合成結果 = null;
                合成結果 = new Mat(比較対象[0].Height, 比較対象[0].Width, MatType.CV_8UC1);
                mycv.Zero(ref 合成結果);
                mycv.Add4(ref 合成結果, 比較結果);
                if (radioButton_合成.Checked) 表示画像更新();
                radioButton_合成.Checked = true;
            }
        }

        void 表示画像更新()
        {
            var val = trackBar.Value;

            if (radioButton_テンプレート.Checked)
            {
                if (テンプレート != null) pictureBoxIpl.ImageIpl = テンプレート;
            }
            else if (radioButton_比較対象.Checked)
            {
                if (比較対象 != null) pictureBoxIpl.ImageIpl = 比較対象_filtered[val];
            }
            else if (radioButton_検査対象.Checked)
            {
                if (検査対象 != null) pictureBoxIpl.ImageIpl = 検査対象_filtered[val];
            }
            else if (radioButton_比較開始.Checked)
            {
                if (比較結果 != null) pictureBoxIpl.ImageIpl = 比較結果[val];
            }
            else if (radioButton_合成.Checked)
            {
                if (合成結果 != null) pictureBoxIpl.ImageIpl = 合成結果;
            }
        }

        private void CheckedChange_テンプレート(object sender, EventArgs e)
        {
            if (radioButton_テンプレート.Checked) 表示画像更新();
        }
        private void CheckedChange_比較対象(object sender, EventArgs e)
        {
            if (radioButton_比較対象.Checked) 表示画像更新();
        }
        private void CheckedChange_検査対象(object sender, EventArgs e)
        {
            if (radioButton_検査対象.Checked) 表示画像更新();
        }
        private void CheckedChange_比較開始(object sender, EventArgs e)
        {
            if (radioButton_比較開始.Checked) 表示画像更新();
        }
        private void CheckedChange_合成(object sender, EventArgs e)
        {
            if (radioButton_合成.Checked) 表示画像更新();
        }
        private void ValueChanged_trackBar(object sender, EventArgs e)
        {
            表示画像更新();
        }
    }
}
