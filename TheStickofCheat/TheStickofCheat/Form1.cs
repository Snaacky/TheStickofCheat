using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Helpers;

namespace TheStickofCheat
{

    public partial class Form1 : Form
    {
        string gameName = "South Park - The Stick of Truth";

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Max Money
            using (var m = new MemorySharp(ApplicationFinder.FromProcessName(gameName).FirstOrDefault()))
            {

                var moneyPtr = new IntPtr(0x01B71110);
                int[] offsets = { 0x0, 0x14, 0x14, 0x218 };
                moneyPtr = m[moneyPtr].Read<IntPtr>();
                moneyPtr = m[moneyPtr + offsets[0], false].Read<IntPtr>();
                moneyPtr = m[moneyPtr + offsets[1], false].Read<IntPtr>();
                moneyPtr = m[moneyPtr + offsets[2], false].Read<IntPtr>();
                m[moneyPtr + offsets[3], false].Write<int>(999999999);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Max Level
            using (var m = new MemorySharp(ApplicationFinder.FromProcessName(gameName).FirstOrDefault()))
            {

                var levelPtr = new IntPtr(0x01CAC924);
                int[] offsets = { 0x324, 0x38 };
                levelPtr = m[levelPtr].Read<IntPtr>();
                levelPtr = m[levelPtr + offsets[0], false].Read<IntPtr>();
                m[levelPtr + offsets[1], false].Write<int>(15);
            }

        }

    }
}
