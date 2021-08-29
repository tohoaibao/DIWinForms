using System.Windows.Forms;

namespace DIWinForms.Helpers
{
    public static class DataGridViewHelpers
    {
        public static TSource GetSelectedItem<TSource>(this DataGridView dataGridView)
            where TSource : class
        {
            if (dataGridView.CurrentRow?.DataBoundItem == null)
            {
                return null;
            }

            return (TSource)dataGridView.CurrentRow.DataBoundItem;
        }
    }
}
