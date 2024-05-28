﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionWindows
{
    public partial class fmrPrincipal : Form
    {
        public fmrPrincipal()
        {
            InitializeComponent();
        }

        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Llamar al formulario del cliente
            Mantenimiento.frmCliente frm = new Mantenimiento.frmCliente();
            frm.MdiParent = this; //Es hijo del formulario principal
            frm.Show();
        }
    }
}
