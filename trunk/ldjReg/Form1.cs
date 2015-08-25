using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace ldjReg
{
    public partial class Form1 : Form
    {
        private Dm.dmsoft dm;
        private const string key = "LuDingJi";
        public Form1()
        {
            InitializeComponent();
            RunReg("RegDll.dll /s");
            RunReg("dm.dll /s");
            RunReg("eyou.dll /s");
            dm = new Dm.dmsoft();
            if (dm.Ver() == "")
            {
                MessageBox.Show("Can't Create Object dm.dmsoft");
            }
        }
        public void RunReg(string cmd)
        {
            ProcessStartInfo pi = new ProcessStartInfo("regsvr32.exe");
            pi.Arguments = cmd;
            pi.CreateNoWindow = true;
            pi.RedirectStandardError = false;
            pi.RedirectStandardInput = false;
            pi.RedirectStandardOutput = false;
            pi.UseShellExecute = false;
            Process p = new Process();
            p.StartInfo = pi;

            p.Start();
            p.WaitForExit();
            p.Close();
        }
        /// <summary>
        /// DES加密算法
        /// sKey为8位或16位
        /// </summary>
        /// <param name="pToEncrypt">需要加密的字符串</param>
        /// <param name="sKey">密钥</param>
        /// <returns></returns>
        public string DE(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
            //return a;
        }
        public string DCode(string mCode, string key)
        {
            string dCode = "";
            char[] mCodeL = mCode.ToCharArray();
            char tmp = mCodeL[1];
            mCodeL[1] = mCodeL[mCodeL.Length - 2];
            mCodeL[mCodeL.Length - 2] = tmp;
            
            dCode = DE(new string(mCodeL), key);
            return dCode;
        }

        private void btnCreateRegCode_Click(object sender, EventArgs e)
        {
            this.txtRegCode.Text = DCode(this.txtMCode.Text.Trim(), key);
        }
    }
}
