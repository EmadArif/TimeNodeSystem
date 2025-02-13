using BasicExample.DataGridViewColumns;
using System.Reflection;
using System.Windows.Forms;
using TimeAndAttendanceSystem.Helpers.Attributes;

namespace TimeAndAttendanceSystem.Helpers.Extensions
{
    public static class Extensions
    {


        public static DateTime ToDateTime(this TimeSpan ts)
        {
            return DateTime.Today.Add(ts);
        }

        public static string ToHH_MM_TT(this DateTime dt)
        {
            return dt.ToString(@"hh\:mm tt");
        }
        public static string ToHH_MM(this DateTime dt)
        {
            return dt.ToString(@"hh\:mm tt");
        }
        public static string ToHH_MM(this TimeSpan ts)
        {
            return ts.ToString(@"hh\:mm");
        }

        public static void CallDgvRowDirty(this DataGridView dgv, Predicate<DataGridViewRow> onRowMatch)
        {
            dgv.CellEndEdit += (a, b) =>
            {
                SetRowDirty(dgv, onRowMatch);
            };
            dgv.NewRowNeeded += (a, b) =>
            {
                SetRowDirty(dgv, onRowMatch);
            };
        }

        public static void PreformEndEdit(this DataGridView dgv)
        {
            int cellIndex = FindEditableCellInFirstRow(dgv);

            if(cellIndex >= 0)
            {

                dgv.CurrentCell = dgv.Rows[0].Cells[cellIndex];
                dgv.BeginEdit(true);
                dgv.EndEdit();
                dgv.CurrentCell = null;
            }
        }

        public static void BuildDataGridViewColumnsFromClass<T>(this DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear(); // مسح أي أعمدة موجودة مسبقًا

            var properties = typeof(T).GetProperties(); // جلب خصائص الكلاس
            int index = 0;

            
            foreach (var prop in properties.Where(x => x.GetCustomAttribute<DisplayInGridAttribute>() != null))
            {
                var displayAttr = prop.GetCustomAttribute<DisplayInGridAttribute>()!;

                DataGridViewColumn column;
                if (prop.PropertyType == typeof(TimeSpan))
                {
                    column = new TimePickerColumn();
                }
                else
                {
                    column = new DataGridViewTextBoxColumn();
                }

                column.Name = prop.Name;
                column.HeaderText = prop.Name;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DataPropertyName = prop.Name;
                column.AutoSizeMode = index == 0 ? DataGridViewAutoSizeColumnMode.DisplayedCells : DataGridViewAutoSizeColumnMode.Fill;
                column.ReadOnly = displayAttr.ReadOnly;

                dgv.Columns.Add(column);

                index++;
            }

            if(index > 0)
                dgv.Columns[index - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }


        private static int FindEditableCellInFirstRow(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count > 0) // التأكد من أن هناك صفوف
            {
                for (int col = 0; col < dataGridView.Columns.Count; col++)
                {
                    DataGridViewCell cell = dataGridView.Rows[0].Cells[col];

                    if (!cell.ReadOnly && cell.Visible)
                    {
                        return col; // إرجاع فهرس العمود القابل للتحرير
                    }
                }
            }

            return -1; // لم يتم العثور على خلية قابلة للتحرير
        }


        private static void SetRowDirty(DataGridView dgv, Predicate<DataGridViewRow> onRowMatch)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Index < 0)
                    return;

                var fontFamily = dgv.Rows[row.Index].DataGridView.Font.FontFamily;

                if (onRowMatch(row))
                {
                    dgv.Rows[row.Index].DefaultCellStyle.Font = new Font(fontFamily, 9, FontStyle.Bold);

                }
                else
                {
                    dgv.Rows[row.Index].DefaultCellStyle.Font = new Font(fontFamily, 9, FontStyle.Regular);
                }
            }
        }


        public static void AddIntegerTextColumn(this DataGridView dataGridView, int columnIndex)
        {

            dataGridView.Columns[columnIndex].ValueType = typeof(int);
            dataGridView.Columns[columnIndex].DefaultCellStyle.Format = "N0";

            // معالجة الأحداث لمنع الأخطاء عند إدخال قيم غير صحيحة
            dataGridView.EditingControlShowing += (sender, e) =>
            {
                if (dataGridView.CurrentCell.OwningColumn.Index == columnIndex && e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= TextBox_KeyPress; // إزالة الاشتراك القديم لتجنب التكرار
                    textBox.KeyPress += TextBox_KeyPress;
                }
            };

            dataGridView.DataError += (sender, e) =>
            {
                // منع ظهور رسالة خطأ عند إدخال قيم غير رقمية
                e.ThrowException = false;
                MessageBox.Show("يجب إدخال رقم صحيح فقط.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView.CancelEdit();
            };
        }

        private static void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح فقط بالأرقام ومفتاح المسح الخلفي
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
