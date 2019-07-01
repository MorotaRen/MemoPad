using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace memo {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        /// <summary>-----------------------------------///
        ///             MainWindowの作成                ///
        /// -------------------------------------</summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>-----------------------------------///
        ///             ファイルオープン                ///
        /// -------------------------------------</summary>
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            //ファイルオープンダイアログ
            OpenFileDialog openFolderDialog = new OpenFileDialog();
            if (openFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(openFolderDialog.FileName))
                {
                    var document = MemoTextBox.Document;
                    TextRange range = new TextRange(document.ContentStart, document.ContentEnd);
                    range.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }

        /// <summary>-----------------------------------///
        ///             名前を付けて保存                ///
        /// -------------------------------------</summary>
        private void NameSaveButton_Click(object sender, RoutedEventArgs e)
        {
            //名前を付けて保存ダイアログ
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "ファイル名を入力してください";   //初期ファイル名
            saveFileDialog.InitialDirectory = "@C:\\";                  //初期パス
            saveFileDialog.Title = "ファイルの名前を入力してください";  //ファイルタイトル
            saveFileDialog.Filter = "テキストファイル(.txt) | *.txt";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter sm = new System.IO.StreamWriter(saveFileDialog.FileName))
                {
                    var document = MemoTextBox.Document;
                    TextRange range = new TextRange(document.ContentStart, document.ContentEnd);
                    sm.WriteLine(range.Text);
                    sm.Close();
                }
            }
        }

        /// <summary>-----------------------------------///
        ///             テキストのフォントサイズ設定    ///
        /// -------------------------------------</summary>
        public void SetTextFontSize(int FontSize)
        {
            MemoTextBox.FontSize = FontSize;
        }

        /// <summary>-----------------------------------///
        ///             ツールボタン                    ///
        /// -------------------------------------</summary>
        private void ToolButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 wnd = new Window1();
            wnd.Show();
        }
    }
}
