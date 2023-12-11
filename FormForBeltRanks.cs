using Karate.Properties;
using Karate_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Karate
{
    public partial class FormForBeltRanks : Form
    {
        public FormForBeltRanks()
        {
            InitializeComponent();
            _RefrechData();
        }

        void _RefrechData()
        {
            DataGridViewForBelts.DataSource = clsBeltRanks.GittAllBeltRanks();
        }

        private void TxtFillterSearch_TextChanged(object sender, EventArgs e)
        {
            if(ComboFilterBelts.SelectedIndex == 0)
            {
                if (TxtFillterSearch.Text == "0" || TxtFillterSearch.Text == string.Empty)
                {
                    DataGridViewForBelts.DataSource = clsBeltRanks.GittAllBeltRanks();
                    return;
                }
                DataGridViewForBelts.DataSource = clsBeltRanks.Fillter(Convert.ToInt32(TxtFillterSearch.Text),"",0);
            }
            if (ComboFilterBelts.SelectedIndex == 1)
            {
                DataGridViewForBelts.DataSource = clsBeltRanks.Fillter(0,TxtFillterSearch.Text,0);
            }
            if (ComboFilterBelts.SelectedIndex == 2)
            {
                if (TxtFillterSearch.Text == "0" || TxtFillterSearch.Text == string.Empty)
                {
                    DataGridViewForBelts.DataSource = clsBeltRanks.GittAllBeltRanks();
                    return;
                }
                DataGridViewForBelts.DataSource = clsBeltRanks.Fillter(0,"",Convert.ToInt32(TxtFillterSearch.Text));
            }
        }

        private void btnListBelts_Click(object sender, EventArgs e)
        {
            Form New = new ListBeltsRankForm();
            New.ShowDialog();
        }

        private void btnAddNewBelt_Click(object sender, EventArgs e)
        {
            Form New = new AddBeltRank();
            New.ShowDialog();
        }

        private void btnEditBelt_Click(object sender, EventArgs e)
        {
            Form New=new EditBeltRanksForm();
            New.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form New = new FindBeltRanksForm();
            New.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ComboFilterBelts.SelectedIndex == 0)
            {
                DataGridViewForBelts.DataSource = clsBeltRanks.Fillter(Convert.ToInt32(TxtFillterSearch.Text), "", 0);
            }
            if (ComboFilterBelts.SelectedIndex == 1)
            {
                DataGridViewForBelts.DataSource = clsBeltRanks.Fillter(0, TxtFillterSearch.Text, 0);
            }
            if (ComboFilterBelts.SelectedIndex == 2)
            {
                DataGridViewForBelts.DataSource = clsBeltRanks.Fillter(0, "", Convert.ToInt32(TxtFillterSearch.Text));
            }
        }
    }
}
