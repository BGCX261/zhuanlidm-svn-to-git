using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ldj
{
    public partial class FrmReg : Form
    {
        public FrmReg()
        {
            InitializeComponent();
            this.txtMCode.Text = new Dm.dmsoft().GetMachineCode();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string regCode = txtRegCode.Text.Trim();
            string mCode=this.txtMCode.Text.Trim();
            if (string.IsNullOrEmpty(regCode))
            {
                MessageBox.Show("请输入注册码!");
                return;
            }
            if (HardwareInfo.CheckCode(mCode, regCode, Form1.GameName))
            {
                Regedit.SetAppRegKeyValue(Form1.RegistryDirName, "RegCode", regCode);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("无效注册码!");
                txtRegCode.Text = "";
                txtRegCode.Focus();
                return;
            }
        }

    }
}
