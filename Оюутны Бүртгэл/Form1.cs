
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OyutniiBurtgel
{
    public class Form1 : Form
    {
        TextBox txtCode, txtPhone;
        NumericUpDown numAge;
        ComboBox cmbMajor, cmbLanguage;
        DateTimePicker dtpBirth;
        CheckBox chkScholarship;
        CheckedListBox lstSubjects;
        RadioButton rdoDay, rdoEvening;
        DataGridView dgvStudents;
        Label lblCount, lblInfo;

        public Form1()
        {
            this.Text = "Оюутны бүртгэлийн программ";
            this.Size = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Оюутны код
            AddLabel("Оюутны код:", 15, 5);
            txtCode = new TextBox();
            txtCode.SetBounds(15, 25, 120, 25);
            txtCode.Text = "M.SW24D000";
            Controls.Add(txtCode);

            lblCount = new Label();
            lblCount.SetBounds(145, 25, 100, 25);
            lblCount.Text = "Нийт: 0";
            Controls.Add(lblCount);

            // Тэтгэлэг
            chkScholarship = new CheckBox();
            chkScholarship.SetBounds(15, 60, 120, 25);
            chkScholarship.Text = "Тэтгэлэгтэй";
            Controls.Add(chkScholarship);

            // Сургалтын төрөл
            AddLabel("Сургалтын төрөл:", 15, 88);

            rdoDay = new RadioButton();
            rdoDay.SetBounds(15, 110, 130, 25);
            rdoDay.Text = "Өдрийн сургалт";
            rdoDay.Checked = true;
            Controls.Add(rdoDay);

            rdoEvening = new RadioButton();
            rdoEvening.SetBounds(15, 135, 130, 25);
            rdoEvening.Text = "Оройн сургалт";
            Controls.Add(rdoEvening);

            // Хичээлүүд
            AddLabel("Сонгох хичээл:", 15, 163);

            lstSubjects = new CheckedListBox();
            lstSubjects.SetBounds(15, 185, 140, 95);
            lstSubjects.Items.AddRange(new object[]
            {
                "Программчлал",
                "Өгөгдлийн бүтэц",
                "Алгоритм",
                "Өгөгдлийн сан",
                "Сүлжээ"
            });
            Controls.Add(lstSubjects);

            // Нас
            AddLabel("Нас:", 15, 285);
            numAge = new NumericUpDown();
            numAge.SetBounds(15, 305, 120, 25);
            numAge.Minimum = 16;
            numAge.Maximum = 100;
            numAge.Value = 21;
            Controls.Add(numAge);

            // Мэргэжил
            AddLabel("Мэргэжил:", 15, 335);
            cmbMajor = new ComboBox();
            cmbMajor.SetBounds(15, 355, 150, 25);
            cmbMajor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMajor.Items.AddRange(new object[]
            {
                "Мэдээллийн технологи",
                "Программ хангамж",
                "Систем инженерчлэл"
            });
            cmbMajor.SelectedIndex = 0;
            Controls.Add(cmbMajor);

            // Утас
            AddLabel("Утас:", 15, 385);
            txtPhone = new TextBox();
            txtPhone.SetBounds(15, 405, 120, 25);
            txtPhone.Text = "9999-9999";
            Controls.Add(txtPhone);

            // Төрсөн огноо
            AddLabel("Төрсөн огноо:", 15, 435);
            dtpBirth = new DateTimePicker();
            dtpBirth.SetBounds(15, 455, 150, 25);
            dtpBirth.Format = DateTimePickerFormat.Short;
            dtpBirth.Value = new DateTime(2005, 1, 28);
            Controls.Add(dtpBirth);

            // Хэл
            AddLabel("Хэл:", 175, 5);
            cmbLanguage = new ComboBox();
            cmbLanguage.SetBounds(175, 25, 120, 25);
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.Items.AddRange(new object[]
            {
                "Монгол", "Англи", "Орос",
                "Хятад", "Япон", "Солонгос"
            });
            cmbLanguage.SelectedIndex = 1;
            Controls.Add(cmbLanguage);

            // Оюутны хүснэгт
            AddLabel("Бүртгэгдсэн оюутнууд:", 320, 5);

            dgvStudents = new DataGridView();
            dgvStudents.SetBounds(320, 25, 530, 150);
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.Columns.Add("Code", "Оюутны код");
            dgvStudents.Columns.Add("Phone", "Утас");
            dgvStudents.Columns.Add("Age", "Нас");
            Controls.Add(dgvStudents);

            // Хөтөлбөрийн бүтэц
            AddLabel("Хөтөлбөрийн бүтэц:", 320, 185);

            TreeView tree = new TreeView();
            tree.SetBounds(320, 205, 530, 130);

            TreeNode root = tree.Nodes.Add(
                "Байгалийн ухааны сургууль");
            root.Nodes.Add("Компьютерийн ухаан");
            root.Nodes.Add("Мэдээллийн технологи");
            root.Nodes.Add("Программ хангамж");
            root.Nodes.Add("Математик");
            root.Nodes.Add("Физик");

            tree.ExpandAll();
            Controls.Add(tree);

            // Бүртгэлийн товч
            Button btnRegister = new Button();
            btnRegister.SetBounds(15, 500, 150, 40);
            btnRegister.Text = "Бүртгэх";
            btnRegister.Click += BtnRegister_Click;
            Controls.Add(btnRegister);

            // Мэдээлэл
            GroupBox grpInfo = new GroupBox();
            grpInfo.SetBounds(320, 350, 530, 220);
            grpInfo.Text = "ОЮУТНЫ БҮРТГЭЛ";
            grpInfo.Font = new Font("Arial", 10, FontStyle.Bold);
            Controls.Add(grpInfo);

            lblInfo = new Label();
            lblInfo.SetBounds(10, 25, 500, 185);
            lblInfo.Font = new Font("Arial", 10);
            grpInfo.Controls.Add(lblInfo);

            ShowInfo();
        }

        private void AddLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.SetBounds(x, y, 180, 22);
            Controls.Add(label);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (code == "" || phone == "")
            {
                MessageBox.Show("Код болон утсаа оруулна уу!");
                return;
            }

            dgvStudents.Rows.Add(code, phone, numAge.Value);

            lblCount.Text = "Нийт: " + dgvStudents.Rows.Count;

            ShowInfo();

            MessageBox.Show("Оюутан амжилттай бүртгэгдлээ!");
        }

        private void ShowInfo()
        {
            lblInfo.Text =
                "Код: " + txtCode.Text + "\n" +
                "Утас: " + txtPhone.Text + "\n" +
                "Нас: " + numAge.Value + "\n" +
                "Төрсөн огноо: " +
                dtpBirth.Value.ToString("yyyy-MM-dd") + "\n" +
                "Сургалт: " +
                (rdoDay.Checked ? "Өдрийн" : "Оройн") + "\n" +
                "Мэргэжил: " + cmbMajor.Text + "\n" +
                "Тэтгэлэг: " +
                (chkScholarship.Checked ? "Тийм" : "Үгүй") + "\n" +
                "Хичээл: " +
                string.Join(", ", lstSubjects.CheckedItems.Cast<object>()) +
                "\n" +
                "Хэл: " + cmbLanguage.Text;
        }
    }
}
