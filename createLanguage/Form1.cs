using com.calitha.goldparser;
using System.Windows.Forms;

namespace createLanguage
{
    public partial class Form1 : Form
    {
        MyParser myParser;
        public Form1()
        {
            InitializeComponent();
            myParser = new MyParser("grammar.cgt", listBox1, listBox2) ;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            myParser.Parse(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
