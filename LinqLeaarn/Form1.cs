using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLeaarn
{
    public partial class Form1 : Form
    {
        const string sLEVEL = "LEVEL";
        const string sNAME = "NAME";
        const string sATTRIBUTE = "ATTRIBUTE";

        DataTable dt;
        
        enum EnumName
        {
            슬라임,
            가고일,
            골렘,
            코볼트,
            고블린,
            고스트,
            언데드,
            노움,
            드래곤,
            웜,
            서큐버스,
            데빌,
            만티코어,
            바실리스트,
        }

        enum EnumAttribute
        {
            불,
            물,
            바람,
            번개,
            어둠,
            빛,
            땅,
            나무,
        }

        public Form1()
        {
            InitializeComponent();

            DataTableCreate(); // DataTable 생성
            EnemyCreate(); //  정보 생성
            ComboBoxCreate();

        }

        private void ComboBoxCreate()
        {
            foreach (EnumAttribute oName in Enum.GetValues(typeof(EnumAttribute)))
            {
                cboxAttribute.Items.Add(oName);
            }
            cboxAttribute.SelectedIndex = 0;
        }

        private void EnemyCreate()
        {

            Random rd = new Random();
            
            foreach (EnumName oName in Enum.GetValues(typeof(EnumName)))
            {
                DataRow dr = dt.NewRow();
                dr[sLEVEL] = rd.Next(1, 11); // 1 ~ 10 중에서 Random 
                dr[sNAME] = oName.ToString();

                int iEnumLength = Enum.GetValues(typeof(EnumAttribute)).Length;
                int iAttribute = rd.Next(iEnumLength);
                dr[sATTRIBUTE] = ((EnumAttribute) iAttribute).ToString();
                dt.Rows.Add(dr);
            }

            dgEnemyTable.DataSource = dt;
        }

        private void DataTableCreate()
        {
            dt = new DataTable("Enemy");

            // DataColumn 생성
            DataColumn colLevel = new DataColumn(sLEVEL, typeof(int));
            DataColumn colName = new DataColumn(sNAME, typeof(string));
            DataColumn colAttribute = new DataColumn(sATTRIBUTE, typeof(string));

            dt.Columns.Add(colLevel);
            dt.Columns.Add(colName);
            dt.Columns.Add(colAttribute);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            DataTable dtCopy = dgEnemyTable.DataSource as DataTable;

            IEnumerable<DataRow> vSortTable = null;

            switch (btn.Name)
            {
                case "btnLevel":
                    vSortTable = from oRow in dtCopy.AsEnumerable()
                                 orderby oRow.Field<int>(sLEVEL) // 정렬기준
                                 select oRow;
                    break;
                case "btnName":
                    vSortTable = from oRow in dtCopy.AsEnumerable()
                                 orderby oRow.Field<string>(sNAME) // 정렬기준
                                 select oRow;
                    break;
                case "btnAttribute":
                    vSortTable = from oRow in dtCopy.AsEnumerable()
                                 orderby oRow.Field<string>(sATTRIBUTE) // 정렬기준
                                 select oRow;
                    break;
            }

            dtCopy = vSortTable.CopyToDataTable();
            dgEnemyTable.DataSource = dtCopy;
        
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DataTable dtCopy = dgEnemyTable.DataSource as DataTable;

            IEnumerable<DataRow> vSortTable = from oRow in dtCopy.AsEnumerable()
                         where oRow.Field<string>(sATTRIBUTE) == cboxAttribute.Text && 
                         (oRow.Field<int>(sLEVEL) >= nLevelMin.Value && oRow.Field<int>(sLEVEL) <= nLevelMax.Value)
                         select oRow;

            if(vSortTable.Count() > 0)
            {
                dtCopy = vSortTable.CopyToDataTable();
                dgEnemyTable.DataSource = dtCopy;
            }
            else
            {
                MessageBox.Show("검색 조건에 맞는 Data 가 없습니다");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}