﻿using System;
using System.Windows.Forms;

namespace Prototype.Forms
{
    public partial class CandidatesEditForm : Form
    {
        private const string StatusFormat = "Status: {0}.";

        public CandidatesEditForm()
        {
            InitializeComponent();
        }

        private void CandidatesBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            try
            {
                Validate();
                candidatesBindingSource.EndEdit();
                tableAdapterManager.UpdateAll(healthDatabaseDataSet);
                tsslStatus.Text = string.Format(StatusFormat, "saved on " + DateTime.Now);
            }
            catch (Exception)
            {
                tsslStatus.Text = string.Format(StatusFormat, "sorry, database error.");
            }
        }

        private void CandidatesEditFormLoad(object sender, EventArgs e)
        {
            rolesTableAdapter.Fill(healthDatabaseDataSet.Roles);
            candidatesTableAdapter.Fill(healthDatabaseDataSet.Candidates);
            tsslStatus.Text = string.Format(StatusFormat, "loaded on" + DateTime.Now);
        }
    }
}
